using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRequestAuthDTO userRequest)
        {
            var user = new User()
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Country = userRequest.Country,
                DateOfBirth = userRequest.DateOfBirth,
                Address = userRequest.Address,
                IsActive = true,
                Type = "U"
            };

            var result = await _userService.Insert(user);
            if (!result) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAuthDTO authDTO)
        {
            //TODO: Validar email
            var result = await _userService.SignIn(authDTO.Email, authDTO.Password);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
