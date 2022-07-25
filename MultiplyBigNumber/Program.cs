using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string tempnum1 = num1;
            string num2 = Console.ReadLine();
            string tempnum2 = num2;

            // Check condition if one string is negative
            if (num1[0] == '-' && num2[0] != '-')
            {
                num1 = num1.Substring(1);
            }
            else
            {
                if (num1[0] != '-' && num2[0] == '-')
                {
                    num2 = num2.Substring(1);
                }
                else
                {
                    if (num1[0] == '-' && num2[0] == '-')
                    {
                        num1 = num1.Substring(1);
                        num2 = num2.Substring(1);
                    }
                }
            }

            string s1 = new string(num1.Reverse().ToArray());
            string s2 = new string(num2.Reverse().ToArray());

            int[] m = new int[s1.Length + s2.Length];

            // Go from right to left in num1
            for (int i = 0; i < s1.Length; i++)
            {
                // Go from right to left in num2
                for (int j = 0; j < s2.Length; j++)
                {
                    int x = int.Parse((s1[i] - '0').ToString());
                    int y = int.Parse((s2[j] - '0').ToString());
                    m[i + j] += (x * y);
                }
            }

            string product = "";
            // Multiply with current digit of first number
            // and add result to previously stored product
            // at current position.
            for (int i = 0; i < m.Length; i++)
            {
                int digit = m[i] % 10;
                int carry = m[i] / 10;
                if (i + 1 < m.Length)
                {
                    m[i + 1] += carry;
                }
                product = digit.ToString() + product;
            }

            // ignore '0's from the right
            while (product.Length > 1 && product[0] == '0')
            {
                product = product.Substring(1);
            }


            // Check condition if one string is negative
            if (tempnum1[0] == '-' && tempnum2[0] != '-')
            {
                product = new StringBuilder(product).Insert(0, '-').ToString();
            }
            else
            {
                if (tempnum1[0] != '-' && tempnum2[0] == '-')
                {
                    product = new StringBuilder(product).Insert(0, '-').ToString();
                }
            }
            Console.Write("Product of the two numbers is :\n" + product);
        }
    }
}
