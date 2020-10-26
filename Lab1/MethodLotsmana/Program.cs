using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodLotsmana
{
    class Program
    {
        public static decimal[,] system = { { 3.2410m, 0.1970m, 0.6430m, 0.2360m, 0.4540m},
                                    {0.2570m, 3.8530m, 0.3420m, 0.4270m, 0.3710m},
                                    { 0.3240m, 0.3170m, 2.7930m, 0.2380m, 0.4650m},
                                    { 0.4380m, 0.3260m, 0.4830m, 4.2290m, 0.8220m}};

        public static decimal[,] nevyzki = new decimal[4, 4];
        public static decimal[,] decisionVector = new decimal[300, 4];
        public static decimal[,] iterationNevyzki = new decimal[300, 4];
        public static decimal epsilon;
        public static double accuracy;
        public static decimal x0;
        static void Main(string[] args)
        {
            CalculationMethods calculations = new CalculationMethods();
            Console.Write("Введите Начально приближение:");
            string strX = Console.ReadLine();
            try
            {
                x0 = Convert.ToDecimal(strX);
            }
            catch
            {
                strX = strX.Replace(".", ",");
                x0 = Convert.ToDecimal(strX);
            }
            Console.Write("Введите Эпсилон:");
            string strE = Console.ReadLine();
            try
            {
                epsilon = Convert.ToDecimal(strE);
            }
            catch
            {
                strE = strE.Replace(".", ",");
                epsilon = Convert.ToDecimal(strE);
            }
            accuracy = Math.Abs(Math.Log10((double)epsilon)) + 1;
            Console.WriteLine("Начальное приближение:"+ x0+"\n"+" Эпcилон равен :" + epsilon + "\n" +
                "Точность вычислений равна " + (accuracy) + " знакам после запятой");
            
            calculations.Iteration(x0, accuracy, epsilon);
            Console.ReadKey();
        }

    }
}
