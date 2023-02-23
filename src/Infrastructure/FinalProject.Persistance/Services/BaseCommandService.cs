using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;

namespace FinalProject.Persistance.Services
{
    public class BaseCommandService<Dto,Entity> : IBaseCommandService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly ICommandRepository<Entity> _commandRepository;
        public BaseCommandService(ICommandRepository<Entity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public Task<BaseResponse<Dto>> InsertAsync(Dto insertResource)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Dto>> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Dto>> UpdateAsync(Guid id, Dto updateResource)
        {
            throw new NotImplementedException();
        }
    }
}
