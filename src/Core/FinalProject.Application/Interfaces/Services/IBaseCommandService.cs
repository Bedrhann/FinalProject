using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Interfaces.Services
{
    public interface IBaseCommandService<DtoCreate,DtoUpdate, Entity>
    {
        Task<BaseResponse<DtoCreate>> InsertAsync(DtoCreate insertResource);
        Task<BaseResponse<DtoUpdate>> UpdateAsync(Guid id, DtoUpdate updateResource);
        Task<BaseResponse<object>> RemoveAsync(Guid id);
    }
}
