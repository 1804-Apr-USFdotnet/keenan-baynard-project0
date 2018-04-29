using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RReviews.DAL
{
    public class RestaurantAccess
    {
        RReviewsEntities db = new RReviewsEntities();

        public IEnumerable<Restaurant> ShowRestaurants()
        {
            return null;
        }


        public void AddNewRestaurnt(RestaurantModels.Restaurant restaurant)
        {
            db.Restaurants.Add(LibraryToData(restaurant));
            db.SaveChanges();
        }


        public void AddNewReview(RestaurantModels.Review review)
        {
            db.Reviews.Add(LibraryToData(review));
            db.SaveChanges();
        }

        public RestaurantModels.Restaurant GetRestaurantByID(int id)
        {
            return DataToLibraryRestaurant(db.Restaurants.ToList().Find((x => x.ID.Equals(id))));
        }

        public IEnumerable<RestaurantModels.Review> GetReviewsByRestaurantID(int id)
        {
            var dataList = db.Reviews.ToList();
            var data2 = dataList.FindAll((x => x.RestaurantID.Equals(id)));
            return data2.Select((x => DataToLibraryReview(x)));
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
