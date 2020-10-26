using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MethodRelaxation
{
    public class CalculationsMethods
    {
        private int k = 1;
        private int colomnX = 0;
        public void SystemAdaptation(decimal[,] system)
        {

            for (int i = 0; i < system.GetUpperBound(0) + 1; i++)
            {
                decimal temp = system[i, i];
                for (int j = 0; j < system.GetUpperBound(1) + 1; j++)
                {
                    system[i, j] = Math.Round(system[i, j] / temp, 4);
                }
            }
        }

        public void PrintSystem(decimal[,] system)
        {
            for (int i = 0; i < system.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < system.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($"{system[i, j] + "|",7}");

                }
                Console.Write("\n");
            }
        }

        public void Nevyazki(decimal[,] system, decimal[,] nevyazki)
        {
            List<decimal> temp = new List<decimal>();
            for (int i = 0; i < system.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < system.GetUpperBound(1) + 1; j++)
                {
                    if (system[i, j] != 1)
                    {
                        temp.Add(system[i, j]);
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    if (temp.First() == system[i, 4])
                    {
                        nevyazki[i, 0] = temp.First();
                        temp.Remove(temp.First());

                    }
                    else
                    {
                        nevyazki[i, j] = -temp.First();
                        temp.Remove(temp.First());
                    }
                }
            }
        }
        private void IncrementR(int k, decimal[,] decisionVector, decimal increment)
        {

            for (int i = 0; i < 4; i++)
            {
                if (i == colomnX)
                {
                    if (decisionVector[k - 1, i] == 0)
                    {
                        decisionVector[k, i] = increment;
                    }
                    else
                    {
                        decisionVector[k, i] = decisionVector[k - 1, i] + increment;
                    }
                }
                else
                {
                    decisionVector[k, i] = decisionVector[k - 1, i];
                }
            }
        }
        private void NewIterNevyazki(decimal[,] nevyazki, decimal[,] decisionVector, decimal[,] iterationNevyzki, double accuracy)
        {
            iterationNevyzki[k - 1, 0] = Math.Round(nevyazki[0, 0] - decisionVector[k - 1, 0] + nevyazki[0, 1] * decisionVector[k - 1, 1] + nevyazki[0, 2] * decisionVector[k - 1, 2] + nevyazki[0, 3] * decisionVector[k - 1, 3], (int)accuracy);
            iterationNevyzki[k - 1, 1] = Math.Round(nevyazki[1, 0] - decisionVector[k - 1, 1] + nevyazki[1, 1] * decisionVector[k - 1, 0] + nevyazki[1, 2] * decisionVector[k - 1, 2] + nevyazki[1, 3] * decisionVector[k - 1, 3], (int)accuracy);
            iterationNevyzki[k - 1, 2] = Math.Round(nevyazki[2, 0] - decisionVector[k - 1, 2] + nevyazki[2, 1] * decisionVector[k - 1, 0] + nevyazki[2, 2] * decisionVector[k - 1, 1] + nevyazki[2, 3] * decisionVector[k - 1, 3], (int)accuracy);
            iterationNevyzki[k - 1, 3] = Math.Round(nevyazki[3, 0] - decisionVector[k - 1, 3] + nevyazki[3, 1] * decisionVector[k - 1, 0] + nevyazki[3, 2] * decisionVector[k - 1, 1] + nevyazki[3, 3] * decisionVector[k - 1, 2], (int)accuracy);

        }
        public bool StopIteration(decimal epsilon, int k, decimal[,] iterationNevyzki)
        {

            if ((Math.Abs(iterationNevyzki[k - 1, 0]) < epsilon) && (Math.Abs(iterationNevyzki[k - 1, 1]) < epsilon) && (Math.Abs(iterationNevyzki[k - 1, 2]) < epsilon) && (Math.Abs(iterationNevyzki[k - 1, 3]) < epsilon))
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        public decimal incremet(decimal[,] iterationNevyzki, int k)
        {
            decimal max = 0;
            for (int i = 0; i < 4; i++)
            {

                if (Math.Abs(iterationNevyzki[k - 1, i]) > Math.Abs(max))
                {
                    max = iterationNevyzki[k - 1, i];
                    colomnX = i;
                }
            }
            return max;
        }
        public void Iteration(decimal[,] nevyazki, decimal[,] decisionVector, decimal[,] iterationNevyzki, double accuracy, decimal epsilon)
        {

            for (int i = 0; i < decisionVector.GetUpperBound(1) + 1; i++)
            {
                decisionVector[0, i] = 0;
            }

            for (int i = 1; i < 300; i++)
            {

                NewIterNevyazki(nevyazki, decisionVector, iterationNevyzki, accuracy);
                IncrementR(i, decisionVector, incremet(iterationNevyzki, i));
                colomnX = 0;
                if (StopIteration(epsilon, k, iterationNevyzki) == true)
                {
                    Finish(decisionVector, iterationNevyzki);
                    return;
                }
                k++;
            }
            

        }

        public void Finish(decimal[,] decisionVector, decimal[,] iterationNevyzki)
        {
            Console.WriteLine("Итерации");
            Console.WriteLine("  K\tВектора решений \t\t   Невязки");
            for (int i = 0; i < k+1; i++)
            {
                Console.Write($"{i + 1 + "|",4}");
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{decisionVector[i, j] + "|",10}");
                }
                for (int j = 0; j < 4; j++)
                {
                        Console.Write($"{ iterationNevyzki[i, j] + "|",10}");
                }
                Console.Write("\n");
            }

            Console.WriteLine($"Вектор решений: {{{decisionVector[k - 1, 0]+";"+ decisionVector[k - 1, 1] + ";" + decisionVector[k - 1, 2] + ";" + decisionVector[k - 1, 3] }}}") ;

        }
    }
}
