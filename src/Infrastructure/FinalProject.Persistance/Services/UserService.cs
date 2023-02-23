using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Persistance.Services
{
    public class UserService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;

        public UserService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<BaseResponse<object>> CreateAsync(CreateUserCommandRequest request)
        {
            AppUser NewUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                Email = request.Email,
                RegistrationDate = DateTime.UtcNow,
            };

            IdentityResult result = await _userManager.CreateAsync(NewUser, request.Password);
            await _userManager.AddToRoleAsync(NewUser, "User");

            return new BaseResponse<Object>(result.Succeeded);
        }

    }
}
