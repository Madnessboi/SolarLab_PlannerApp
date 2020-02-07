using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Globalization;

namespace SolarLabToDoList
{
    class PlannerApp
    {
        static inMemoryDb DataBase = new inMemoryDb();
        public static void Main(string[] args)
        {
            while (true)
            {
                switch (menuFunc())
                {
                    //Просмотреть список
                    case 1:
                        ListOnScreen();
                        break;
                    //Добавить задание
                    case 2:
                        AddTask();
                        break;
                    //Удалить задание
                    case 3:
                        RemoveTask();
                        break;
                    //Редактировать
                    case 4:
                        Editor();
                        break;
                    //Выход
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            Console.ReadLine();
        }

        static DateTime WriteDate()
        {
            Console.WriteLine("Укажите день: ");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Укажите месяц: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Укажите год: ");
            int year = Convert.ToInt32(Console.ReadLine());

            DateTime fullDate = new DateTime(year, month, day);

            return fullDate;

        }

        static int menuFunc()
        {
            int menuVar;
            Console.WriteLine("1. Список заданий;");
            Console.WriteLine("2. Добавить задание в список;");
            Console.WriteLine("3. Удаления задания из списка;");
            Console.WriteLine("4. Редактирование заданий;");
            Console.WriteLine("5. Выход.");
            Console.WriteLine();
            Console.WriteLine("Пожалуйста, сделайте выбор:");
            menuVar = Convert.ToInt32(Console.ReadLine());
            return menuVar;
        }

        public static void ListOnScreen()
        {
            foreach (var task in DataBase.GetAll())
            {
                Console.WriteLine(task);
            }
        }

        public static void AddTask()
        {
            Console.WriteLine("Что нужно сделать? ");
            string name = Console.ReadLine();

            Task Task1 = new Task();
            Task1.Name = name;

            Console.WriteLine("Дата добавления задания: ");
            DateTime dateBegin = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Task1.Added = dateBegin;

            /*Console.WriteLine("Дата начала выполнения задания: ");
            DateTime dateStart = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Task1.Start = dateStart;

            Console.WriteLine("Дата окончания выполнения задания: ");
            DateTime dateFinish = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Task1.Finish = dateFinish;

            Console.WriteLine("Описание задания:");
            string descrip = Console.ReadLine();
            Task1.Descr = descrip;*/


            DataBase.Add(Task1);
        }

        public static void RemoveTask()
        {
            int id;
            Console.WriteLine("Какое задание требуется удалить? ");
            id = Convert.ToInt32(Console.ReadLine());
            DataBase.Remove(id);
        }

        public static void Editor()
        {
            int id2;
            Console.WriteLine("Планы изменились? ");
            Console.WriteLine("Выберите номер задания: ");
            id2 = Convert.ToInt32(Console.ReadLine());
            Task task = DataBase.GetById(id2);

            Console.WriteLine("Что нужно сделать? ");
            string name = Console.ReadLine();

            task.Name = name;

            Console.WriteLine("Дата добавления задания: ");
            DateTime dateBegin = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            task.Added = dateBegin;

            //Console.WriteLine("Дата начала выполнения задания: ");
            //DateTime dateStart = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //task.Start = dateStart;

            //Console.WriteLine("Дата окончания выполнения задания: ");
            //DateTime dateFinish = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            //task.Finish = dateFinish;

            //Console.WriteLine("Описание задания:");
            //string descrip = Console.ReadLine();
            //task.Descr = descrip;

        }
    }
}
