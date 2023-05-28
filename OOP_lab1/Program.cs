
using System;
namespace OOP_lab1
{
    class Program
    {
        class TSMatrix
        {
           private int[,] matrix;
           public int size;

            // Конструктори
            public TSMatrix()
            {
                size = 0;
                matrix = new int[size, size];
            }

            public TSMatrix(int[,] arr)
            {
                size = (int)Math.Sqrt(arr.Length);
                matrix = new int[size, size];
               
            }

            public TSMatrix(TSMatrix other)
            {
                size = other.size;
                matrix = new int[size, size];
                Array.Copy(other.matrix, matrix, other.matrix.Length);
            }
           
         


            // Методи
            public int GetSize()
            {
                return size;
            }
            public int GetElement(int row, int col)
            {
                return matrix[row - 1, col - 1];
            }

            public void InputData()
            {
                Random random = new Random();
                Console.WriteLine("Введіть размірність матриці:");
                size = int.Parse(Console.ReadLine());
                matrix = new int[size, size];
               
                while (true)
                {
                    Console.WriteLine("Заповнити вручну(1) чи автоматично(2): ");
                    string temp = Console.ReadLine();
                    if (temp == "1")
                    {
                        Console.WriteLine("Введіть элементи матриці:");
                        for (int i = 0; i < size; i++)
                        {
                            string[] row = Console.ReadLine().Split();
                            for (int j = 0; j < size; j++)
                            {
                                matrix[i, j] = int.Parse(row[j]);
                            }
                        }
                        break;
                    }
                    else if (temp == "2")
                    {
                        
                       
                        for (int i = 0; i < size; i++)
                        {
                         
                           
                            for (int j = 0; j < size; j++)
                            {
                                matrix[i, j] = random.Next(-100, 100); ;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неправильний ввід");

                    }
                }
              
            }
         
            public void OutputData()
            {
                Console.WriteLine("Елементи матриці:");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            public int FindMax()
            {
                int max = matrix[0, 0];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                        }
                    }
                }
                return max;
            }

            public int FindMin()
            {
                int min = matrix[0, 0];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                        }
                    }
                }
                return min;
            }

            public int FindSum()
            {
                int sum = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        sum += matrix[i, j];
                    }
                }
                return sum;
            }
            //перегрузки
            public static TSMatrix operator +(TSMatrix a, TSMatrix b)
            {
                if (a.size != b.size)
                {
                    throw new ArgumentException("Матриці повинні бути одинакової размірності");
                }
                TSMatrix result = new TSMatrix(a);
                for (int i = 0; i < result.size; i++)
                {
                    for (int j = 0; j < result.size; j++)
                    {
                        result.matrix[i, j] += b.matrix[i, j];
                    }
                }
                return result;
            }

            public static TSMatrix operator -(TSMatrix a, TSMatrix b)
            {
                if (a.size != b.size)
                {
                    throw new ArgumentException("Матриці повинні бути одинакової размірності");
                }
                TSMatrix result = new TSMatrix(a);
                for (int i = 0; i < result.size; i++)
                {
                    for (int j = 0; j < result.size; j++)
                    {
                        result.matrix[i, j] -= b.matrix[i, j];
                    }
                }
                return result;
            }
        }
        class TDeterminant2 : TSMatrix
        {
            public TDeterminant2() : base() { }

            public TDeterminant2(TSMatrix elem) : base(elem) { }
            public double Determinant()
            {
                
                return (GetElement(1, 1) * GetElement(2, 2)) - (GetElement(1, 2) * GetElement(2, 1));
            }
           
        }
        
        public static void Main(string[] args)
        {
            TSMatrix a = new TSMatrix();
            a.InputData();
            a.OutputData();
            Console.WriteLine("Максимальний елемент: " + a.FindMax());
            Console.WriteLine("Минімальний елемент: " + a.FindMin());
            Console.WriteLine("Сумма елементів: " + a.FindSum());

            TSMatrix b = new TSMatrix();
            b.InputData();
            b.OutputData();

              TSMatrix c = a + b;
               c.OutputData();

               TSMatrix d = a - b;
               d.OutputData();
            
            TDeterminant2 matrix;
            while (true) {
                Console.WriteLine("Виберіть матрицю для пошуку визначника 1 або 2");
                string temp = Console.ReadLine();
                if (temp == "1")
                {
                     matrix = new TDeterminant2(a);
                    break;
                }
                else if (temp == "2")
                {
                    matrix = new TDeterminant2(b);
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильний ввід");
                    
                }
            }
            Console.WriteLine("Determinant:" + matrix.Determinant());
        
            Console.ReadKey();
        }
    }
}