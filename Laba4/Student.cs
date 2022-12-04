using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    enum GenderEnum {
        Woman,
        Man
    }
    internal class Student
    {
        string name;
        string surname;
        int age;
        GenderEnum gender;
        DateTime birthday;
        string phone;

        public Student(string name, string surname, DateTime birthday, string phone, string Gender)
        {
            this.name = name;
            this.surname = surname;
            Birthday = birthday;
            Phone = phone;
            this.age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.DayOfYear < birthday.DayOfYear)
                this.age++;
            if (Gender == "М")
                this.gender = GenderEnum.Man;
            else if (Gender == "Ж")
                this.gender = GenderEnum.Woman;
        }

        public Student()
        {
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age;}
        public DateTime Birthday 
        { 
            get => birthday; 
            set
            {
                if (value.Year > 2005)
                    Console.WriteLine("Ошибка! Максимальный год рождения студента - 2005.");
                else birthday = value;
            } 
        }
        public string Phone
        {
            get => phone;
            set
            {
                if (value.Length == 11)
                    phone = value;
                else Console.WriteLine("Ошибка! Номер телефон должен сдержать 11 символов.");
            }
        }
        internal string Gender { get => GenderToRussian(gender);}

        static string GenderToRussian (GenderEnum gender)
        {
            switch(gender)
            {
                case GenderEnum.Man: return "мужчина";
                case GenderEnum.Woman: return "женщина";
                default: return null;
            }
        }
        public string ToString()
        {
            return string.Format($"{surname} {name}");
        }
        public string ToMoreString()
        {
            return string.Format($"{surname+" "+name,18} {age,4} лет    Дата рождения {birthday.ToShortDateString(),9}   Пол: {GenderToRussian(gender)}    Номер: {phone,11}");
        }
    }
}
