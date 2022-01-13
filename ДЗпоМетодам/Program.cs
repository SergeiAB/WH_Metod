using System;

namespace ДЗпоМетодам
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int size_x,size_y, menuSelection;
            int[,] num;
            string msg="Ошибка ввода значения!!!";

                Console.WriteLine("Введите размер массива Array[x,y]");

                Console.Write("x = ");

            size_x = CheckEnterNumber(Console.ReadLine(),msg, 1);

                Console.Write("y = ");

            size_y = CheckEnterNumber(Console.ReadLine(), msg, 1);

            num = new int[size_x, size_y];

                Console.WriteLine($"Введите {num.Length} элементов\nмассива используя Enter:");

            FillingArray(num,msg);

                Console.WriteLine($"Ваш массив Array[{size_x},{size_y}]:");

            Show(num);

                Console.Write("Нажмите если надо:\n" +
                    "Найти количество положительных/отрицательных чисел - 1\n" +
                    "Сортировка элементов матрицы построчно (в двух направлениях) - 2\n" +
                    "Инверсия элементов матрицы построчно - 3\n");

            menuSelection = CheckEnterNumber(Console.ReadLine(),msg,1,3);

            int[,] Nnum = new int[size_x, size_y];

            Array.Copy(num, Nnum, num.Length);//создаем копию массива

            
            switch (menuSelection)
            {
                case 1:
                    {
                        CountPozitivNegativ(num, out int positivCount, out int negativCount);

                        Console.WriteLine($"В массиве:\nПоложительных чисел - {positivCount}\nОтрицательных чисел - {negativCount}");                
                       
                        break;
                    }
                case 2:
                    {   
                        SortingByLine(num, Nnum);

                        Console.WriteLine("Сортировка построчно:\nПо возрастанию:");
                          
                        Show(num);

                        Console.WriteLine("По убыванию:");

                        Show(Nnum);

                        break;
                    }
                case 3:
                    {
                        ArrayInversion(num);

                        ArrayInversionLine(Nnum);

                        Console.WriteLine("Инверсия всего массива:");

                        Show(num);

                        Console.WriteLine("Инверсия массива построчно:");

                        Show(Nnum);

                        break;
                    }   
                
            }
  
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
            
           
                //метод для проверки вводимых значений с консоли на число и по условию >= minValue & <= maxValue
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
            
                // Метод заполнения массива с консоли 
            static void FillingArray(int[,] numArray, string message)
            {
                for (int i = 0; i < numArray.GetLength(0); i++)
                {
                    for (int j = 0; j < numArray.GetLength(1); j++)
                    {
                        Console.Write($"{i * numArray.GetLength(1) + j + 1}-[{i},{j}] = ");
                        numArray[i, j] = CheckEnterNumber(Console.ReadLine(),message);
                    }
                }
            }

                //Метод считает количество положительных и отрицательных чисел
            static void CountPozitivNegativ(int[,] numArray,out int positivCount, out int negativCount)
            {
                negativCount = 0;
                positivCount = 0;
                for (int i = 0; i < numArray.GetLength(0); i++)
                {
                    for (int j = 0; j < numArray.GetLength(1); j++)
                    {
                        if (numArray[i, j] < 0)
                        {
                            negativCount++;
                        }
                        else if (numArray[i, j] > 0)
                        {
                            positivCount++;
                        }
                    }

                }


            }
            
                //Метод сортировка построчно по возрастанию и убывынию
            static void SortingByLine(int[,] num,int[,] Nnum )
            {
                int temp;

                for (int i = 0; i < num.GetLength(0); i++)
                {
                    for (int j = 0; j < num.GetLength(1); j++)
                    {
                        for (int k = 0; k < num.GetUpperBound(1); k++)
                        {
                            if (num[i, k] > num[i, k + 1])
                            {
                                temp = num[i, k];
                                num[i, k] = num[i, k + 1];
                                num[i, k + 1] = temp;
                            }

                            if (Nnum[i, k] < Nnum[i, k + 1])
                            {
                                temp = Nnum[i, k];
                                Nnum[i, k] = Nnum[i, k + 1];
                                Nnum[i, k + 1] = temp;
                            }
                        }
                    }
                }

            }

                //метод инверсия массива
            static void ArrayInversion(int[,] num)
            {
                int temp;
                int itemCounter;
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    for (int j = 0; j < num.GetLength(1); j++)
                    {
                        itemCounter = i * num.GetLength(1) + j + 1;

                        if (itemCounter > num.Length / 2) break;
                        temp = num[i, j];
                        num[i, j] = num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j];
                        num[num.GetUpperBound(0) - i, num.GetUpperBound(1) - j] = temp;

                    }
                }

            }

                // Метод инверсия массива по строчно
            static void ArrayInversionLine(int[,] Nnum)
            {   
                int temp;
                for (int i = 0; i < Nnum.GetLength(0); i++)
                {
                    
                    for (int j = 0; j < Nnum.GetLength(1) / 2; j++)
                    {
                        temp = Nnum[i, j];
                        Nnum[i, j] = Nnum[i, Nnum.GetUpperBound(1) - j];
                        Nnum[i, Nnum.GetUpperBound(1) - j] = temp;
                    }

                }

            }




    }

}
