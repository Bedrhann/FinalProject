using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Interfaces.Services.UserServices
{
    public interface IUserCommandService
    {
        Task<BaseResponse<CreateUserCommandRequest>> InsertAsync(CreateUserCommandRequest insertResource);
        Task<BaseResponse<CreateUserCommandRequest>> UpdateAsync(Guid id, CreateUserCommandRequest updateResource);
        Task<BaseResponse<CreateUserCommandRequest>> RemoveAsync(Guid id);
        Task<BaseResponse<CreateUserCommandRequest>> GetByIdAsync(Guid id);
        Task<BaseResponse<IEnumerable<CreateUserCommandRequest>>> GetAllAsync();
    }
}
