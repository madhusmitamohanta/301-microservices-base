using MT.OnlineRestaurant.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MT.OnlineRestaurant.DataLayer.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewManagementContext db;
        public ReviewRepository(ReviewManagementContext connection)
        {
            db = connection;
        }

        #region Interface Methods
        public TblTableReview GetReviewDetails(int reviewID)
        {
            TblTableReview rreviewInformation = new TblTableReview();

                try
                {
                    if (db != null)
                    {
                    rreviewInformation = (from review in db.TblTableReview
                                          where review.Id == reviewID
                                          select new TblTableReview
                                          {
                                              Id = review.Id,
                                              Comments=review.Comments,
                                              CreatedBy=review.CreatedBy,
                                              CreatedDateTime=review.CreatedDateTime,
                                              TblRatingId=review.TblRatingId,
                                              TblRestaurantId=review.TblRestaurantId,
                                              TblUserId=review.TblUserId,
                                              UpdatedBy=review.UpdatedBy,
                                              UpdatedDateTime=review.UpdatedDateTime                                              

                                          }).FirstOrDefault();
                                          
                                          
                    }

                    return rreviewInformation;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
         

        }

        public bool PostYourReview(TblTableReview tblTableReview)
        {           

            if (tblTableReview != null)
            {
                db.Add(tblTableReview);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateYourReview(TblTableReview tblTableReview)
        {
            TblTableReview tblTableReviewEntity = db.Set<TblTableReview>().Where(tto => tto.Id == tblTableReview.Id).FirstOrDefault();

            if (tblTableReviewEntity != null)
            {
                tblTableReviewEntity = tblTableReview;
                tblTableReview.UpdatedDateTime = DateTime.Now;

                db.SaveChanges();

                return true;
            }

            return false;
        }
        #endregion
    }
}
