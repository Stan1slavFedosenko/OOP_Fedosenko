using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace OOP_lab4
{

    internal class Program
    {
        static int CountWords(char[] content)
        {
            int wordCount = 0;
            bool inWord = false;

            foreach (char c in content)
            {
                if (Char.IsLetter(c))
                {
                    if (!inWord)
                    {
                        inWord = true;
                        wordCount++;
                    }
                }
                else
                {
                    inWord = false;
                }
            }

            return wordCount;
        }

        static int CountWords(List<char> content)
        {
            int wordCount = 0;
            bool inWord = false;

            foreach (char c in content)
            {
                if (Char.IsLetter(c))
                {
                    if (!inWord)
                    {
                        inWord = true;
                        wordCount++;
                    }
                }
                else
                {
                    inWord = false;
                }
            }

            return wordCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть текст, який буде зчитуватись з файлу:");
            string input = Console.ReadLine();
            File.WriteAllText("text.txt", input);
            string filePath = "text.txt"; // шлях до файлу
                char[] fileContent = File.ReadAllText(filePath).ToCharArray(); // заносимо вміст файлу до масиву символів

                int wordCount = CountWords(fileContent); // обчислюємо кількість слів за допомогою методу
                Console.WriteLine("Кількість слів: " + wordCount);

                List<char> fileContentList = new List<char>(fileContent); // створюємо колекцію List<T> з масиву символів

                wordCount = CountWords(fileContentList); // обчислюємо кількість слів за допомогою методу
                Console.WriteLine("Кількість слів: " + wordCount);

                Console.ReadKey();
            }

           
        }
    }

