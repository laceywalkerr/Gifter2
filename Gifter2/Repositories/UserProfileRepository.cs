using Gifter2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Repositories
{
    public class UserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        // below is the dependancy injetion 
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfileRepository> GetAll()
        {
            return _context.UserProfile.ToList();
        }
    }
}
