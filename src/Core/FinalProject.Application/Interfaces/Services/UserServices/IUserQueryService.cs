using FinalProject.Application.DTOs.User;
using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Interfaces.Services.UserServices
{
    public interface IUserQueryService
    {
        Task<BaseResponse<GetUserDto>> InsertAsync(GetUserDto insertResource);
        Task<BaseResponse<GetUserDto>> UpdateAsync(Guid id, GetUserDto updateResource);
        Task<BaseResponse<GetUserDto>> RemoveAsync(Guid id);
        Task<BaseResponse<GetUserDto>> GetByIdAsync(Guid id);
        Task<BaseResponse<IEnumerable<GetUserDto>>> GetAllAsync();
    }
}
