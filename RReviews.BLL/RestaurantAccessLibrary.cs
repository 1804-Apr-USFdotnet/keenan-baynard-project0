using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.DAL;

namespace RReviews.BLL
{
    public class RestaurantAccessLibrary
    {
        public static void ReturnGetRestaurantFullName(string PartialName)
        {
            Tuple<IEnumerable<RestaurantModels.Restaurant>, string> result = GetRestaurantFullName(PartialName);
            if (result.Item1 != null)
            {
                foreach (var item in result.Item1)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Item2);
            }
        }

        public static Tuple<IEnumerable<RestaurantModels.Restaurant>, string> GetRestaurantFullName(string PartialName)
        {
            return RestaurantAccessData.GetRestaurantFullName(PartialName);
        }

        public static IEnumerable<Restaurant> ShowRestaurants()
        {
            return RestaurantAccessData.ShowRestaurants();
        }

        public static void AddNewRestaurnt(RestaurantModels.Restaurant restaurant)
        {
            RestaurantAccessData.AddNewRestaurnt(restaurant);
        }

        public static void AddNewReview(RestaurantModels.Review review)
        {
            RestaurantAccessData.AddNewReview(review);
        }

        public static RestaurantModels.Restaurant GetRestaurantByID(int ID)
        {
            return RestaurantAccessData.GetRestaurantByID(ID);
        }

        public static RestaurantModels.Restaurant GetRestaurantByName(string name)
        {
            return RestaurantAccessData.GetRestaurantByName(name);
        }

        public static IEnumerable<RestaurantModels.Review> GetReviewsByRestaurantID(int id)
        {
            return RestaurantAccessData.GetReviewsByRestaurantID(id);
        }

        public static double GetAvgReview(RestaurantModels.Restaurant restaurant)
        {
            return RestaurantAccessData.GetAvgReview(restaurant);
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByNameAscending()
        {
            return RestaurantAccessData.GetRestaurantsByNameAscending();
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByNameDescending()
        {
            return RestaurantAccessData.GetRestaurantsByNameDescending();
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByLocationCityAscending()
        {
            return RestaurantAccessData.GetRestaurantsByLocationCityAscending();
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByLocationCityDescending()
        {
            return RestaurantAccessData.GetRestaurantsByLocationCityDescending();
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetAllRestaurantsByReviewDescending()
        {
            return RestaurantAccessData.GetAllRestaurantsByReviewDescending();
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetBestReviewedRestaurantsTop3()
        {
            return RestaurantAccessData.GetBestReviewedRestaurantsTop3();
        }

    }
}
