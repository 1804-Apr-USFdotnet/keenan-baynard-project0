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
            //for (int i=0;i<5;i++)
            //{
            //    SearchRestaurants.restaurants[i].PrintInfo();
            //    for (int j = 0; j < SearchRestaurants.restaurants[i].Reviews.Count-1 ; j++)
            //    {
            //        Console.WriteLine(SearchRestaurants.restaurants[i].Reviews[j].GetFormattedReview());
            //    }
            //    Console.WriteLine("------------------------------------------------------------------------------------------------------");
            //}
            Console.WriteLine("What would you like to do?: ");
            Console.WriteLine("Type help for What you can do");
            Console.WriteLine("Type find to find restaurant");
            Console.WriteLine("Type exit to exit");
            Console.WriteLine();
            while (true)
            {
                string option = Console.ReadLine();
                switch (option)
                {
                    case "find":
                        Console.Write("Search for restaurant by full or parital name: ");
                        string Search = Console.ReadLine();
                        SearchRestaurants.ReturnGetRestaurantFullName(Search);
                        Console.WriteLine();
                        Console.WriteLine("select (restaurant name)");
                        Console.WriteLine("back");
                        option = Console.ReadLine();
                        if (option.Length > "select".Length)
                        {
                            if (option.Substring(0, 6).Equals("select"))
                            {
                                //select method
                            }
                        }
                        else if (option=="back")
                        {
                            goto case "find";
                        }
                        else
                        {
                            Console.WriteLine("Please select valid option");
                            Console.WriteLine();
                        }

                        break;
                    case "help":
                        Console.WriteLine("Type find to find restaurant");
                        Console.WriteLine("Type exit to exit");
                        Console.WriteLine();
                        break;
                    case "exit":
                        return;
                    case "select":
                        Console.WriteLine();
                        Console.WriteLine("Select restuarant");
                        break;







                    default:
                        Console.WriteLine("Please select valid option");
                        break;
                }
            }
        }
    }
}
