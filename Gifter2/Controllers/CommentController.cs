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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentrepository)
        {
            _commentRepository = commentrepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_commentRepository.GetAll());
        }

        public IActionResult Add(Comment comment)
        {
            _commentRepository.Add(comment);
            return CreatedAtAction("Get", new { id = comment.Id });
        }

        [HttpPut("id")]
        public IActionResult Update(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _commentRepository.Update(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentRepository.Delete(id);
            return NoContent();
        }
    }
}
