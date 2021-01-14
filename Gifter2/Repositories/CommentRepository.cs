using Gifter2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _context;

        // below is the dependancy injetion 
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
