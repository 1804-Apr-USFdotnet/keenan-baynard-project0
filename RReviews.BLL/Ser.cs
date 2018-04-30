using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantModels;

namespace RReviews.BLL
{
    public static class Ser
    {
        //separate getting string and derserializing
        public static void Serialize(object obj)
        {
            string textJson = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["jsonPath"], textJson);
        }
        public static List<Restaurant> Deserialize(string json)
        {
            var objects = JsonConvert.DeserializeObject<List<Restaurant>>(json);
            return objects;
        }
        public static void CreateList()
        {
            SearchRestaurantsSer.restaurants = Deserialize(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["jsonPath"]));
        }
    }
}
