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
        static Tuple<List<Restaurant>, string> GetRestaurantFullName(string PartialName)
        {
            if (PartialName != null && PartialName != "")
            {
                int PartialLength = PartialName.Length;
                List<Restaurant> found;
                try
                {
                    found = restaurants.FindAll((x => x.Name.Substring(0, PartialLength).Equals(PartialName, StringComparison.InvariantCultureIgnoreCase)));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    //log exception
                    found = new List<Restaurant>();
                }

                if (found.Count > 0)
                {
                    return new Tuple<List<Restaurant>, string>(found, "");
                }
                return new Tuple<List<Restaurant>, string>(null, "Could not find Restaurant matching " + PartialName);
            }
            else
            {
                return new Tuple<List<Restaurant>, string>(null, "Didnt not Enter a valid name");
            }
        }

        public static void ReturnGetRestaurantFullName(string PartialName)
        {
            List<Restaurant> result = GetRestaurantFullName(PartialName).Item1;
            string resultString = GetRestaurantFullName(PartialName).Item2;
            if (restaurants != null)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine(resultString);
            }
        }

        public static List<Restaurant> GetResturantsByNameAscending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderBy(x => x.Name).ToList();
                return sortedAsc;
            }
            else
            {
                //empty or null list
                return restaurants = new List<Restaurant>
                {
                    //check when calling SearchRestaurants for empty strings, is they appear there is an error
                    new Restaurant("","","")
                };
            }
        }

        public static List<Restaurant> GetResturantsByNameDescending()
        {
            var sortedDesc = restaurants.OrderByDescending(x => x.Name).ToList();
            return sortedDesc;

        }

        public static List<Restaurant> GetRestaurantsByLocationCityAscending()
        {
            var sortedAsc = restaurants.OrderBy(x => x.City).ToList();
            return sortedAsc;
        }

        public static List<Restaurant> GetRestaurantsByLocationCityDescending()
        {
            var sortedDesc = restaurants.OrderByDescending(x => x.City).ToList();
            return sortedDesc;
        }

        public static List<Restaurant> GetAllRestaurantsByReviewAscending()
        {
            var sortedAsc = restaurants.OrderBy(x => x.GetAvgReview()).ToList();
            return sortedAsc;
        }

        public static List<Restaurant> GetBestReviewedRestaurantsTop3()
        {
            var sorted = GetAllRestaurantsByReviewAscending();
            return sorted.GetRange(0, 3);
        }
    }
}
