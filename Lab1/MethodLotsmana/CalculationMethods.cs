using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodLotsmana
{
    public class CalculationMethods
    {
        public decimal Function(decimal x, double accuracy)
        {
            decimal s = -0.5m * x * x;
            decimal function = x * (decimal)Math.Log((double)x) - (decimal)Math.Exp((double)s);
            return Math.Round(function, (int)accuracy);
        }
        public decimal FirstDerivative(decimal x, double accuracy)
        {
            decimal s = -0.5m * x * x;
            decimal derivative = Decimal.Add((decimal)Math.Log((double)x), decimal.Multiply(x, (decimal)Math.Exp((double)s))) + 1;
            return Math.Round(derivative, (int)accuracy);
        }

        public decimal SecondDerivative(decimal x, double accuracy)
        {
            decimal s = -0.5m * x * x;
            decimal derivative = 1 / x + (decimal)Math.Exp((double)s) + decimal.Multiply(decimal.Multiply(x, (decimal)Math.Exp((double)s)), -x);
            return Math.Round(derivative, (int)accuracy);
        }

        public decimal IterativeProcess(decimal x, double accuracy)
        {
            decimal newX = x - (2 * Function(x, accuracy) * FirstDerivative(x, accuracy)) / (2 * (decimal)Math.Pow((double)FirstDerivative(x, accuracy), 2) - Function(x, accuracy) * SecondDerivative(x, accuracy));
            return (decimal)Math.Round((double)newX, (int)accuracy);
        }

        public void Iteration(decimal x0, double accuracy, decimal epsilon)
        {
            decimal x = x0;
            int n = 1;
            decimal condition;
            decimal newX = IterativeProcess(x, accuracy);
            Console.WriteLine($"{" n|",3} {" X|",10} {" Xn+1|",10} {"|Xn-Xn-1||",10}");
            Console.WriteLine($"{n-1 + "|",3} {x + "|",10} {newX + "|",10} ");
            do
            {
                condition = Math.Abs(newX - x);
                x = newX;
                newX = IterativeProcess(x, accuracy);
                Console.WriteLine($"{n + "|",3} {x + "|",10} {newX + "|",10} {condition + "|",10}");
                n++;
            } while (Math.Abs(x - newX) >= epsilon);

            condition = Math.Abs(newX - x);
            x = newX;
            newX = IterativeProcess(x, accuracy);
            Console.WriteLine($"{n + "|",3} {x + "|",10} {newX + "|",10} {condition + "|",10}");
        }
    }
}
