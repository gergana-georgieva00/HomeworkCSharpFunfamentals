using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            FindDataType(dataType);
        }

        static void FindDataType(string dataType)
        {
            int integer;
            double realNum;
            string someString;

            string output = "";

            switch (dataType)
            {
                case "int":
                    integer = int.Parse(Console.ReadLine());
                    integer *= 2;
                    output = integer.ToString();
                    break;
                case "real":
                    realNum = double.Parse(Console.ReadLine());
                    realNum *= 1.5;
                    output = string.Format($"{realNum:f2}");
                    break;
                default:
                    someString = Console.ReadLine();
                    output = string.Format($"${someString}$");
                    break;
            }

            Console.WriteLine(output);
        }
    }
}
