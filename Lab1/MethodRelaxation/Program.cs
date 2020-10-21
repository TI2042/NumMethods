using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodRelaxation
{
    class Program
    {
        public static decimal[,] system = { { 3.2410m, 0.1970m, 0.6430m, 0.2360m, 0.4540m},
                                    {0.2570m, 3.8530m, 0.3420m, 0.4270m, 0.3710m},
                                    { 0.3240m, 0.3170m, 2.7930m, 0.2380m, 0.4650m},
                                    { 0.4380m, 0.3260m, 0.4830m, 4.2290m, 0.8220m}};

        public static decimal[,] nevyzki = new decimal [4,4];
        public static decimal[,] decisionVector = new decimal[15,4];
        public static decimal[,] iterationNevyzki = new decimal[15, 4];
        public static decimal epsilon; 
        public static double accuracy;
        static void Main(string[] args)
        {
            Console.Write("Введите точность вычислений:");
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
            Console.WriteLine("Эпcилон равен :"+epsilon+"\n" +
                "Точность вычислений равна "+ (accuracy) + " знакам после запятой");

            
            Console.WriteLine("Преобразование системы \n" +
                "матрица А \t\t   вектор B");
            CalculationsMethods calculations = new CalculationsMethods();
            calculations.SystemAdaptation(system);
            calculations.PrintSystem(system);
            Console.WriteLine("Невязки ");
            calculations.Nevyazki(system, nevyzki);
            calculations.PrintSystem(nevyzki);
            Console.WriteLine(" \n" );
            calculations.Iteration(nevyzki, decisionVector, iterationNevyzki, accuracy ,  epsilon);

            
            Console.ReadKey();
        }
    }
}
