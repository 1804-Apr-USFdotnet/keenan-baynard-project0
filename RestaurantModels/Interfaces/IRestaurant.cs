using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantModels.Interfaces
{
    interface IRestaurant
    {
        string Name { get; }
        string City { get; }
        string State { get; }
        string FoodType { get; set; }
        string OperationHours { get; }
        List<Review> Reviews { get; set; }
        string GetLocation();
        void AddReview(Review review);
        double GetAvgReview(List<Review> reviews);
        void SetOperationHours(string sun, string mon, string tue, string wed, string thur, string friday, string sat);
    }
}
