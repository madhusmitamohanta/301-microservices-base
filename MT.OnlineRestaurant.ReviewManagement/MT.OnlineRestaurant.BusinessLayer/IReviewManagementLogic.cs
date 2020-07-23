using MT.OnlineRestaurant.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public interface IReviewManagementLogic
    {
        ReviewInformation GetReviewDetails(int reviewID);
        bool UpdateReviewDetails(ReviewInformation updatedReview);
    }
}
