using System;

namespace ДЗпоМетодам
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool flag;
            int size_x,size_y, menuSelection;
            //string tmp;
            Console.WriteLine("Введите размер массива Array[x,y]");
                Console.Write("x = ");
                    size_x = CheckEnterNumber(Console.ReadLine(), "Ошибка ввода измерения массива", 1);
                Console.Write("y = ");
                    size_y = CheckEnterNumber(Console.ReadLine(), "Ошибка ввода измерения массива", 1);

            int[,] num = new int[size_x, size_y];

            Console.WriteLine($"Введите {num.Length} элементов\nмассива используя Enter:");

            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    Console.Write($"{i * num.GetLength(1) + j + 1}-[{i},{j}] = ");

                    //flag = int.TryParse(Console.ReadLine(), out num[i, j]);

                    //    if (!flag)
                    //    {
                    //        Console.WriteLine("Ошибка ввода, введите число!!!");
                    //        j--;
                    //    }

                    num[i, j] = CheckEnterNumber(Console.ReadLine(), "Ошибка ввода, введите число!!!");
                }
            }

            Console.WriteLine($"Ваш массив Array[{size_x},{size_y}]:");
            Show(num);

            Console.Write("Нажмите если надо:\n" +
                "Найти количество положительных/отрицательных чисел - 1\n" +
                "Сортировка элементов матрицы построчно (в двух направлениях) - 2\n" +
                "Инверсия элементов матрицы построчно - 3\n");


            menuSelection = CheckEnterNumber(Console.ReadLine(),"--Введите цифры от 1 до 3",1,3);
           


            int[,] Nnum = new int[size_x, size_y];
            Array.Copy(num, Nnum, num.Length);//создаем копию массива

            int negativCount = 0, positivCount = 0;
            switch (menuSelection)
            {
                case 1:

                    for (int i = 0; i < num.GetLength(0); i++)
                    {
                        for (int j = 0; j < num.GetLength(1); j++)
                        {
                            if (num[i, j] < 0) negativCount++;
                            else if (num[i, j] > 0) positivCount++;
                        }

                    }
                    Console.WriteLine($"В массиве:\nПоложительных чисел - {positivCount}\n" +
                                      $"Отрицательных чисел - {negativCount}");
                    break;
                case 2:
                    Console.WriteLine("Сортировка построчно:");
                    Console.WriteLine("По возрастанию:");
                    int a, b;
                    for (int i = 0; i < num.GetLength(0); i++)
                    {
                        for (int j = 0; j < num.GetLength(1); j++)
                        {
                            for (int k = 0; k < num.GetUpperBound(1); k++)
                            {
                                if (num[i, k] > num[i, k + 1])
                                {
                                    a = num[i, k];
                                    num[i, k] = num[i, k + 1];
                                    num[i, k + 1] = a;
                                }

                                if (Nnum[i, k] < Nnum[i, k + 1])
                                {
                                    a = Nnum[i, k];
                                    Nnum[i, k] = Nnum[i, k + 1];
                                    Nnum[i, k + 1] = a;
                                }
                            }
                        }
                    }
                    Show(num);
                    Console.WriteLine("или по убыванию:");
                    Show(Nnum);
                    break;

                case 3:
                    Console.WriteLine("Инверсия массива:");
                    for (int i = 0; i < num.GetLength(0); i++)
                    {
                        for (int j = 0; j < num.GetLength(1); j++)
                        {
                            b = i * num.GetLength(1) + j + 1;

                            if (b > num.Length / 2) break;
                            a = num[i, j];
                            num[i, j] = num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j];
                            num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j] = a;

                        }
                    }

                    Show(num);

                    Console.WriteLine("или инверсия массива построчно:");
                    for (int i = 0; i < Nnum.GetLength(0); i++)
                    {
                        for (int j = 0; j < Nnum.GetLength(1) / 2; j++)
                        {
                            b = Nnum[i, j];
                            Nnum[i, j] = Nnum[i, Nnum.GetUpperBound(1) - j];
                            Nnum[i, Nnum.GetUpperBound(1) - j] = b;
                        }

                    }
                    Show(Nnum);
                    break;
                //default:
                //    Console.WriteLine($"Вы выбрали {n}, а надо 1,2 или 3 !!!");
                //    break;
            }
            Console.ReadKey();
           
        }

             // метод для вывода массива на консоль в виде матрицы
            static void Show(int[,] num)
            {
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    for (int j = 0; j < num.GetLength(1); j++)
                    {
                        Console.Write("{0,-3} ", num[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            
           
            //метод для проверки вводимых значений с консоли , условие >= minValue & <= maxValue
            static int CheckEnterNumber(string enterText, string message,int minValue = int.MinValue, int maxValue = int.MaxValue)
            {
                bool flag;
                int number;
                do
                {
                    flag = int.TryParse(enterText, out number);
                    if (!flag || number < minValue || number>maxValue)
                    {
                        Console.WriteLine(message);
                        flag = false;
                        enterText = Console.ReadLine();
                    }
                } while (!flag);
                return number;
            }
    }
}
