using Gifter2.Data;
using Gifter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        // below is the dependancy injetion 
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        //{
        //    return _context.Comment
        //        .Where(c => c.PostId == postId)
        //        .ToList();
        //}

        {
            throw new NotImplementedException();
        }


        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetByUserProfileId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment commnet)
        {
            throw new NotImplementedException();
        }
    }
}
