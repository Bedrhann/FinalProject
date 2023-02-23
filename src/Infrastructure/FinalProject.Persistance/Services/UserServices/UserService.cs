using FinalProject.Application.DTOs.Base;
using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Persistance.Services.UserServices
{
    public class UserService : IUserService
    {
        readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;

        public UserService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<BaseResponse<UserCommandDto>> CheckAsync(UserCommandDto insertResource)
        {
            AppUser user = await _userManager.FindByNameAsync(insertResource.UserName);
            if (user == null)
                user = await _userManager.FindByEmailAsync(insertResource.UserName);

            if (user == null)
                throw new Exception();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, insertResource.Password, false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                List<Claim> claims = new List<Claim>();
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                claims.Add(new Claim("Id", user.Id));

                Token token = _tokenGenerater.CreateAccessToken(5, claims);
                return new CheckUserCommandResponse()
                {
                    Token = token
                };
            }
            throw new NotImplementedException();

        }

        public async Task<BaseResponse<CreateUserCommandRequest>> CreateAsync(CreateUserCommandRequest request)
        {

            
            //********


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

            return new BaseResponse<CreateUserCommandRequest>(result.Succeeded);
        }

        public Task<BaseResponse<UserCommandDto>> CreateAsync(UserCommandDto insertResource)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<UserQueryDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserQueryDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserCommandDto>> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserCommandDto>> UpdateAsync(Guid id, UserCommandDto updateResource)
        {
            throw new NotImplementedException();
        }
    }
}
