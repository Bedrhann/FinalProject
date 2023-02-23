using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;

namespace FinalProject.Persistance.Services
{
    public class BaseQueryService<Dto,Entity> : IBaseQueryService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly ICommandRepository<Entity> _commandRepository;
        public BaseQueryService(ICommandRepository<Entity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Dto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
    }
}
