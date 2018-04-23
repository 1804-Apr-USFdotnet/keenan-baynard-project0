using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels;

namespace RReviews.BLL
{
    public static class SearchRestaurants
    {
        public static List<Restaurant> restaurants = new List<Restaurant>();
        public static string GetResturantFullName(string PartialName)
        {
            if (PartialName != null && PartialName != "")
            {

                int PartialLength = PartialName.Length;
                foreach (Restaurant restaurant in restaurants)
                {
                    if (restaurant.Name.Substring(0, PartialLength).Equals(PartialName))
                    {
                        return restaurant.Name;
                    }
                }
                return "Could not find Restaurant matching " + PartialName;
            }
            else
            {
                return "Didnt not Enter a valid name";
            }
        }

        public static List<Restaurant> GetResturantsByNameAscending()
        {
            var sortedAsc = restaurants.OrderBy(x => x.Name).ToList();
            return sortedAsc;
        }

        public static List<Restaurant> GetResturantsByNameDescending()
        {
            var sortedDesc = restaurants.OrderByDescending(x => x.Name).ToList();
            return sortedDesc;

        }

        public static List<Restaurant> GetRestaurantsByLocationCityAscending()
        {
            return null;
        }

        public static List<Restaurant> GetRestaurantsByLocationCityDescending()
        {
            return null;
        }

        public static List<Restaurant> GetAllRestaurantsByReviewAscending()
        {
            return null;
        }

        public static List<Restaurant> GetBestReviewedRestaurantsTop3()
        {
            return null;
        }
    }
}
