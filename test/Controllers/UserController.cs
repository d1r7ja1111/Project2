using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Services.interfaces;

namespace test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService _userService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetUsers() =>
            Ok(await _userService.GetAllUsers());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            var id = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id }, user);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UserModel user)
        {
            if (id != user.id) return BadRequest("ID mismatch.");
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
