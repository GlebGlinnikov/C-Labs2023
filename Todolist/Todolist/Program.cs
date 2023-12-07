using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

//3.Todo - list
//Главное меню программы включает следующие пронумерованные пункты:
//1.добавление новой задачи
//2.поиск задач по тэгам вывод N наиболее актуальных задач
//3.выход.

//Для выбора нужного пункта меню пользователь вводит соответствующий номер.
//При добавлении новой задачи пользователь последовательно вводит
//тему задачи, описание, дату к которой задача должна быть готова и тэги.
//Ввод тэгов продолжается до тех пор, пока пользователь не введёт пустую строку.
//Для поиска пользователь вводит через пробел ключевые слова, наличие которых среди тэгов задачи является критерием выборки.

//Вывод актуальных задач осуществляется в отсортированном по дате готовности порядке.

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {


            int comanda = 0;
            string NameTag = "";

            TodoList todoList = new TodoList();



            while (comanda != 3)
            {
                Console.WriteLine("Введите номер команды:");
                Console.WriteLine("1 - добавление новой задачи");
                Console.WriteLine("2 - поиск задач по тэгам");
                Console.WriteLine("3 - выход из программы");
                Console.WriteLine("4 - удаление");

                comanda = Convert.ToInt32(Console.ReadLine());
                //1.добавление новой задачи
                if (comanda == 1)
                {
                    var task = new TodoTask();
                    Console.WriteLine("Введите название задачи");
                    string TaskName = Console.ReadLine();
                    task.Title = TaskName;

                    Console.WriteLine("Введите описание задачи");
                    string TaskDescription = Console.ReadLine();
                    task.Description = TaskDescription;

                    Console.WriteLine("Введите дедлайн");
                    String deadLine = Console.ReadLine();
                    DateTime DDLine = DateTime.Parse(deadLine);
                    task.Deadline = DDLine;

                    Console.WriteLine("Введите тэги");
                    Console.WriteLine("(вывод прекратиться, когда вы введете пустую строку)");
                    NameTag = " ";
                    while (NameTag != "")
                    {
                        NameTag = Console.ReadLine();
                        task.AddTag(NameTag);
                        todoList.Add(task);
                    }

                    task.IsCompleted = false;
                }

                //2.поиск задач по тэгам вывод N наиболее актуальных задач
                if (comanda == 2)
                {
                    Console.WriteLine("Введите тэги, по которым будет выполнен поиск");
                    Console.WriteLine("Чтобы закончить ввод - введите пустую строку");

                    NameTag = Convert.ToString(Console.ReadLine());
                    //Ввод тэгов продолжается до тех пор, пока пользователь не введёт пустую строку.
                    while (NameTag != "")
                    {
                        //task.HasTag(NameTag);

                        var searchResults = todoList.Search(NameTag);
                        if (searchResults.Count() == 0)
                        {
                            Console.WriteLine("Задач с заданным тегом нет");
                        }
                        else
                        {
                            Console.WriteLine("Это все задания по Вашему запросу");
                            foreach (var result in searchResults)
                            {
                                Console.WriteLine(result);
                            }
                        }


                        NameTag = Convert.ToString(Console.ReadLine());
                    }
                }

                //3.выход.
                if (comanda == 3)
                {
                    Environment.Exit(0);
                }

                //4.удаление тэга 
                if (comanda == 4)
                {
                    Console.WriteLine("введите тэг");
                    NameTag = Convert.ToString(Console.ReadLine());


                    while (NameTag != "")
                    {
                        var searchResults = todoList.Search(NameTag);
                        if (searchResults.Count() == 0)
                        {
                            Console.WriteLine("Задач с заданным тегом нет");
                        }
                        else
                        {
                            Console.WriteLine("Это все задания по Вашему запросу");
                            foreach (var result in searchResults)
                            {
                                result.RemoveTag(NameTag);
                                Console.WriteLine("тэг удален");
                            }
                        }

                        NameTag = Convert.ToString(Console.ReadLine());
                    }


                }

            }
        }
    }
}
