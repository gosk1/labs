﻿namespace Lab02;

public static class Program
{
    public static void Main(string[] args)
    {
        Greeting();
        string inp;
        int length;
        do
        {
            Console.Write("Введите длину вектора: ");
            inp = Console.ReadLine();
        } while (!int.TryParse(inp, out length) || length <= 0);

        var vec = new LinkedListVector(length);
        vec.Log("Созданный вектор");
        
        while (true)
        {
            Console.WriteLine("Выберете действие:\n\n" +
                              "\t1 - Добавить элемент в начало списка\n" +
                              "\t2 - Добавить элемент в конец списка\n" +
                              "\t3 - Добавить элемент по индексу\n" +
                              "\t4 - Удалить первый элемент\n" +
                              "\t5 - Удалить последний элемент\n" +
                              "\t6 - Удалить элемент по индексу\n" +
                              "\t0 - Выход из программы\n");

            inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                {
                    int value;
                    do
                    {
                        Console.Write("Введите значение для добавления: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out value));
                    
                    vec.AddToStart(value);
                    vec.Log("Обновленный вектор");
                    break;
                }
                case "2":
                {
                    int value;
                    do
                    {
                        Console.Write("Введите значение для добавления: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out value));
                    
                    vec.AddToEnd(value);
                    vec.Log("Обновленный вектор");
                    break;
                }
                case "3":
                {
                    int value;
                    do
                    {
                        Console.Write("Введите значение для добавления: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out value));
                    
                    int idx;
                    do
                    {
                        Console.Write("Введите позицию для добавления элемента: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out idx));

                    try
                    {
                        vec.AddByIndex(idx, value);
                        vec.Log("Обновленный вектор");
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Введенный индекс выходит за рамки связного списка");
                    }
                    break;
                }
                case "4":
                {
                    vec.DeleteFromStart();
                    vec.Log("Обновленный вектор");
                    break;
                }
                case "5":
                {
                    vec.DeleteFromEnd();
                    vec.Log("Обновленный вектор");
                    break;
                }
                case "6":
                {
                    int idx;
                    do
                    {
                        Console.Write("Введите индекс элемента который хотите удалить: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out idx));

                    try
                    {
                        vec.DeleteByIndex(idx);
                        vec.Log("Обновленный вектор");
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Введенный индекс выходит за рамки связного списка");
                    }

                    break;
                }
                case "0":
                {
                    Console.WriteLine("До скорой встречи, до скорой встречи!");
                    return;
                }
                default:
                {
                    Console.WriteLine("Нет такого пункта в меню");
                    break;
                }
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    public static void Greeting()
    {
        Console.WriteLine("Языки Программирования и Структуры Данных\n" +
                          "Лабораторная работа #2\n" +
                          "Выполнил студент группы 6101-020302D - Фадеев Артем");
    }
}