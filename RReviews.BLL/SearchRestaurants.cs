using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels;
using NLog;

namespace RReviews.BLL
{
    public static class SearchRestaurants
    {
        private static Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static List<Restaurant> restaurants = new List<Restaurant>();
        public static Tuple<List<Restaurant>, string> GetRestaurantFullName(string PartialName)
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
                    log.Error($"Entry ({PartialName}) does not exist, " + e.Message);
                    found = new List<Restaurant>();
                }

                if (found.Count > 0)
                {
                    return new Tuple<List<Restaurant>, string>(found, "");
                }
                return new Tuple<List<Restaurant>, string>(null, "Could not find Restaurant matching " + PartialName);
            }
            //code is never reached, maybe write so reaches here if entry has numbers
            else
            {
                return new Tuple<List<Restaurant>, string>(null, "Didnt not Enter a valid name");
            }
        }

        public static void ReturnGetRestaurantFullName(string PartialName)
        {
            Tuple<List<Restaurant>, string> result = GetRestaurantFullName(PartialName);
            if (restaurants != null && result.Item1 != null)
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

        public static List<Restaurant> GetRestaurantsByNameAscending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderBy(x => x.Name).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }
        }

        public static List<Restaurant> GetRestaurantsByNameDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedDesc = restaurants.OrderByDescending(x => x.Name).ToList();
                return sortedDesc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }

        }

        public static List<Restaurant> GetRestaurantsByLocationCityAscending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderBy(x => x.City).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }
        }

        public static List<Restaurant> GetRestaurantsByLocationCityDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedDesc = restaurants.OrderByDescending(x => x.City).ToList();
                return sortedDesc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }
        }

        public static List<Restaurant> GetAllRestaurantsByReviewDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderByDescending(x => x.GetAvgReview()).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }
        }

        public static List<Restaurant> GetBestReviewedRestaurantsTop3()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sorted = GetAllRestaurantsByReviewDescending();
                return sorted.GetRange(0, 3);
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<Restaurant>
                {
                    new Restaurant("","","")
                };
            }
        }

        //public static Restaurant GetRestaurantByName(string name)
        //{
        //    return restaurants.Find((x => x.Name.Equals(name)));
        //}
    }
}
