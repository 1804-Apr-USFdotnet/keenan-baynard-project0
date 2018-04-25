﻿using System;
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
            Ser.CreateList();
            //for (int i = 0; i < 5; i++)
            //{
            //    SearchRestaurants.restaurants[i].PrintInfo();
            //    for (int j = 0; j < SearchRestaurants.restaurants[i].Reviews.Count - 1; j++)
            //    {
            //        Console.WriteLine(SearchRestaurants.restaurants[i].Reviews[j].GetFormattedReview());
            //    }
            //    Console.WriteLine("------------------------------------------------------------------------------------------------------");
            //}


                            //need to add displaying restaurants by rating



            Console.WriteLine("What would you like to do?: ");
            Console.WriteLine("Type 'help' for What you can do");
            Console.WriteLine("Type 'find' to find restaurant");
            Console.WriteLine("Type 'exit' to exit");
            Console.WriteLine();
            while (true)
            {
                string option = Console.ReadLine();
                switch (option)
                {
                    case "find":
                        Running.Find(option);
                        break;
                    case "help":
                        Running.Help();
                        break;
                    case "exit":
                        Running.Exit();
                        break;



                    default:
                        break;
                }
            }
        }
    }
    static class Running
    {
        internal static void Find(string option)
        {
            Console.Write("Search for restaurant by full or parital name: ");
            string Search = Console.ReadLine();
            SearchRestaurants.ReturnGetRestaurantFullName(Search);
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Type 'select' and then Restaurant name to select it ");
            Console.WriteLine("Type 'back' to go back");
            option = Console.ReadLine();
            if (option.Length > 6)
            {
                if (option.Substring(0, 6).Equals("select"))
                {
                    Select(option.Substring(7, option.Length - 7));
                }
            }
        }
        internal static void Help()
        {
            Console.WriteLine("Type 'help' for What you can do");
            Console.WriteLine("Type 'find' to find restaurant");
            Console.WriteLine("Type 'exit' to exit");
        }
        internal static void Select(string selected)
        {
            Console.WriteLine("Selected: " + selected);
            Restaurant restaurant = SearchRestaurants.restaurants.Find((x => x.Name.Equals(selected, StringComparison.InvariantCultureIgnoreCase)));
            AddReview(restaurant);
        }
        internal static void AddReview(Restaurant restaurant)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Type 'add' to add review to restaurant");
                Console.WriteLine("Type 'get' to see all reviews for restaurant");
                Console.WriteLine("Type 'back' to go back");
                Console.WriteLine("Type 'avg' to get average review");
                Console.WriteLine("Type 'exit' to exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "add":
                        restaurant.AddReview(Restaurant.CreateReview());
                        break;
                    case "back":
                        Find(option);
                        break;
                    case "get":
                        foreach (var item in restaurant.Reviews)
                        {
                            Console.WriteLine(item.GetFormattedReview());
                        }
                        break;
                    case "avg":
                        Console.WriteLine("Average Review Rating: " +restaurant.GetAvgReview());
                        break;
                    case "exit":
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Option");
                        break;
                }
            }
        }
        internal static void Exit()
        {
            Ser.Serialize();
            Environment.Exit(0);
        }
    }
}

