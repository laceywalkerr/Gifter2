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
    public class UserProfileController : ControllerBase
    {
        private IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allUsers = _userProfileRepository.GetAll();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userProfileRepository.GetById(id);

            if (user == null)

            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult GetByUser(UserProfile user)
        {
            user.DateCreated = DateTime.Now;

            _userProfileRepository.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserProfile user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _userProfileRepository.GetById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _userProfileRepository.Update(user);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepository.Delete(id);
            return NoContent();
        }



    }
}
