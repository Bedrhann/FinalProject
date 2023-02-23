using FinalProject.Application.Wrappers.Paging;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserQueryRequest : BasePagingRequest, IRequest<GetAllUserQueryResponse>
    {
        public string? UserId { get; set; }
        public string? SearchByUserName { get; set; }
        public DateTime? RegistrationRangeCeiling { get; set; }
        public DateTime? RegistrationRangeLower { get; set; }
    }
}
