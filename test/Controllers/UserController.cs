using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using test.Models;
using test.Services;

namespace test.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() => Ok(await userService.GetAllUsers());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            var id = await userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel user)
        {
            if (id != user.id) return BadRequest();
            await userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUser(id);
            return NoContent();
        }

    }

}
