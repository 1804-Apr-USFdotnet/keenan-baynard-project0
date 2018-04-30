using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantModels;
using RReviews.BLL;

namespace RReviewsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Restaurant restaurant = new Restaurant("Fogo De Chao", "Minneapolis", "Minnesota");
        Restaurant restaurant2 = new Restaurant("Wendys", "Tampa", "Florida");
        Restaurant restaurant3 = new Restaurant("Chipotle", "St. Paul", "Minnesota");
        Restaurant restaurant4 = new Restaurant("Ritas", "Lancaster", "Pennsylvania");
        Restaurant restaurant5 = new Restaurant("Qdoba", "Temple Terrace", "Florida");


        public void init()
        {
            //adding reviews
            restaurant.AddReview(new Review
            {
                ReviewComment = "good service, good food. Was very  happy with how the place looked and very clean",
                ReviewRating = 4.5,
                ReviewerName = "Keenan Baynard"

            });
            restaurant.AddReview(new Review
            {
                ReviewComment = "terrible, food was aweful, service was slow, and my table was not cleaned",
                ReviewRating = 0.5,
                ReviewerName = "Joe Johnson"

            });
            restaurant2.AddReview(new Review
            {
                ReviewRating = 1,

            });
            restaurant3.AddReview(new Review
            {
                ReviewRating = 2,

            });
            restaurant4.AddReview(new Review
            {
                ReviewRating = 3,

            });
            restaurant5.AddReview(new Review
            {
                ReviewRating = 4,

            });

            //adding restautants to list
            SearchRestaurantsSer.restaurants.Add(restaurant);
            SearchRestaurantsSer.restaurants.Add(restaurant2);
            SearchRestaurantsSer.restaurants.Add(restaurant3);
            SearchRestaurantsSer.restaurants.Add(restaurant4);
            SearchRestaurantsSer.restaurants.Add(restaurant5);
        }
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
            init();
            double expected = 2.5;

            //act
            var actual = restaurant.GetAvgReview();

            //assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void GetBestReviewedRestaurantsTop3UnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant5,
                restaurant4,
                restaurant,
            };


            List<Restaurant> actual = SearchRestaurantsSer.GetBestReviewedRestaurantsTop3();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetResturantFullNameUnitTest()
        {
            //Method in BLL
        }
        [TestMethod]
        public void GetResturantsByNameAscendingUnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant3,
                restaurant,
                restaurant5,
                restaurant4,
                restaurant2
            };


            List<Restaurant> actual = SearchRestaurantsSer.GetRestaurantsByNameAscending();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetResturantsByNameDescendingUnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant2,
                restaurant4,
                restaurant5,
                restaurant,
                restaurant3
            };

            List<Restaurant> actual = SearchRestaurantsSer.GetRestaurantsByNameDescending();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetRestaurantsByLocationCityAscendingUnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant4,
                restaurant,
                restaurant3,
                restaurant2,
                restaurant5
            };

            List<Restaurant> actual = SearchRestaurantsSer.GetRestaurantsByLocationCityAscending();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetRestaurantsByLocationCityDescendingUnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant5,
                restaurant2,
                restaurant4,
                restaurant,
                restaurant4
            };

        }
        [TestMethod]
        public void GetAllRestaurantsByReviewAscendingUnitTest()
        {
            init();
            List<Restaurant> expected = new List<Restaurant>
            {
                restaurant5,
                restaurant4,
                restaurant,
                restaurant3,
                restaurant2
            };


            List<Restaurant> actual = SearchRestaurantsSer.GetAllRestaurantsByReviewDescending();

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void jsonSerializeUnitTest()
        {

        }
        [TestMethod]
        public void jsonDeserializeUnitTest()
        {

        }
    }
}
