using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services
{
    public abstract class BaseQueryService<Dto,Entity> : IBaseQueryService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly IBaseQueryRepository<Entity> _queryRepository;
        public BaseQueryService(IBaseQueryRepository<Entity> commandRepository)
        {
            _queryRepository = commandRepository;
        }

        public virtual async Task<BaseResponse<Dto>> GetByIdAsync(Guid id)
        {
            Entity ShopList = await _queryRepository.GetByIdAsync(id.ToString());
                
            return new BaseResponse<Dto>(ShopList.Adapt<Dto>());
        }
    }
}
