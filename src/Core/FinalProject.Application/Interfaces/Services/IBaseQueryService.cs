using FinalProject.Application.Wrappers.Base;

namespace FinalProject.Application.Interfaces.Services
{
    public interface IBaseQueryService<Dto, Entity>
    {
        Task<BaseResponse<Dto>> GetByIdAsync(Guid id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
    }
}
