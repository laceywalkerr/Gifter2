using Gifter2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();
        // I thought the GetAll was for the posts, wouldnt it need (int postId) ?

        void Add(Comment comment);
        void Update(Comment commnet);
        void Delete(int id);
        Comment GetById(int id);
        List<Comment> GetByUserProfileId(int id);


    }
}
