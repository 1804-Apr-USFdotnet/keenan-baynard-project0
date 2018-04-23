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
            Console.WriteLine("Application Runs");
            bool b1 = 1 < 0;
            bool b2 = !(12 % 3 > 2);
            if (b1 = b2)
                Console.Write("true: ");
            else
                Console.Write("false: ");
            Console.WriteLine("b1 is {0}.  b2 is {1}.", b1, b2);
        }
    }
}
