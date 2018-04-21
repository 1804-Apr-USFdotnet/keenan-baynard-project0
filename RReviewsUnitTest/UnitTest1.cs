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
        public void GetRestaurantDetailsUnitTest()
        {
            //ReviewComment()
        }
        [TestMethod]
        public void GetResaurantReviewsUnitTest()
        {
            //AddReview()
            //Reviews.get
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
