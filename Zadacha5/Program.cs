using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha5
{
    class Program
    {
        static Random rnd = new Random();
        public static int sizeMatrix;

        static void MakeMatrix(int size,int[,] array)
        {
            sizeMatrix = size;
            int[,] matr = new int[size, size];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = rnd.Next(-10, 10);
                }
            }
        }// создание массива
        static void Print(int[,] array)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Матрица {array.GetLength(0)}x{array.GetLength(1)}");
            Console.ResetColor();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }// печать массива
        static bool Check(int[,] array)
        {
            bool okey = false;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, i] < 0)
                    {
                        okey = true;
                    }
                    else okey = false;
                }
            }
            return okey;
        } // проверяем на главной диагонали 0 или нет

        static void FindMax(int[,] array)
        {
            int[] maxValues = new int[array.GetLength(0)];
            int max = -100000;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, i] < 0)
                    {
                        if (array[i, j] > max)
                        {
                            max = array[i, j];
                            maxValues[i] = max;
                        }
                    }
                }
               max = -100000;
            }
            for (int i = 0; i < maxValues.Length; i++)
            {
                if (maxValues[i] == 0) Console.WriteLine($"В строке {i + 1} на главной диагонали не отрицательный!");
                else
                {
                    Console.WriteLine($"В строке {i + 1} максимальный {maxValues[i]}");
                }
            }
        } //массив максимальных элементов
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите размер матрицы NxN");
            Console.ResetColor();
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            MakeMatrix(n, matrix);
            Print(matrix);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Максимальные элементы для строк, где на главной диагонали элемент отрицательный");
            Console.ResetColor();
            FindMax(matrix);
            Console.ReadKey();
        }
    }
}
