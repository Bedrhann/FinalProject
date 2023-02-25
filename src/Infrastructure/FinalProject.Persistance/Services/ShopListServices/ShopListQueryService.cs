using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using FinalProject.Domain.Entities;
using FinalProject.Persistance.Services.BaseServices;
using Mapster;

namespace FinalProject.Persistance.Services.ShopListServices
{
    public class ShopListQueryService : BaseQueryService<ShopListQueryDto, ShopList>, IShopListQueryService
    {
        private readonly IBaseQueryRepository<ShopList> _repository;
        private readonly IShopListQueryArchiveRepository _archiveRepository;

        public ShopListQueryService(IBaseQueryRepository<ShopList> repository, IShopListQueryArchiveRepository archiveRepository) : base(repository)
        {
            _repository = repository;
            _archiveRepository = archiveRepository;
        }

        public async Task<BaseResponseWithPaging<List<ShopListQueryDto>>> GetAllAsync(ShopListGetAllRequestDto request, bool isByUser, bool? İsArchive = false)
        {
            IQueryable<ShopList> Lists = null;
            if (isByUser)
            {
                Lists = _repository.GetWhere(x => x.AppUserId == request.UserId.ToString() && x.IsDeleted == false);
            }
            else
            {
                Lists = _repository.GetAll();
            }

            if (request.IsCompleted)
            {
                Lists = Lists.Where(x => x.IsCompleted == true);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Lists = Lists.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.CreationRangeLower);
            }

            int TotalUser = Lists.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            BasePagingResponse PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };
            List<ShopList> ShopLists = Lists.Skip(Skip).Take(request.Limit).ToList();
            List<ShopListQueryDto> ShopListDtoList = ShopLists.Adapt<List<ShopListQueryDto>>();

            return new BaseResponseWithPaging<List<ShopListQueryDto>>(new BaseResponse<List<ShopListQueryDto>>(ShopListDtoList), PageInfo);
        }
    }
}
