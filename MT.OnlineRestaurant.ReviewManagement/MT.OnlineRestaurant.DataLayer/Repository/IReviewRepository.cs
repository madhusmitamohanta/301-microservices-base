using MT.OnlineRestaurant.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public interface IReviewRepository
    {
        TblTableReview GetReviewDetails(int reviewID);
        bool UpdateYourReview(TblTableReview tblTableReview);
        bool PostYourReview(TblTableReview tblTableReview);
    }
}
