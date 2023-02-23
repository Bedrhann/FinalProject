using FinalProject.Application.DTOs.User;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<UserQueryDto> Users { get; set; }
        public BasePagingResponse PagingInfo { get; set; }
    }
}
