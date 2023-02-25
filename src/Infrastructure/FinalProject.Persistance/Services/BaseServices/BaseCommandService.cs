using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services.BaseServices
{
    public class BaseCommandService<Dto, Entity> : IBaseCommandService<Dto, Entity> where Entity : BaseEntity
    {
        private readonly IBaseCommandRepository<Entity> _commandRepository;
        private readonly IBaseQueryRepository<Entity> _queryRepository;
        public BaseCommandService(IBaseCommandRepository<Entity> commandRepository, IBaseQueryRepository<Entity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }



        //*******************       INSERT     **********************
        public virtual async Task<BaseResponse<Dto>> InsertAsync(Dto insertResource)
        {

            bool result = await _commandRepository.AddAsync(insertResource.Adapt<Entity>());
            await _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(result);
        }




        //*******************       UPDATE     **********************
        public virtual async Task<BaseResponse<Dto>> UpdateAsync(Guid id, Dto updateResource)
        {
            Entity UpdatedEntity = await _queryRepository.GetByIdAsync(id.ToString());
            updateResource.Adapt(UpdatedEntity);
            bool result = _commandRepository.Update(UpdatedEntity);
            await _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(result);
        }




        //*******************       DELETE     **********************
        public virtual async Task<BaseResponse<Dto>> RemoveAsync(Guid id)
        {
            bool result = await _commandRepository.RemoveByIdAsync(id.ToString());
            await _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(result);
        }




    }
}
