using Gifter2.Models;
using System.Collections.Generic;

namespace Gifter2.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);
    }
}