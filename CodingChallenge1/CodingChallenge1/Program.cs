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
            Console.Write("Enter string to check if is palindrome: ");
            string ToTest = Console.ReadLine();
            Console.WriteLine(Pal.Check(ToTest));
        }
    }
}
