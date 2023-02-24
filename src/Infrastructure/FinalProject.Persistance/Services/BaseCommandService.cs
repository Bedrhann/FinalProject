using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services
{
    public abstract class BaseCommandService<Dto,Entity> : IBaseCommandService<Dto,Entity> where Entity : BaseEntity
    {
        private readonly ICommandRepository<Entity> _commandRepository;
        private readonly IQueryRepository<Entity> _queryRepository;
        public BaseCommandService(ICommandRepository<Entity> commandRepository, IQueryRepository<Entity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }



        //*******************       INSERT     **********************
        public async Task<BaseResponse<Dto>> InsertAsync(Dto insertResource)
        {

            await _commandRepository.AddAsync(insertResource.Adapt<Entity>());
            await _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(insertResource);
        }




        //*******************       UPDATE     **********************
        public virtual async Task<BaseResponse<Dto>> UpdateAsync(Guid id, Dto updateResource)
        {
            Entity UpdatedEntity = await _queryRepository.GetByIdAsync(id.ToString());
            updateResource.Adapt<Dto, Entity>(UpdatedEntity);
            _commandRepository.Update(UpdatedEntity);
            await _commandRepository.SaveAsync();


            return new BaseResponse<Dto>(true);
        }




        //*******************       DELETE     **********************
        public async Task<BaseResponse<Dto>> RemoveAsync(Guid id)
        {
            Entity DeletedProduct = await _queryRepository.GetByIdAsync(id.ToString());
            _commandRepository.Remove(DeletedProduct);
            _commandRepository.SaveAsync();

            return new BaseResponse<Dto>(true);
        }




    }
}
