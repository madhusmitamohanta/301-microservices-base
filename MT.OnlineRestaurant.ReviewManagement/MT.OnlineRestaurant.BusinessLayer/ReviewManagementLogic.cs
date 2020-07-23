using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.DataLayer.Context;
using MT.OnlineRestaurant.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MT.OnlineRestaurant.BusinessLayer
{
    public class ReviewManagementLogic : IReviewManagementLogic
    {

        IReviewRepository review_Repository;
        private readonly string connectionstring;
        public ReviewManagementLogic(IReviewRepository _reviewRepository)
        {
            review_Repository = _reviewRepository;
        }
        public ReviewInformation GetReviewDetails(int reviewID)
        {
            try
            {
                TblTableReview reviewDetail = new TblTableReview();
                reviewDetail = review_Repository.GetReviewDetails(reviewID);
                ReviewInformation review_Information = new ReviewInformation
                {
                    ReviewId=reviewDetail.Id,
                    RestaurantId=reviewDetail.TblRestaurantId,
                    Comments=reviewDetail.Comments,
                    CreatedBy=reviewDetail.CreatedBy,
                    RatingId=reviewDetail.TblRatingId,
                    UpdatedBy=reviewDetail.UpdatedBy,
                    CreatedDateTime=reviewDetail.CreatedDateTime,
                    UpdatedDateTime=reviewDetail.UpdatedDateTime,
                    UserId=reviewDetail.TblUserId
                };
                return review_Information;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateReviewDetails(ReviewInformation updatedReview)
        {

            TblTableReview tblTableReview;

            if (updatedReview != null)
            {
                tblTableReview = new TblTableReview();
                tblTableReview.Id = updatedReview.ReviewId;
                tblTableReview.TblUserId = updatedReview.UserId;
                tblTableReview.CreatedBy = updatedReview.CreatedBy;
                tblTableReview.CreatedDateTime = updatedReview.CreatedDateTime;
                tblTableReview.TblRestaurantId = updatedReview.RestaurantId;
                tblTableReview.TblRatingId = updatedReview.RatingId;
                tblTableReview.Comments = updatedReview.Comments;
                tblTableReview.UpdatedDateTime = DateTime.Now;
                return review_Repository.UpdateYourReview(tblTableReview);
            }

            return false;
        }
    }
}
