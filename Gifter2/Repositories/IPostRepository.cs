using Gifter2.Models;
using System.Collections.Generic;

namespace Gifter2.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);

        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        List<Post> GetUserByProfileId(int id);
    }
}