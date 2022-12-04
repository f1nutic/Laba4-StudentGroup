using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class StudentGroup
    {
        static int count = 1;
        int id;
        private List<Student> listStudents;
        private int countStudents;
        private string nameGroup;
        private Student elder;

        public StudentGroup(string nameGroup, List <Student> students)
        {
            id = count;
            NameGroup = nameGroup;
            listStudents = students;
            count++;
        }

        public int CountStudents { get => countStudents = listStudents.Count; }
        public string NameGroup { get => nameGroup; set => nameGroup = value; }
        public string Elder 
        {
            get
            {
                if (elder != null)
                    return elder.ToString();
                else return $"Староста группы {nameGroup} не назначен.";
                
            }
            set => SetElder(int.Parse(value)); 
        }
        public List<Student> ListStudents { get => listStudents; set => listStudents = value; }

        public void ToString()
        {
            int i = 1;
            foreach (var student in listStudents)
            {
                Console.WriteLine($"{i,4}: {student.ToMoreString()}");
                i++;
            }
        }
        public void SetElder(int id)
        {
            if (id <= listStudents.Count && id > 0)
                elder = listStudents[id];
            else Console.WriteLine("Студент не найден.");
        }
        void AddStudent(Student student)
        {
            listStudents.Add(student);
        }
        void DelStudent(int id)
        {
            listStudents.RemoveAt(id - 1);
        }
        private int Count()
        {
            return countStudents = listStudents.Count;
        }
    }
}
