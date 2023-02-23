using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Interfaces.Services
{
    public interface IBaseCommandService<Dto, Entity>
    {
        Task<BaseResponse<Dto>> InsertAsync(Dto insertResource);
        Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource);
        Task<BaseResponse<Dto>> RemoveAsync(int id);
    }
}
