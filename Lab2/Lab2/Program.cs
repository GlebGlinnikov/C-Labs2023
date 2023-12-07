using Lab2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Xml.Serialization;

namespace Lab2
{
    public class Program
    {
        public static MarkList history;   //Список сохранённых решений
        private static Context db = new Context(); //Ссылка на бд

        static void Main(string[] args)
        {
            history = new MarkList();
            Console.WriteLine("Its an equation solver");
            Console.WriteLine();
            while (true)
            {

                //Выводим меню
                Console.WriteLine("Enter a number: ");
                Console.WriteLine("1. Solve a linear equation");
                Console.WriteLine("2. Solve a quadratic equation");
                Console.WriteLine("3. View recent calculations");
                Console.WriteLine("4. Import from XML, Json, SQLite");
                Console.WriteLine("5. Export to XML, Json, SQLite");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                //Принимаем команду
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            SolveLinear();
                            break;
                        case 2:
                            SolveQuadratic();
                            break;
                        case 3:
                            ViewSaved();
                            break;
                        case 4:
                            Import();
                            break;
                        case 5:
                            Export();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine();
            }
        }

        //Метод для решения уравнений 1-ой степени
        static public void SolveLinear()
        {
            Console.WriteLine("Solving a linear equation - kx + b = 0");
            Console.Write("Enter the coefficient 'k': ");
            if (double.TryParse(Console.ReadLine(), out double k))
            {
                //Проверка вводимых данных
                if (k == 0)
                {
                    Console.WriteLine("Invalid input. Coefficient 'k' cannot be zero");
                }

                else
                {

                    Console.Write("Enter the coefficient 'b': ");
                    if (double.TryParse(Console.ReadLine(), out double b))
                    {
                        history.add(k, b);
                        Console.WriteLine();
                        Console.WriteLine($"Mark number: {history.getlength()}");
                        history.printmark(history.getlength());
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for coefficient 'b'");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input for coefficient 'k'");
            }
        }

        //Метод для решения уравнений 2-ой степени
        static public void SolveQuadratic()
        {
            Console.WriteLine("Solving a quadratic equation - ax^2 + bx + c = 0");
            Console.Write("Enter the coefficient 'a': ");
            if (double.TryParse(Console.ReadLine(), out double a))
            {
                //Проверка вводимых данных
                if (a == 0)
                {
                    Console.WriteLine("Invalid input. Coefficient 'a' cannot be zero");
                }
                else
                {
                    Console.Write("Enter the coefficient 'b': ");
                    if (double.TryParse(Console.ReadLine(), out double b))
                    {
                        Console.Write("Enter the coefficient 'c': ");
                        if (double.TryParse(Console.ReadLine(), out double c))
                        {
                            history.add(a, b, c);
                            Console.WriteLine();
                            Console.WriteLine($"Mark number: {history.getlength()}");
                            history.printmark(history.getlength());
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for coefficient 'c'");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for coefficient 'b'");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input for coefficient 'a'");
            }
        }

        //Метод для вывода сохранённых записей
        static public void ViewSaved()
        {
            Console.WriteLine("Enter mark number: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                if (n > history.getlength() || n <= 0)
                {
                    Console.WriteLine($"-- Mark number {n} does not exist --");
                }
                else
                {
                    history.printmark(n);
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        //Импорт
        static public void Import()
        {

                Console.WriteLine("Enter a number: ");
                Console.WriteLine("1. Import from XML");
                Console.WriteLine("2. Import from Json");
                Console.WriteLine("3. Import from SQLite");
                string filePath = "";

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter file path:");
                            filePath = Console.ReadLine();

                            if (!File.Exists(filePath))
                            {
                                Console.WriteLine("File path does not exist");
                            }
                            else
                            {
                                deserializeFromXml(filePath).print();
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter file path:");
                            filePath = Console.ReadLine();

                            if (!File.Exists(filePath))
                            {
                                Console.WriteLine("File path does not exist");
                            }
                            else
                            {
                                deserializeFromJson(filePath).print();
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter a mark number: ");
                            if (int.TryParse(Console.ReadLine(), out int marknum))
                            {
                                marknum--;
                                if (history.getlength() <= marknum)
                                {
                                    Console.WriteLine($"-- Mark number {marknum + 1} does not exist --");
                                }
                                else
                                {
                                    importFromSql(marknum).print();
                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

        //Экспорт
        static public void Export()
        {
            Console.WriteLine("Enter a mark number: ");
            if (int.TryParse(Console.ReadLine(), out int marknum))
            {
                marknum--;
                if (history.getlength() <= marknum)
                {
                    Console.WriteLine($"-- Mark number {marknum+1} does not exist --");
                }

                else
                {
                    Console.WriteLine("Enter a number: ");
                    Console.WriteLine("1. Export to XML");
                    Console.WriteLine("2. Export to Json");
                    Console.WriteLine("3. Export to SQLite");
                    string filePath = "";


                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Enter file path:");
                                filePath = Console.ReadLine();

                                if (!File.Exists(filePath))
                                {
                                    Console.WriteLine("File path does not exist");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"-- Mark {marknum+1} was XML-serialized to {filePath} --");
                                    history.GetMark(marknum).serializeToXml(filePath);
                                }
                                break;

                            case 2:
                                Console.WriteLine("Enter file path:");
                                filePath = Console.ReadLine();

                                if (!File.Exists(filePath))
                                {
                                    Console.WriteLine("File path does not exist");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"-- Mark {marknum+1} was Json-serialized to {filePath} --");
                                    history.GetMark(marknum).serializeToJson(filePath);
                                }
                                break;

                            case 3:
                                exportToSql(marknum);
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        //Десериализация XML
        public static Mark deserializeFromXml(string filePath)
        {
            Console.WriteLine();
            Console.WriteLine($"-- Mark from {filePath}: --");
            XmlSerializer serializer = new XmlSerializer(typeof(Mark));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (Mark)serializer.Deserialize(stream);
            }
        }

        //Десериализация Json
        public static Mark deserializeFromJson(string filePath)
        {
            Console.WriteLine();
            Console.WriteLine($"-- Mark from {filePath}: --");
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Mark>(json);
        }

        //SQLite вывод
        public static Mark importFromSql(int marknum)
        {
            Console.WriteLine();
            Console.WriteLine($"-- Mark {marknum+1} from SQL database: --");
            return db.dbmarks.ToList()[marknum].toMark();
        }

        //SQLite запись
        public static void exportToSql(int id)
        {
            dbmark dbmark = new dbmark(history.GetMark(id));
            db.dbmarks.Add(dbmark);
            db.SaveChanges();
            Console.WriteLine();
            Console.WriteLine($"-- Mark {id+1} was exported to SQL database--");
        }
    }
}
