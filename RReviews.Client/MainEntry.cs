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


            Start:
            Console.WriteLine();
            Console.WriteLine("What would you like to do?: ");
            Console.WriteLine("Type 'find' to find restaurant");
            Console.WriteLine("Type 'top' to list top 3 best reviewed restauratns");
            Console.WriteLine("Type 'all review' to list all resturants in order of rating");
            Console.WriteLine("Type 'all city asc' to list all restauratns in order of city ascending");
            Console.WriteLine("Type 'all city desc' to list all restauratns in order of city descending");
            Console.WriteLine("Type 'all name asc' to list all restauratns in order of name ascending");
            Console.WriteLine("Type 'all name desc' to list all restauratns in order of name descending");
            Console.WriteLine("Type 'exit' to exit");
            Console.WriteLine();
            while (true)
            {
                List<Restaurant> top;
                string option = Console.ReadLine();
                switch (option)
                {
                    case "find":
                        Console.WriteLine();
                        Running.Find();
                        break;
                    case "exit":
                        Running.Exit();
                        break;
                    case "top":
                        Console.WriteLine();
                        top = SearchRestaurants.GetBestReviewedRestaurantsTop3();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;
                    case "all review":
                        Console.WriteLine();
                        top = SearchRestaurants.GetAllRestaurantsByReviewDescending();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;
                    case "all name asc":
                        Console.WriteLine();
                        top = SearchRestaurants.GetRestaurantsByNameAscending();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;
                    case "all name desc":
                        Console.WriteLine();
                        top = SearchRestaurants.GetRestaurantsByNameDescending();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;
                    case "all city asc":
                        Console.WriteLine();
                        top = SearchRestaurants.GetRestaurantsByLocationCityAscending();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant location: " + item.GetLocation() + ", Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;
                    case "all city desc":
                        Console.WriteLine();
                        top = SearchRestaurants.GetRestaurantsByLocationCityDescending();
                        foreach (var item in top)
                        {
                            Console.WriteLine("Restaurant location: " + item.GetLocation() + ", Restaurant Name: " + item.Name + ", Rating: " + item.GetAvgReview());
                        }
                        goto Start;

                    default:
                        Console.WriteLine("Enter Valid Option");
                        Console.WriteLine();
                        goto Start;
                }
            }
        }
    }
    static class Running
    {
        internal static void Find()
        {
            string option;
            Console.Write("Search for restaurant by full or parital name: ");
            string Search = Console.ReadLine();
            SearchRestaurants.ReturnGetRestaurantFullName(Search);
            if (SearchRestaurants.GetRestaurantFullName(Search).Item1==null)
            {
                Console.WriteLine();
                Console.WriteLine("Make sure search is a name, or try shortening the search");
                Find();
            }
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

        internal static void Select(string selected)
        {
            Console.WriteLine("Selected: " + selected);
            Restaurant restaurant = SearchRestaurants.restaurants.Find((x => x.Name.Equals(selected, StringComparison.InvariantCultureIgnoreCase)));
            if (restaurant == null)
            {

                Console.WriteLine();
                Console.WriteLine("Please enter correct restaurant name");
                Find();
            }
            else
            {
                AddReview(restaurant);
            }
        }
        internal static void AddReview(Restaurant restaurant)
        {
            while (true)
            {
                //check if entry is a valid restaurant name
                Console.WriteLine();
                Console.WriteLine("Type 'add' to add review to restaurant");
                Console.WriteLine("Type 'get' to see all reviews for restaurant");
                Console.WriteLine("Type 'avg' to get average review");
                Console.WriteLine("Type 'info' for restaurant info");
                Console.WriteLine("Type 'back' to go back");
                Console.WriteLine("Type 'exit' to exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "add":
                        restaurant.AddReview(Restaurant.CreateReview());
                        break;
                    case "back":
                        Find();
                        break;
                    case "get":
                        foreach (var item in restaurant.Reviews)
                        {
                            Console.WriteLine(item.GetFormattedReview());
                        }
                        break;
                    case "avg":
                        Console.WriteLine();
                        Console.WriteLine("Average Review Rating: " + restaurant.GetAvgReview());
                        break;
                    case "info":
                        Console.WriteLine();
                        restaurant.PrintInfo();
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
            Ser.Serialize(SearchRestaurants.restaurants);
            Environment.Exit(0);
        }
    }
}

