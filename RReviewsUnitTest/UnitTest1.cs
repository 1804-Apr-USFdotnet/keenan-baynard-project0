using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantModels;
using RReviews.BLL;
using RReviews.DAL;

namespace RReviewsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Restaurant restaurant = new Restaurant("Fogo De Chao", "Minneapolis", "Minnesota");
        Restaurant restaurant2 = new Restaurant("Wendys", "Templs Terrace", "Florida");
        Restaurant restaurant3 = new Restaurant("Chipotle", "St. Paul", "Minnesota");
        Restaurant restaurant4 = new Restaurant("Ritas", "Lancaster", "Pennsylvania");
        Restaurant Restaurant5 = new Restaurant("Qdoba", "Templ Terrace", "Florida");

        [TestMethod]
        public void GetRestaurantLocationUnitTest()
        {
            //arrange
            string expected = "Minneapolis, Minnesota";

            //act
            var actual = restaurant.GetLocation();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetResaurantAvgReviewUnitTest()
        {
            //arrange
            restaurant.AddReview(new Review
            {
                ResturuantName = "Fogo De Chao",
                ReviewComment = "good service, good food. Was very  happy with how the place looked and very clean",
                ReviewRating = 4.5,
                ReviewerName="Keenan Baynard"
                
            });
            restaurant.AddReview(new Review
            {
                ResturuantName = "Fogo De Chao",
                ReviewComment = "terrible, food was aweful, service was slow, and my table was not cleaned",
                ReviewRating = 0.5,
                ReviewerName = "Joe Johnson"

            });
            double expected = 2.5;

            //act
            var actual = restaurant.GetAvgReview();

            //assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void GetBestReviewedRestaurantsTop3UnitTest()
        {
            //AddReview()
            //GetBestReviewedRestaurantsTop3()
        }
        [TestMethod]
        public void GetResturantFullNameUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetResturantsByNameAscendingUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetResturantsByNameDescendingUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetRestaurantsByLocationCityAscendingUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetRestaurantsByLocationCityDescendingUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetAllRestaurantsByReviewAscendingUnitTest()
        {
            //Method in BLL
        }
    }
}
