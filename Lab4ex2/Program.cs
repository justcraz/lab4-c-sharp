using System;
using System.Collections;
using System.IO;
namespace Lab4ex2
{
    class Program
    {
        public static ArrayList ReadFromFile(string path)
        {
            ArrayList list = new ArrayList();
            string line;
            StreamReader reader = File.OpenText(path);

            while ((line = reader.ReadLine()) != null)
            {
                string[] s = line.Split(new string[]
                {
                    "Номер пари: ", ", День тижня: ", ", Предмет: ", ", Прiзвище викладача: ", ", Форма заняття: "
                }, 5, StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Couple(s[0], s[1], s[2], s[3], s[4]));
            }
            reader.Close();
            return list;
        }

        // Метод для редагування запису //

        public static Couple Edit(Couple couple)
        {
            Console.WriteLine("\nЯке поле ви хочете редагувати?\n\n" +
                                               "Номер пари - 1\n" +
                                               "День тижня - 2\n" +
                                               "Предмет - 3\n" +
                                               "Прiзвище викладача - 4\n" +
                                               "Форма заняття - 5\n" +
                                               "Вийти - 6");
            Console.Write("\nВаш вибiр: ");
            int localNum = int.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введiть нове значення: ");
            switch (localNum)
            {
                case 1:
                    couple.Numcouple = Console.ReadLine(); break;
                case 2:
                    string changeweekday = Console.ReadLine();
                    
                    {
                        couple.Weekday = changeweekday; break;
                    }
                case 3:
                    string changeitem = Console.ReadLine();
                    {
                        couple.Item = changeitem; break;
                    }
                case 4:
                    string changesurname = Console.ReadLine();

                    couple.Surname = Console.ReadLine();
                    break;
                    
                case 5:
                    string changeform = Console.ReadLine();
                    {
                        couple.Form = changeform; break;
                    }
                case 6: break;
            }
            return couple;
        }
        public static void Write(string path, ArrayList students)
        {
            StreamWriter streamWriter;
            streamWriter = File.CreateText(path);
            foreach (Couple n in students)
            {
                streamWriter.WriteLine(n);
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            string path = "D:\\database.txt";
        

            ArrayList students = new ArrayList(new Couple[] { });
            Console.WriteLine("\n_--_--_--_--_--_-Ласкаво просимо до програми, виберiть один iз варiантiв запропонованих меню-_--_--_--_--_-\n\n");
            while (true)
            {


                Console.WriteLine("\n\tМеню\n\n" +
                                  "\nДодати запис - 1\n" +
                                  "Редагувати запис - 2\n" +
                                  "Видалити запис - 3\n" +
                                  "Вивести усi записи - 4\n" +
                                  "Пошук за номером пари - 5\n" +
                                  "Вийти - 6");
                try
                {
                    bool breakFlag = false;
                    int a;
                    Console.Write("\nВаш вибiр: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                    switch (choice)
                    {
                        // Додавання запису

                        case 1:
                            Console.Write("Номер пари: ");
                            string numcouple = Console.ReadLine();
                            
                            if (int.Parse(numcouple) < 1 || int.Parse(numcouple) > 5)
                            {
                                Console.Write("\nНомер пари не може бути бiльшим за 5 i меншим за 0 \n"); break;
                            }
                            Console.Write("День тижня: ");
                            string weekday = Console.ReadLine();

                            Console.Write("Предмет: ");
                            string item = Console.ReadLine();

                            Console.Write("Прiзвище викладача: ");
                            string surname = Console.ReadLine();
                            
                            Console.Write("Форма заняття: ");
                            string form = Console.ReadLine();
                            
                            students = ReadFromFile(path);
                            Couple student = new Couple(numcouple, weekday, item, surname, form);
                            students.Add(student);
                            Write(path, students);
                            break;
                            Console.OutputEncoding = System.Text.Encoding.Default;

                        // Вибір запису для редагування 

                        case 2:
                           students = ReadFromFile(path);
                            Console.WriteLine("Який запис хочете редагувати?\n");
                            a = 1;
                            students.Sort();
                            for (int i = 0; i < students.Count; i++)
                            {
                                a++;
                                Couple n = (Couple)students[i];
                                Console.WriteLine($"{i + 1} - Номер пари: {n.Numcouple}, День тижня: {n.Weekday}, Предмет: {n.Item}, Прiзвище викладача: {n.Surname}, Форма заняття: {n.Form}");
                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int editChoice = int.Parse(Console.ReadLine());
                            if (editChoice == a)
                                break;
                            students[editChoice - 1] = Edit((Couple)students[editChoice - 1]);
                            Write(path, students);
                            break;

                        // Видалення запису

                        case 3:
                            Console.WriteLine("Виберiть запис який хочете видалити\n");
                            a = 1;
                            students = ReadFromFile(path);
                            students.Sort();
                            for (int i = 0; i < students.Count; i++)
                            {
                                a++;
                                Couple n = (Couple)students[i];
                                Console.WriteLine($"{i + 1} - Номер пари: {n.Numcouple}, День тижня: {n.Weekday}, Предмет: {n.Item}, Прiзвище викладача: {n.Surname}, Форма заняття: {n.Form}");

                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int deleteChoice = int.Parse(Console.ReadLine());
                            Console.Write("\n");
                            if (deleteChoice == a)
                                break;
                            students.Remove(students[deleteChoice - 1]);
                            Write(path, students);
                            break;

                        // Виведення усіх записів

                        case 4:
                            students = ReadFromFile(path);
                            students.Sort();
                            foreach (Couple n in students)
                            {
                                Console.WriteLine($"Номер пари: {n.Numcouple}, День тижня: {n.Weekday}, Предмет: {n.Item}, Прiзвище викладача: {n.Surname}, Форма заняття: {n.Form}");
                            }
                            Console.WriteLine("\n");
                            break;

                        // Знаходження за номером групи

                        case 5:
                            int count = 0;
                            students = ReadFromFile(path);
                            Console.Write("Введiть день тижня: ");
                            string weekdays = Console.ReadLine();
                                Console.Write("\n");
                                
                            foreach (Couple n in students)
                            {
                                if (n.Weekday.Equals(weekdays))
                                {
                                    Console.WriteLine(n);
                                    count++;
                                    
                                }
                               
                            }
                            if (count == 0)
                            {
                                    Console.Write("Даних про пару немає \n");
                                  
                                }
                            
                            break;
                        case 6:
                            breakFlag = true;
                            break;
                        default:
                            continue;
                    }
                    if (breakFlag)
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nВводити можна тiльки букви!\n");
                }
            }
        }
    }
}