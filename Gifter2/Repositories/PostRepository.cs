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
            return _context.Post.Include(p => p.UserProfile)
                .Take(3)
                .OrderBy(p => p.DateCreated)
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
            _context.Add(post);
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
            _context.SaveChanges();
        }

        public List<Post> GetByUserProfileId(int id)
        {
            return _context.Post.Include(p => p.UserProfile)
                .Where(p => p.UserProfileId == id)
                .OrderBy(p => p.Title)
                .ToList();
        }

    }
}
