using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MT.OnlineRestaurant.BusinessEntities;
using MT.OnlineRestaurant.BusinessLayer;

namespace MT.OnlineRestaurant.ReviewManagementAPI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ReviewController : Controller
    {
        private readonly IReviewManagementLogic business_Repo;
        public ReviewController(IReviewManagementLogic _business_Repo)
        {
            business_Repo = _business_Repo;
        }
        [HttpGet]
        [Route("ReviewDetail")]
        public ReviewInformation GetReviewDetail([FromQuery] int ReviewID)
        {
            ReviewInformation reviewInformation = new ReviewInformation();
            reviewInformation = business_Repo.GetReviewDetails(ReviewID);
            return reviewInformation;
        }
        [HttpPut]
        [Route("UpdateReviewDetails")]
        public IActionResult UpdateReviewDetails([FromBody] ReviewInformation updatedReview)
        {
           
             var result = business_Repo.UpdateReviewDetails(updatedReview);

         
            if (!result)
            {
                return BadRequest("Failed to update Review, Please try again later");
            }
            return Ok("Review Updated successfully");
        }
    }
}
