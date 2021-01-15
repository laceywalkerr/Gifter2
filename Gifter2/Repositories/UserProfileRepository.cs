using Gifter2.Data;
using Gifter2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        // below is the dependancy injetion 
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public void Add(UserProfile user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userPosts = _context.Post.Include(p = p.Comments).Where(p = p.UserProfileId == id);
            _context.Post.RemoveRange(userPosts);

            var user = GetById(id);
            _context.UserProfile.Remove(user);

            _context.SaveChanges();
        }



        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(p => p.Id == id);
        }

        public void Update(UserProfile user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
