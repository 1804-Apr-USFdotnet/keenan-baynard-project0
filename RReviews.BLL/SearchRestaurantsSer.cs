using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels;
using RReviews.DAL;
using NLog;

namespace RReviews.BLL
{
    public static class SearchRestaurantsSer
    {
        private static Logger log = NLog.LogManager.GetCurrentClassLogger();
        public static List<RestaurantModels.Restaurant> restaurants = new List<RestaurantModels.Restaurant>();
        public static Tuple<List<RestaurantModels.Restaurant>, string> GetRestaurantFullName(string PartialName)
        {
            if (PartialName != null && PartialName != "")
            {
                int PartialLength = PartialName.Length;
                List<RestaurantModels.Restaurant> found;
                try
                {
                    found = restaurants.FindAll((x => x.Name.Substring(0, PartialLength).Equals(PartialName, StringComparison.InvariantCultureIgnoreCase)));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    log.Error($"Entry ({PartialName}) does not exist, " + e.Message);
                    found = new List<RestaurantModels.Restaurant>();
                }

                if (found.Count > 0)
                {
                    return new Tuple<List<RestaurantModels.Restaurant>, string>(found, "");
                }
                return new Tuple<List<RestaurantModels.Restaurant>, string>(null, "Could not find Restaurant matching " + PartialName);
            }
            //code is never reached, maybe write so reaches here if entry has numbers
            else
            {
                return new Tuple<List<RestaurantModels.Restaurant>, string>(null, "Didnt not Enter a valid name");
            }
        }

        public static void ReturnGetRestaurantFullName(string PartialName)
        {
            Tuple<List<RestaurantModels.Restaurant>, string> result = GetRestaurantFullName(PartialName);
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

        public static List<RestaurantModels.Restaurant> GetRestaurantsByNameAscending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderBy(x => x.Name).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static List<RestaurantModels.Restaurant> GetRestaurantsByNameDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedDesc = restaurants.OrderByDescending(x => x.Name).ToList();
                return sortedDesc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }

        }

        public static List<RestaurantModels.Restaurant> GetRestaurantsByLocationCityAscending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderBy(x => x.City).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static List<RestaurantModels.Restaurant> GetRestaurantsByLocationCityDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedDesc = restaurants.OrderByDescending(x => x.City).ToList();
                return sortedDesc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static List<RestaurantModels.Restaurant> GetAllRestaurantsByReviewDescending()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sortedAsc = restaurants.OrderByDescending(x => x.GetAvgReview()).ToList();
                return sortedAsc;
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static List<RestaurantModels.Restaurant> GetBestReviewedRestaurantsTop3()
        {
            if (restaurants.Count > 0 && restaurants != null)
            {
                var sorted = GetAllRestaurantsByReviewDescending();
                return sorted.GetRange(0, 3);
            }
            else
            {
                log.Error("Restaurants list is either null or empty, searching will not work");
                return restaurants = new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        //public static Restaurant GetRestaurantByName(string name)
        //{
        //    return restaurants.Find((x => x.Name.Equals(name)));
        //}
    }
}
