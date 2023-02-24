using FinalProject.Application.Wrappers.Paging;

namespace FinalProject.Application.DTOs.ShopList
{
    public class ShopListGetAllRequestDto : BasePagingRequest
    {
        public Guid? UserId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
        public bool IsCompleted { get; set; }
    }
}
