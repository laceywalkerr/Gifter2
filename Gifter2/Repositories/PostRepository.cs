using Gifter2.Data;
using Gifter2.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Post.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post.FirstOrDefault(p => p.Id == id);
        }


    }
}
