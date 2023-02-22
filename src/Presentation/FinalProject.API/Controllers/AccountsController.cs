using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountsController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public class CreateUserCommandRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }


        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            
            AppUser NewUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                RegistrationDate = DateTime.UtcNow,
            };

            IdentityResult result = await _userManager.CreateAsync(NewUser, "12345");
            await _userManager.AddToRoleAsync(NewUser, "User");

            return Ok();
        }


    }
}
