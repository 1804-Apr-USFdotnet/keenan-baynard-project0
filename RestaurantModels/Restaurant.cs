﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModels.Interfaces;

namespace RestaurantModels
{
    public class Restaurant : IRestaurant
    {
        public string City { get; private set; }
        public string State { get; private set; }
        public string Name { get; private set; }
        public List<Review> Reviews { get; private set; }
        public string FoodType { get; set; }
        public string OperationHours { get; private set; }
        

        public Restaurant(string name, string city, string state)
        {
            Reviews = new List<Review>();
            Name = name;
            City = city;
            State = state;
        }

        public string GetLocation()
        {
            return City + ", " + State;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public double GetAvgReview()
        {
            double result = Reviews.Sum(item => item.ReviewRating) / Reviews.Count;
            return result;
        }

        public void SetOperationHours(string sun, string mon, string tue, string wed, string thur, string fri, string sat)
        {
            OperationHours =
                "Sunday: " + sun +
                "\nMonday: " + mon +
                "\nTuesday: " + tue +
                "\nWednesday: " + wed +
                "\nThursday: " + thur +
                "\nFriday: " + fri +
                "\nSaturday: " + sat;
        }
    }
}
