using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services
{
    public class BaseQueryService<Dto,Entity> : IBaseQueryService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly IQueryRepository<Entity> _queryRepository;
        public BaseQueryService(IQueryRepository<Entity> commandRepository)
        {
            _queryRepository = commandRepository;
        }

        public async Task<BaseResponse<Dto>> GetByIdAsync(Guid id)
        {
            Entity ShopList = await _queryRepository.GetByIdAsync(id.ToString());
                
            return new BaseResponse<Dto>(ShopList.Adapt<Dto>());
        }
    }
}
