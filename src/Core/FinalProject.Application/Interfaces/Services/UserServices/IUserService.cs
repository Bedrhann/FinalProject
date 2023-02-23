using FinalProject.Application.DTOs.User;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Models;

namespace FinalProject.Application.Interfaces.Services.UserServices
{
    public interface IUserService
    {
        Task<BaseResponse<UserCommandDto>> CreateAsync(UserCommandDto insertResource);
        Task<BaseResponse<Token>> CheckAsync(UserCommandDto insertResource);
        Task<BaseResponse<UserCommandDto>> UpdateAsync(Guid id, UserCommandDto updateResource);
        Task<BaseResponse<UserCommandDto>> RemoveAsync(Guid id);
        Task<BaseResponse<UserQueryDto>> GetByIdAsync(Guid id);
        Task<BaseResponse<IEnumerable<UserQueryDto>>> GetAllAsync();
    }
}
