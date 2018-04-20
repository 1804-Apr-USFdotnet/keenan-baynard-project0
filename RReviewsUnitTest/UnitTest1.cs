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
        [TestMethod]
        public void GetRestaurantLocationUnitTest()
        {
            //arrange
            Restaurant restaurant = new Restaurant("Minneapolis", "Minnesota");
            string expected = "Minneapolis, Minnesota";

            //act
            var actual = restaurant.GetLocation();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetRestaurantDetailsUnitTest()
        {

        }
        [TestMethod]
        public void GetResaurantReviewsUnitTest()
        {

        }
        [TestMethod]
        public void GetResturantFullNameUnitTest()
        {

        }
        [TestMethod]
        public void GetResturantByNameAscending()
        {

        }
        [TestMethod]
        public void GetResturantByNameDescending()
        {

        }
        [TestMethod]
        public void GetRestaurantByLocationCityAscending()
        {

        }
        [TestMethod]
        public void GetRestaurantByLocationCityDescending()
        {

        }
        [TestMethod]
        public void GetAllRestaurantsByReviewAscending()
        {

        }
    }
}
