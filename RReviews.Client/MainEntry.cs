using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.BLL;
using RestaurantModels;

namespace RReviews.Client
{
    class MainEntry
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Application Runs");
            SearchRestaurants.restaurants = Ser.Deserialize();
            //for (int i=0;i<5;i++)
            //{
            //    SearchRestaurants.restaurants[i].PrintInfo();
            //    for (int j = 0; j < SearchRestaurants.restaurants[i].Reviews.Count-1 ; j++)
            //    {
            //        Console.WriteLine(SearchRestaurants.restaurants[i].Reviews[j].GetFormattedReview());
            //    }
            //    Console.WriteLine("------------------------------------------------------------------------------------------------------");
            //}

            Console.Write("Search for restaurant by full or parital name: ");
            string Search = Console.ReadLine();
            SearchRestaurants.ReturnGetRestaurantFullName(Search);
        }
    }
}
