using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba4
{
    internal class Program
    {
        static List<StudentGroup> listStudentGroups = new List<StudentGroup>();

        static void Main(string[] args)
        {
            //Triangle triangle1 = new Triangle(10, 2, 3);
            //Console.WriteLine(triangle1.ToString());
            //triangle1++;
            //Console.WriteLine(triangle1.ToString());
            //triangle1--;
            //Console.WriteLine(triangle1.ToString());
            //triangle1 *= 10;
            //Console.WriteLine(triangle1.ToString());
            //string str = (string)triangle1;
            //Console.WriteLine(str);
            //string str4 = "1 2 3";
            //Triangle triangle2 = (Triangle)str4;
            //Console.WriteLine(triangle2.ToString());
            //Console.WriteLine(triangle2);
            //if (triangle2)
            //    Console.WriteLine(true);
            //else Console.WriteLine(false);
            //if (triangle1)
            //    Console.WriteLine(true);
            //else Console.WriteLine(false);

            //Console.ReadKey();

            //-----------------------------------------------------
            List<Student> students1 = new List<Student>()
            {
                new Student("Андрей","Голушко", new DateTime(2002,12,12), "89242099090", "М"),
                new Student("Георгий","Петрушко", new DateTime(1999,7,24), "89242099091", "М"),
                new Student("Алексей","Номов", new DateTime(2000,6, 27), "89242099092", "М"),
                new Student("Алиса","Наумова", new DateTime(2004,3,2), "89242099093", "Ж"),
                new Student("Анастасия","Парова", new DateTime(2001,1,1), "89242099094", "Ж"),
            };
            List<Student> students2 = new List<Student>()
            {
                new Student("Андрей","Петров", new DateTime(2002,12,12), "89242099090", "М"),
                new Student("Георгий","Малахов", new DateTime(1999,7,24), "89242099091", "М"),
                new Student("Алексей","Герцов", new DateTime(2000,6, 27), "89242099092", "М"),
                new Student("Алиса","Ладова", new DateTime(2004,3,2), "89242099093", "Ж"),
                new Student("Анастасия","Никова", new DateTime(2001,1,1), "89242099094", "Ж"),
            };

            StudentGroup studentGroup1 = new StudentGroup("БО221ПИН",students1);
            StudentGroup studentGroup2 = new StudentGroup("ААА111АА",students2);
            listStudentGroups.Add(studentGroup1);
            listStudentGroups.Add(studentGroup2);

            Console.WriteLine("Введите \"Помощь\" для отобржения доступных команд");

            string[] command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine().Split('|');
                switch (command[0])
                {
                    case "Помощь": Help(command); break;
                    case "Список": List(command); break;
                    case "Поиск": Find(command); break;
                    case "Добавить": Add(command); break;
                    case "Удалить": Del(command); break;
                }
            } while (command[0] != "exit");

            void Help(string[] commands)
            {
                Console.WriteLine("Список - вывод списка всех групп\n" +
                    "Список|{Номер_группы} - вывод списка студентов определенной группы\n" +
                    "Список|Старосты - вывод старост всех групп\n" +
                    "Список|Староста|{Номер_группы} - вывод старосты определенной группы\n" +
                    "Список|Сортировка|{Номер_группы}|Фамилия или Дата рождения  - вывод список группы отсортированных по фамилии или дате рождения. Доступен только один параметр сортировки.\n" +
                    "Поиск|{Фамилия Имя} - поиск студента по имени и фамилии среди всех групп\n" +
                    "Поиск|{Дата_рождения} - поиск студентов с определённой датой рождения среди всех групп\n" +
                    //string name, string surname, DateTime birthday, string phone, string Gender
                    "Добавить|{Номер_группы}|{Имя}|{Фамилия}|{Дата_рождения(ДД:ММ:ГГГГ)}|{Номер_телефона}|{Пол} - добавление нового студента в определённую группу\n" +
                    "Добавить|Староста|{Номер_группы}|{Номер_студента}\n" +
                    "Удалить|{Номер_группы}|{Номер_студента} - удаление студента с определённой группы\n" +
                    "ПРИМЕЧАНИЕ: Фигурные скобки {} указывают на ввод соответствующего значения"
                    );
            }
            
            void List(string[] commands)
            {
                if (commands.Length == 1)
                {
                    int i = 0;
                    foreach (var studentGroup in listStudentGroups)
                        Console.WriteLine($"\t{++i}{studentGroup.NameGroup, 10}");
                }

                else if (commands.Length == 2)
                {
                    if (commands[1] == "Старосты")
                        foreach (var studentGroup in listStudentGroups)
                            Console.WriteLine(studentGroup.Elder);
                    else if (int.TryParse(commands[1], out int id))
                        listStudentGroups[id - 1].ToString();
                }
                else if (commands.Length == 3)
                {
                    if (commands[1] == "Староста" && int.TryParse(commands[2], out int id))
                        Console.WriteLine(listStudentGroups[id - 1].Elder);
                }
                else if (commands.Length == 4)
                {
                    if (commands[1] == "Сортировка" && int.TryParse(commands[2], out int id))
                    {
                        if (commands[3] == "Фамилия")
                        {
                            listStudentGroups[id - 1].ListStudents.Sort((first, second) => first.Surname.CompareTo(second.Surname));
                        }
                        else if (commands[3] == "Дата рождения")
                        {
                            listStudentGroups[id - 1].ListStudents.Sort((first, second) => first.Birthday.CompareTo(second.Birthday));
                        }
                    }
                }
            }

            void Find(string[] commands)
            {
                //bool isFind = false;
                if (commands[1].Split().Length == 2)
                {
                    string[] temp = commands[1].Split();
                    for (int i = 0; i < listStudentGroups.Count; i++)
                    {
                        for (int j = 0; j < listStudentGroups[i].CountStudents; j++)
                        {
                            if (listStudentGroups[i].ListStudents[j].Surname == temp[0] && listStudentGroups[i].ListStudents[j].Name == temp[1])
                            {
                                Console.Write("\tРезультат поиска: ");
                                Console.WriteLine($"Номер группы - {i + 1}| Номер студента - {j + 1}");
                                Console.WriteLine(listStudentGroups[i].ListStudents[j].ToMoreString());
                                break;
                            }
                        }
                    }
                }
                else if (DateTime.TryParse(commands[1], out DateTime birthday))
                {
                    for (int i = 0; i < listStudentGroups.Count; i++)
                    {
                        for (int j = 0; j < listStudentGroups[i].CountStudents; j++)
                        {
                            if (listStudentGroups[i].ListStudents[j].Birthday == birthday)
                            {
                                Console.Write("\tРезультат поиска: ");
                                Console.WriteLine($"Номер группы - {i + 1}| Номер студента - {j + 1}");
                                Console.WriteLine(listStudentGroups[i].ListStudents[j].ToMoreString());

                            }
                        }
                    }
                }
            }

            void Add(string[] commands)
            {
                if (commands.Length == 7)
                //Добавить |{ Id_группы}|{ Имя}|{ Фамилия}|{ Дата_рождения(ДД: ММ:ГГГГ)}|{Номер_телефона}|{Пол } -добавление нового студента в определённую группу
                //string name, string surname, DateTime birthday, string phone, string Gender
                {
                    listStudentGroups[int.Parse(commands[1])].ListStudents.Add(new Student(commands[2], commands[3], DateTime.Parse(commands[4]), commands[5], commands[6]));
                }
                //"Добавить|Староста|{Id_группы}|{Id_студента}
                else if (commands[1] == "Староста")
                {
                    listStudentGroups[int.Parse(commands[2]) - 1].SetElder(int.Parse(commands[3])-1);
                }
            }

            void Del(string[] commands)
            {
                //"Удалить|{Id_группы}|{Id_студента} - удаление студента с определённой группы\n"
                if (commands.Length == 3)
                    listStudentGroups[int.Parse(commands[1])-1].ListStudents.Remove(listStudentGroups[int.Parse(commands[1])-1].ListStudents[int.Parse(commands[2])-1]);
            }
            //Student FindStudent(List<Product> products, int id)
            //{
            //    foreach (Product product in products)
            //        if (product.Id == id)
            //            return product;
            //    return null;
            //}
        }
        static int CompareBirthdays(Student first, Student second)
        {
            return first.Birthday.CompareTo(second.Birthday);
        }
    }
}
