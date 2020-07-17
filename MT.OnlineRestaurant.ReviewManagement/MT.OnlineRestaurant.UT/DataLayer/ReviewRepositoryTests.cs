using Microsoft.EntityFrameworkCore;
using MT.OnlineRestaurant.DataLayer.Context;
using MT.OnlineRestaurant.DataLayer.Repository;
using NUnit.Framework;
using System;

namespace MT.OnlineRestaurant.UT.DataLayer
{
    [TestFixture]
    public class ReviewRepositoryTests
    {

        [Test]
        public void Test_GetReviewDetails()
        {

            TblTableReview reviewDetails = new TblTableReview()
            {
                Id = 1,
                TblRatingId = 1,
                Comments = "Bad Experience",
                CreatedBy = "Madhusmita",
                CreatedDateTime = DateTime.Now,
                UpdatedBy = "Madhusmita",
                UpdatedDateTime = DateTime.Now,
                TblRestaurantId = 1,
                TblUserId = 1
            };

            var options = new DbContextOptionsBuilder<ReviewManagementContext>()
            .UseInMemoryDatabase(databaseName: "ReviewManagement")
            .Options;

            ReviewRepository repo = new ReviewRepository(new ReviewManagementContext(options));
            var review = repo.GetReviewDetails(2);
            Assert.IsNull(review);

        }

        [Test]
        public void Test_UpdateReviewDetails()
        {

            TblTableReview reviewDetails = new TblTableReview()
            {
                Id = 1,
                TblRatingId = 1,
                Comments = "Bad Experience",
                CreatedBy = "Madhusmita",
                CreatedDateTime = DateTime.Now,
                UpdatedBy = "Madhusmita",
                UpdatedDateTime = DateTime.Now,
                TblRestaurantId = 1,
                TblUserId = 1
            };

            var options = new DbContextOptionsBuilder<ReviewManagementContext>()
            .UseInMemoryDatabase(databaseName: "ReviewManagement")
            .Options;

            ReviewRepository repo = new ReviewRepository(new ReviewManagementContext(options));
            var review = repo.UpdateYourReview(reviewDetails);
            Assert.IsFalse(review);

        }

        [Test]
        public void Test_PostYourReview()
        {

            TblTableReview reviewDetails = new TblTableReview()
            {
                Id = 2,
                TblRatingId = 1,
                Comments = "Bad Experience",
                CreatedBy = "Madhusmita M",
                CreatedDateTime = DateTime.Now,
                UpdatedBy = null,
                UpdatedDateTime = DateTime.Now,
                TblRestaurantId = 1,
                TblUserId = 1
            };

            var options = new DbContextOptionsBuilder<ReviewManagementContext>()
            .UseInMemoryDatabase(databaseName: "ReviewManagement")
            .Options;

            ReviewRepository repo = new ReviewRepository(new ReviewManagementContext(options));
            var review = repo.PostYourReview(reviewDetails);
            Assert.IsTrue(review);

        }
    }
}
