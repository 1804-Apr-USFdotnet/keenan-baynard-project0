using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantModels;

namespace RReviews.BLL
{
    public static class Ser
    {
        public static void Serialize()
        {
            string textJson = JsonConvert.SerializeObject(SearchRestaurants.restaurants);
            System.IO.File.WriteAllText(@"D:\Users\ksbay\Documents\Revature\keenan-baynard-project0\MockData.txt",textJson);
        }
        public static List<Restaurant> Deserialize()
        {
            string textJson = System.IO.File.ReadAllText(@"D:\Users\ksbay\Documents\Revature\keenan-baynard-project0\MockData.txt");
            var objects = JsonConvert.DeserializeObject<List<Restaurant>>(textJson);
            return objects;
        }
    }
}
