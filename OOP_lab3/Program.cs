using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    public interface IProgression
    {
        int NthTerm(int a1, int d, int n);
        int Sum(int a1, int d, int n);
    }

    public class ArithmeticProgression : IProgression
    {
        public int NthTerm(int a1, int d, int n)
        {
            return a1 + (n - 1) * d;
        }

        public int Sum(int a1, int d, int n)
        {
            return (2 * a1 + (n - 1) * d) * n / 2;
        }
    }

    public class GeometricProgression : IProgression
    {
        public int NthTerm(int a1, int r, int n)
        {
            return a1 * (int)Math.Pow(r, n - 1);
        }

        public int Sum(int a1, int r, int n)
        {
            if (r == 1)
            {
                return a1 * n;
            }
            else
            {
                return a1 * ((int)Math.Pow(r, n) - 1) / (r - 1);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IProgression arithmetic = new ArithmeticProgression();
            Console.WriteLine("Арифметична прогресiя:");
            Console.WriteLine("Введіть перший член,різницю та n-член прогресії");
            int a1 =int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(n+"th term: " + arithmetic.NthTerm(a1, d, n));
            Console.WriteLine("Sum of first "+n+" terms: " + arithmetic.Sum(a1, d, n));

            IProgression geometric = new GeometricProgression();
            Console.WriteLine("\nГеометрична прогресiя:");
            Console.WriteLine(n + "th term: " + geometric.NthTerm(a1, d, n));
            Console.WriteLine("Sum of first " + n + " terms: " + geometric.Sum(a1, d, n));

            Console.ReadKey();
        }
    }
}
