using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidDescentMethod
{
    public class CalculationsMethods
    {
        public void Calculation(double e, double x1, double x2, int kolznak)
        {
            int it = 0;
            double alpha = 0.1;
            double[] mass1 = { x1, x2, 2 * getFunction1(x1, x2) * getDerivativeFunc1_x1(x1, x2) + 2 * getFunction_2(x1, x2) * getDerivativeFunc2_x1(x1), 2 * getFunction1(x1, x2) * getDerivativeFunc1_x2(x1, x2) + 2 * getFunction_2(x1, x2) * getDerivativeFunc2_x2(x2), 0 };
            string[] table = { "N","X1", "X2", "Ф'1","Ф'2","Норма"};
            Console.Write($"{ table[0]}  ");
            for (int i = 1; i < table.Length; i++)
            {
                Console.Write($"{table[i], 10}  ");
                
            }
            Console.WriteLine();
            Console.Write($"{it}");
            for (int i = 0; i < mass1.Length; i++)
            {
                Console.Write($"{ "|"+Math.Round(mass1[i], kolznak),10}  ");
            }
            it++;
            Console.WriteLine();
            double[] mass2 = new double[5];
            while (true)
            {
                mass2[0] = mass1[0] - alpha * mass1[2];
                mass2[1] = mass1[1] - alpha * mass1[3];
                mass2[2] = 2 * getFunction1(mass2[0], mass2[1]) * getDerivativeFunc1_x1(mass2[0], mass2[1]) + 2 * getFunction_2(mass2[0], mass2[1]) * getDerivativeFunc2_x1(mass2[0]);
                mass2[3] = 2 * getFunction1(mass2[0], mass2[1]) * getDerivativeFunc1_x2(mass2[0], mass2[1]) + 2 * getFunction_2(mass2[0], mass2[1]) * getDerivativeFunc2_x2(mass2[1]);
                mass2[4] = Math.Max(Math.Abs(mass2[0] - mass1[0]), Math.Abs(mass2[1] - mass1[1]));
                Console.Write($"{it}");
                for (int i = 0; i < mass2.Length; i++)
                {
                    Console.Write($"{"|"+Math.Round(mass2[i], kolznak ),10}  ");
                }
                Console.WriteLine();
                it++;
                if (mass2[4] < e)
                {
                    Console.WriteLine($"Ответ: x1= {Math.Round(mass2[0], kolznak)} x2= {Math.Round(mass2[1], kolznak)}");
                    return;
                }

                for (int i = 0; i < mass1.Length; i++)
                {
                    mass1[i] = mass2[i];
                }
            }

        }

        public double getFunction1(double x1, double x2)
        {
            return Math.Tan(x1 * x2 + 0.1) - x1 * x1;
        }

        public double getFunction_2(double x1, double x2)
        {
            return x1 * x1 + 2 * x2 * x2 - 1;
        }

        public double getDerivativeFunc1_x1(double x1, double x2)
        {
            return (Math.Tan(x1 * x2 + 0.1) * Math.Tan(x1 * x2 + 0.1) + 1) * x2 - 2 * x1;
        }

        public double getDerivativeFunc1_x2(double x1, double x2)
        {
            return (Math.Tan(x1 * x2 + 0.1) * Math.Tan(x1 * x2 + 0.3) + 1) * x1;
        }

        public double getDerivativeFunc2_x1(double x1)
        {
            return 2 * x1;
        }

        public double getDerivativeFunc2_x2(double x2)
        {
            return 4 * x2;
        }
    }
}
