using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessEntities
{
    public class ReviewInformation
    {

        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? RestaurantId { get; set; }
        public int? RatingId { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
