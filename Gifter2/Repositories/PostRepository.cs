using Gifter2.Data;
using Gifter2.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Gifter2.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _context;

        // below is the dependancy injetion 
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            // this is the table we're going to look at
            return _context.Post.Include(p => p.UserProfile)
                // we could to limit it to three, but we decided otherwise
                //.Take(3)
                // we're going to order it by date created
                .OrderBy(p => p.DateCreated)
                // this tells the program to fire it off and then list the items
                .ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Post post)
        {
            // .Add stages 
            _context.Add(post);
            // .SaveChanges executes
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = GetById(id);
            _context.Post.Remove(post);

            //var userToDelete = _context.UserProfile.Where(up => up.Id == post.UserProfileId);
            //_context.UserProfile.RemoveRange(userToDelete);

            _context.SaveChanges();
        }

        public List<Post> GetByUserProfileId(int id)
        {
            return _context.Post.Include(p => p.UserProfile)
                .Where(p => p.UserProfileId == id)
                .OrderBy(p => p.Title)
                .ToList();
        }


        public List<Post> Hottest(DateTime startDate)
        {
            var query = _context.Post
                                .Include(p => p.UserProfile)
                                .Where(p => p.DateCreated >= startDate);

            return query.ToList();
        }

        public List<Post> Search(string searchTerm, bool recent)
        {
            var query = _context.Post
                .Where(p => p.Title.Contains(searchTerm));
            //.ToList();

            if (recent == true)
            {
                return query.OrderByDescending(p => p.DateCreated).ToList();
            }
            else
            {
                return query.OrderBy(p => p.DateCreated).ToList();
            }
        }

    }
}
