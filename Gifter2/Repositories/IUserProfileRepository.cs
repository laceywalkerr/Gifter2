using Gifter2.Models;
using System.Collections.Generic;

namespace Gifter2.Repositories
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAll();
        void Add(UserProfile user);
        void Delete(int id);
        UserProfile GetById(int id);
        void Update(UserProfile user);

    }
}