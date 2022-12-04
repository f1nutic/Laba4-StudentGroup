using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class Triangle
    {
        private int a, b, c;

        public int Side1
        {
            get { return a; }
            set { a = value; }
        }
        public int Side2
        {
            get { return b; }
            set { b = value; }
        }
        public int Side3
        {
            get { return c; }
            set { c = value; }
        }

        public string IsTriangle
        {
            get { return CheckTriangle(); }
        }

        public static Triangle operator ++(Triangle triangle)
        {
            return new Triangle(triangle.a+1, triangle.b+1, triangle.c+1);
        }
        public static Triangle operator --(Triangle triangle)
        {
            return new Triangle(triangle.a - 1, triangle.b - 1, triangle.c - 1);
        }

        public static Triangle operator *(Triangle triangle, int value)
        {
            return new Triangle(triangle.a * value, triangle.a * value, triangle.c * value);
        }

        public static bool operator true(Triangle triangle)
        {
            if ((triangle.a < triangle.b + triangle.c) & (triangle.b < triangle.a + triangle.c) & (triangle.c < triangle.b + triangle.a))
                return true;
            else return false;
        }
        public static bool operator false(Triangle triangle)
        {
            if ((triangle.a > triangle.b + triangle.c) || (triangle.b > triangle.a + triangle.c) || (triangle.c > triangle.b + triangle.a))
                return true;
            else return false;
        }
        public static implicit operator string(Triangle triangle)
        {
            return ($"Треугольник|{triangle.a}|{triangle.b}|{triangle.c}");
        }
        public static implicit operator Triangle(string str)
        {
            string[] sides = str.Split('|');
            return new Triangle(Int32.Parse(sides[1]), Int32.Parse(sides[2]), Int32.Parse(sides[3]));
        }
        public int this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    default: throw new Exception("недопустимое значение индекса");
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        a = value;
                        break;
                    case 1:
                        b = value;
                        break;
                    case 2:
                        c = value;
                        break;
                    default: throw new Exception("недопустимое значение индекса");
                }
            }

        }

        private string CheckTriangle()
        {
            if ((a < b + c) & (b < a + c) & (c < b + a)) return $"Треугольник со сторонами ({a}, {b}, {c}) существует";
            else return $"Треугольник со сторонами ({a}, {b}, {c}) не существует";
        }

        public Triangle()
        {
            this.a = 5;
            this.b = 5;
            this.c = 5;
        }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public string Perimetr()
        {
            return string.Format("Периметр треугольника = {0}", a + b + c);
        }

        public string Square()
        {
            return string.Format("Площадь треугольника = {0}", a * b * c);
        }

        public override string ToString()
        {
            return string.Format("Длина первого катета = {0} \nДлина второго катета = {1} \nДлина высоты = {2}", a, b, c);
        }
    }
}
