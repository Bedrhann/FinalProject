using FinalProject.Application.DTOs.Base;
using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Interfaces.ForeignServices;
using FinalProject.Application.Interfaces.Services.UserServices;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Identity;
using FinalProject.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FinalProject.Persistance.Services.UserServices
{
    public class UserService : IUserService
    {
        readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;
        private readonly IGenerateToken _tokenGenerater;

        public UserService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IGenerateToken tokenGenerater)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerater = tokenGenerater;
        }

        public async Task<BaseResponse<Token>> CheckAsync(UserCommandDto insertResource)
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
                return new BaseResponse<Token>(token);
            }
            throw new Exception();//TODO exeption kontolu dikkay!!!!

        }

        public async Task<BaseResponse<UserCommandDto>> CreateAsync(UserCommandDto insertResource)
        {
            //Veritabanına ilk kez admin ve user rollerini vermek için kullanıyoruz.
            //await _roleManager.CreateAsync(new AppRole { Id = "sdfsdfsfs", Name = "Admin" });
            //await _roleManager.CreateAsync(new AppRole { Id = "dfsdffsf", Name = "User" });
            AppUser NewUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = insertResource.UserName,
                FirstName = insertResource.FirstName,
                LastName = insertResource.LastName,
                Email = insertResource.Email,
                RegistrationDate = DateTime.UtcNow,
            };

            IdentityResult result = await _userManager.CreateAsync(NewUser, insertResource.Password);
            await _userManager.AddToRoleAsync(NewUser, "User");

            return new BaseResponse<UserCommandDto>(result.Succeeded);
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
