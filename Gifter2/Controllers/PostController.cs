using Gifter2.Models;
using Gifter2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // Dependancy injection
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        //[HttpGet("getbyuser/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_postRepository.GetByUserProfileId(id));
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            _postRepository.Add(post);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Optional:
            //var existingPost = _postRepository.GetById(id);
            //if (existingPost == null)
            //{
            //    return NotFound();
            //}

            _postRepository.Delete(id);
            return NoContent();
        }

        // The method below will respond to a request that looks like this
        // https://localhost:5001/api/post/search?q=p&sortDesc=false

        //[HttpGet("search")]
        //public IActionResult Search(string q, bool sortDesc)
        //{
        //    return Ok(_postRepository.Search(q, sortDesc));
        //}

        //[HttpGet("hottest")]
        //public IActionResult Search(string q, int DateTime)
        //{
        //    return Ok(_postRepository.Search(q, DateTime));
        //}

        [HttpGet("search")]
        public IActionResult Search(string criterion)
        {
            var posts = _postRepository.GetAll();
            return Ok(posts);
        }
    }
}
