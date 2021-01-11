using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Gifter2.Repositories
{
    public class PostRepository
    {
        [Route("api/[controller]")]
        [ApiController]
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
            public IActionResult Get(int id)
            {
                var post = _postRepository.GetById(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
        }
    }
}
