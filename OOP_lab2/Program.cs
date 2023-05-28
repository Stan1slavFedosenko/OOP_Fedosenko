using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2
{
    internal class Program
    {
        static double[] Initmass_1(int n)
        {
            double[] mass = new double[n];
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Заповнити вручну(1) чи автоматично(2): ");
                string temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.WriteLine("Введіть элементи матриці:");
                    for (int i = 0; i < n; i++)
                    {
                        string[] row = Console.ReadLine().Split();
                        mass[i] = int.Parse(row[i]);

                    }
                    break;
                }
                else if (temp == "2")
                {
                   

                    for (int i = 0; i < n; i++)
                    {
                       
                        mass[i] = random.Next(-100, 100);
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Неправильний ввід");

                }
                
            }
            for (int i = 0; i < n; i++)
            {

                Console.Write(mass[i]+" "); 

            }
            return mass;
        }
        static double[,] Initmass_2(int rows, int cols)
        {
            double[,] mass= new double[rows, cols];
            Random random = new Random();
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Заповнити вручну(1) чи автоматично(2): ");
                string temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.WriteLine("Введіть элементи матриці:");
                    for (int i = 0; i < rows; i++)
                    {
                        string[] row = Console.ReadLine().Split();
                        for (int j = 0; j < cols; j++)
                        {
                            mass[i, j] = int.Parse(row[j]);
                        }
                    }
                    break;
                }
                else if (temp == "2")
                {
                   

                    for (int i = 0; i < rows; i++)
                    {
                       

                        for (int j = 0; j < cols; j++)
                        {
                            mass[i, j] = random.Next(-100, 100); ;
                        }
                    }
                    break;
                }
                else
                {
                    Console.Write("Неправильний ввід");

                }

            }
            for (int i = 0; i < rows; i++)
            {


                for (int j = 0; j < cols; j++)
                {
                  Console.Write(mass[i, j]+" ");
                }
                Console.WriteLine();
            }
            return mass;
        }
        static void Main(string[] args)
        {
       
            //1.1
            {
                Console.WriteLine("//1.1");
                Console.WriteLine("Введіть довжину масива");
                int n = int.Parse(Console.ReadLine());
                double[] arr = Initmass_1(n);
                double sum = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < 0)
                    {
                        break;
                    }
                    sum += arr[i];
                }

                Console.WriteLine("Сума елементів до першого від'ємного:" + sum);
            }

            //1.2
            {
                Console.WriteLine("//1.2");
                Console.WriteLine("Введіть довжину масивів");
                int n = int.Parse(Console.ReadLine());

                // ініціалізація масивів a, b, c
                double[] a = Initmass_1(n);
                double[] b =Initmass_1( n);
                double[] c = new double[n];

                // знаходження вектора c
                for (int i = 0; i < n; i++)
                {
                    c[i] = 2 * (a[i] + c[i]) - 3 * (a[i] - b[i]);
                }

                // виведення результату
                Console.Write("Вектор c: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("{0} ", c[i]);
                }
            }

            //1.3
            {
                Console.WriteLine("//1.3");
                Console.WriteLine("Введіть довжину масиву");
                int n = int.Parse(Console.ReadLine());

                // ініціалізація масиву
                double[] a = Initmass_1(n);

                // сортування елементів за спаданням модулів
                Array.Sort(a, (x, y) => Math.Abs(y).CompareTo(Math.Abs(x)));

                // виведення результату
                Console.Write("Відсортований масив: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("{0} ", a[i]);
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Введіть кількість рядків");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть кількість стовбців");
            int cols = int.Parse(Console.ReadLine());


            // ініціалізація масиву
            double[,] mass = Initmass_2(rows, cols);
            //2.1
            {

                // переміщення від'ємних елементів парних рядків наліво
                for (int i = 0; i < rows; i += 2)
                {
                    int k = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (mass[i, j] < 0)
                        {
                            double temp = mass[i, j];
                            mass[i, j] = mass[i, k];
                            mass[i, k] = temp;
                            k++;
                        }
                    }
                }

                // виведення результату
                Console.WriteLine("Масив після переміщення від'ємних елементів:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write("{0,3}", mass[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            //2.2
            {
                
               

                // знаходження максимального елементу
                double max = mass[0, 0];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (mass[i, j] > max)
                        {
                            max = mass[i, j];
                        }
                    }
                }

                // вилучення рядків і стовпців з максимальним елементом
                bool[] rowToDelete = new bool[rows];
                bool[] colToDelete = new bool[cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (mass[i, j] == max)
                        {
                            rowToDelete[i] = true;
                            colToDelete[j] = true;
                        }
                    }
                }

                // створення нової ущільненої матриці
                int newRows = rows - rowToDelete.Count(x => x);
                int newCols = cols - colToDelete.Count(x => x);
                double[,] b = new double[newRows, newCols];
                int newRow = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (!rowToDelete[i])
                    {
                        int newCol = 0;
                        for (int j = 0; j < cols; j++)
                        {
                            if (!colToDelete[j])
                            {
                                b[newRow, newCol] = mass[i, j];
                                newCol++;
                            }
                        }
                        newRow++;
                    }
                }

                // виведення результату
                Console.WriteLine("Ущільнена матриця:");
                for (int i = 0; i < newRows; i++)
                {
                    for (int j = 0; j < newCols; j++)
                    {
                        Console.Write("{0,3}", b[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            //2.3
            {
                Console.WriteLine("Введіть розмірність квадратної матриці");
               int size  = int.Parse(Console.ReadLine());
                 mass = Initmass_2(size,size);
                int count = 0;

                for (int i = 0; i < size; i++)
                {
                    bool isSorted = true;
                    for (int j = 1; j < size; j++)
                    {
                        if (mass[i, j] < mass[i, j - 1])
                        {
                            isSorted = false;
                            break;
                        }
                    }
                    if (isSorted)
                    {
                        count++;
                    }
                }

                Console.WriteLine("Кількість рядків з елементами, що упорядковані за зростанням: {0}", count);
            }
            Console.ReadKey();
        }
    }
}
    

