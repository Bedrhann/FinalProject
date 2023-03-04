using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Common;
using Mapster;

namespace FinalProject.Persistance.Services.BaseServices
{
    public class BaseCommandService<DtoCreate,DtoUpdate, Entity> : IBaseCommandService<DtoCreate, DtoUpdate, Entity> where Entity : BaseEntity
    {
        private readonly IBaseCommandRepository<Entity> _commandRepository;
        private readonly IBaseQueryRepository<Entity> _queryRepository;
        public BaseCommandService(IBaseCommandRepository<Entity> commandRepository, IBaseQueryRepository<Entity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }



        //*******************       INSERT     **********************
        public virtual async Task<BaseResponse<DtoCreate>> InsertAsync(DtoCreate insertResource)
        {

            bool result = await _commandRepository.AddAsync(insertResource.Adapt<Entity>());
            await _commandRepository.SaveAsync();

            return new BaseResponse<DtoCreate>(result);
        }




        //*******************       UPDATE     **********************
        public virtual async Task<BaseResponse<DtoUpdate>> UpdateAsync(Guid id, DtoUpdate updateResource)
        {
            Entity UpdatedEntity = await _queryRepository.GetByIdAsync(id.ToString());
            updateResource.Adapt(UpdatedEntity);
            bool result = _commandRepository.Update(UpdatedEntity);
            await _commandRepository.SaveAsync();

            return new BaseResponse<DtoUpdate>(result);
        }




        //*******************       DELETE     **********************
        public virtual async Task<BaseResponse<Object>> RemoveAsync(Guid id)
        {
            bool result = await _commandRepository.RemoveByIdAsync(id.ToString());
            await _commandRepository.SaveAsync();

            return new BaseResponse<Object>(result);
        }




    }
}
