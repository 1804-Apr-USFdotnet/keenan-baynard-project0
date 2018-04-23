using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge1
{
    public static class Pal
    {
        public static bool Check(string p)
        {
            int length;
            p = p.Replace(" ", string.Empty);
            p = p.Replace(",", string.Empty);
            length = p.Length;
            bool test = false;
            for (int i = 0; i < length / 2; i++)
            {
                if (p[i] == p[length - 1 - i])
                {
                    test = true;
                }
                else
                {
                    return false;
                }
            }
            return test;
        }
    }
}
