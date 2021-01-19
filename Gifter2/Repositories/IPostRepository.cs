using Gifter2.Models;
using System;
using System.Collections.Generic;

namespace Gifter2.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        Post GetById(int id);
        List<Post> GetByUserProfileId(int id);
        void Update(Post post);
        List<Post> Hottest(DateTime startDate);
        List<Post> Search(string searchTerm, bool recent);
    }
}