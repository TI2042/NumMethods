using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidDescentMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите эпсилон:");
            string str = Console.ReadLine();
            double e = Convert.ToDouble(str, CultureInfo.InvariantCulture);
            Console.WriteLine();
            Console.Write("Введите х1:");
            double x1 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();
            Console.Write("Введите х2 :");
            double x2 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            CalculationsMethods calculations = new CalculationsMethods();
            calculations.Calculation(e, x1, x2, str.Length - 1);

            Console.ReadKey();
        }
    }
}
