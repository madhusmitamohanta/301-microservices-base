using System;

namespace MT.OnlineRestaurant.DataLayer.Context
{
    public class TblTableReview
    {
        public int Id { get; set; }
        public int? TblUserId { get; set; }
        public int? TblRestaurantId { get; set; }
        public int? TblRatingId { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}