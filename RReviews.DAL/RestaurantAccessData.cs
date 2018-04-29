﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NLog;
using System.Data.Entity;

namespace RReviews.DAL
{
    public static class RestaurantAccessData
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private static RReviewsEntities db = new RReviewsEntities();


        public static IEnumerable<Restaurant> ShowRestaurants()
        {
            return db.Restaurants.ToList();
        }

        public static void AddNewRestaurnt(RestaurantModels.Restaurant restaurant)
        {
            db.Restaurants.Add(LibraryToData(restaurant));
            db.SaveChanges();
        }


        public static void AddNewReview(RestaurantModels.Review review)
        {
            db.Reviews.Add(LibraryToData(review));
            db.SaveChanges();
        }

        public static RestaurantModels.Restaurant GetRestaurantByID(int ID)
        {
            return DataToLibraryRestaurant(db.Restaurants.ToList().Find((x => x.ID.Equals(ID))));
        }

        public static RestaurantModels.Restaurant GetRestaurantByName(string name)
        {
            return DataToLibraryRestaurant(db.Restaurants.ToList().Find((x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))));
        }

        public static IEnumerable<RestaurantModels.Review> GetReviewsByRestaurantID(int id)
        {
            var dataList = db.Reviews.ToList();
            var data2 = dataList.FindAll((x => x.RestaurantID.Equals(id)));
            return data2.Select((x => DataToLibraryReview(x)));
        }

        public static double GetAvgReview(RestaurantModels.Restaurant restaurant)
        {
            var reviews = db.Reviews.ToList();
            var lreviews = reviews.FindAll((x => x.RestaurantID.Equals(restaurant.ID)));
            return Math.Round(lreviews.Select(x => x.ReviewerRating).Average(), 2);
        }

        public static Tuple<IEnumerable<RestaurantModels.Restaurant>, string> GetRestaurantFullName(string PartialName)
        {
            if (PartialName != null && PartialName != "")
            {
                int PartialLength = PartialName.Length;
                IEnumerable<RestaurantModels.Restaurant> found;
                try
                {
                    var dataList = db.Restaurants.ToList();
                    var data2 = dataList.FindAll((x => x.Name.Substring(0, PartialLength).Equals(PartialName, StringComparison.InvariantCultureIgnoreCase)));
                    found = data2.Select((x => DataToLibraryRestaurant(x)));
                }
                catch (ArgumentOutOfRangeException e)
                {
                    log.Error($"Entry ({PartialName}) does not exist, " + e.Message);
                    found = new List<RestaurantModels.Restaurant>();
                }

                if (found.Any())
                {
                    return new Tuple<IEnumerable<RestaurantModels.Restaurant>, string>(found, "");
                }
                return new Tuple<IEnumerable<RestaurantModels.Restaurant>, string>(null, "Could not find Restaurant matching " + PartialName);
            }
            //code is never reached, maybe write so reaches here if entry has numbers
            else
            {
                return new Tuple<IEnumerable<RestaurantModels.Restaurant>, string>(null, "Didnt not Enter a valid name");
            }
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByNameAscending()
        {
            if (db.Restaurants.Any())
            {
                var sortedAsc = db.Restaurants.OrderBy(x => x.Name).ToList();
                return sortedAsc.Select((x => DataToLibraryRestaurant(x)));
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByNameDescending()
        {
            if (db.Restaurants.Any())
            {
                var sortedAsc = db.Restaurants.OrderByDescending(x => x.Name).ToList();
                return sortedAsc.Select((x => DataToLibraryRestaurant(x)));
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByLocationCityAscending()
        {
            if (db.Restaurants.Any())
            {
                var sortedAsc = db.Restaurants.OrderBy(x => x.City).ToList();
                return sortedAsc.Select((x => DataToLibraryRestaurant(x)));
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static IEnumerable<RestaurantModels.Restaurant> GetRestaurantsByLocationCityDescending()
        {
            if (db.Restaurants.Any())
            {
                var sortedAsc = db.Restaurants.OrderByDescending(x => x.City).ToList();
                return sortedAsc.Select((x => DataToLibraryRestaurant(x)));
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<RestaurantModels.Restaurant>
                {
                    new RestaurantModels.Restaurant("","","")
                };
            }
        }

        public static IEnumerable<Restaurant> GetAllRestaurantsByReviewDescending()
        {
            if (db.Restaurants.Any())
            {
                var restaurants = db.Restaurants.ToList();
                return restaurants.OrderByDescending(x => x.getAvgReview());
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<Restaurant>
                {
                    new Restaurant()
                };
            }
        }

        public static IEnumerable<Restaurant> GetBestReviewedRestaurantsTop3()
        {
            if (db.Restaurants.Any())
            {
                var sorted = GetAllRestaurantsByReviewDescending();
                return sorted.ToList().GetRange(0, 3);
            }
            else
            {
                log.Error("DB does not contain any restaurants");
                return new List<Restaurant>
                {
                    new Restaurant()
                };
            }
        }



        #region Model Conversion
        public static Restaurant LibraryToData(RestaurantModels.Restaurant libModel)
        {
            var dataModel = new Restaurant()
            {
                ID = libModel.ID,
                Name = libModel.Name,
                City = libModel.City,
                State = libModel.State,
                FoodType = libModel.FoodType,
                OperationHours = libModel.OperationHours
            };
            return dataModel;
        }
        public static Review LibraryToData(RestaurantModels.Review libModel)
        {
            var dataModel = new Review()
            {
                ReviewerName = libModel.ReviewerName,
                ReviewerComment = libModel.ReviewComment,
                ReviewerRating = libModel.ReviewRating,
                RestaurantID = libModel.RestaurantID
            };
            return dataModel;
        }
        public static RestaurantModels.Restaurant DataToLibraryRestaurant(Restaurant dataModel)
        {
            var libModel = new RestaurantModels.Restaurant(dataModel.Name, dataModel.City, dataModel.State)
            {
                ID = dataModel.ID,
                FoodType = dataModel.FoodType,
                OperationHours = dataModel.OperationHours
            };
            return libModel;
        }
        public static RestaurantModels.Review DataToLibraryReview(Review dataModel)
        {
            var libModel = new RestaurantModels.Review()
            {
                ReviewRating = dataModel.ReviewerRating,
                ReviewComment = dataModel.ReviewerComment,
                ReviewerName = dataModel.ReviewerName,
                RestaurantID = dataModel.RestaurantID
            };
            return libModel;
        }
        #endregion
    }
}
