using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string to check if it is a palindrome: ");
            string ToTest = Console.ReadLine();
            bool check = Pal.Check(ToTest);
            if (check)
            {
                Console.WriteLine("Yes, " + ToTest + " is a palindrome");
            }
            else
            {
                Console.WriteLine("No, " + ToTest + " is not a palindrome");
            }
        }
    }
}
