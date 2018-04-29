using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.DAL;
using RReviews.BLL;
using RestaurantModels;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Ser.CreateList();
            RestaurantAccess access = new RestaurantAccess();

            var testlist = access.GetReviewsByRestaurantID(45);

            foreach (var item in testlist)
            {
                Console.WriteLine(item.RestaurantID + " || " + item.ReviewerName + " || " + item.ReviewRating + "\n" + item.ReviewComment);
            }
            
        }
    }
}
