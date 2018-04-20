using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels.Interfaces;

namespace RestaurantModels
{
    public class Restaurant : IRestaurant
    {
        public string City { get; set; }
        public string State { get; set; }
        public Restaurant(string city, string state)
        {
            City = city;
            State = state;
        }

        public string GetLocation()
        {
            //format location string
            return null;
        }
    }
}
