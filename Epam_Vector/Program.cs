using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(1, 2, 5);
            Vector vector2 = new Vector(4, 8, 1);
            //Add two vectors
            Console.WriteLine("Додавання(перегрузка): " + vector1 + " + " + vector2 + " = " + (vector1 + vector2));
            //another way add
            //Vector vectorRes = vector1.Add(vector2);
            Console.WriteLine("Додавання(метод): " + vector1 + " + " + vector2 + " = " + vector1.Add(vector2));
            //Substracting two vectors
            Console.WriteLine("Віднімання(перегрузка): " + vector1 + " - " + vector2 + " = " + (vector1 - vector2));
            //another way substracting
            Console.WriteLine("Віднімання(метод): " + vector1 + " - " + vector2 + " = " + vector1.Subs(vector2));
            //Scalar multiplying two vectors
            vector1 = new Vector(1, 2, -5);
            vector2 = new Vector(4, 8, 1);
            Console.WriteLine("Скалярний добуток(метод): " + vector1 + " scalar* " + vector2 + " = " + vector1.MultScalar(vector2));
            //Vector multiplying two vectors
            vector1 = new Vector(-1, 2, -2);
            vector2 = new Vector(2, 1, -1);
            Console.WriteLine("Векторний добуток(метод): " + vector1 + " * " + vector2 + " = " + vector1.MultVector(vector2));
            //another way multiplying
            vector1 = new Vector(1, 2, 3);
            vector2 = new Vector(2, 1, -2);
            Console.WriteLine("Векторний добуток(перегрузка): " + vector1 + " * " + vector2 + " = " + (vector1 * vector2));
            //Mixed multiplying two vectors
            vector1 = new Vector(1, 2, 3);
            vector2 = new Vector(1, -1, 1);
            Vector vector3 = new Vector(2, 0, -1);
            Console.WriteLine("Мішаний добуток векторів: {0}, {1}, {2} = {3}", vector1, vector2, vector3, vector1.MultMixed(vector2, vector3));
            //Angle between two vectors
            vector1 = new Vector(1, 0, 3);
            vector2 = new Vector(5, 5, 0);
            double cosA = vector1.CosAngle(vector2);
            Console.WriteLine("Косинус кута між вектором {0} і {1} = {2}",vector1, vector2, vector1.CosAngle(vector2));
            //Comparison of two vectors
            Console.WriteLine("Порівняння "+vector1+" з "+vector2+" = "+vector1.isEqual(vector2));
            vector1 = new Vector(5, 5, 0);
            Console.WriteLine("Порівняння " + vector1 + " з " + vector2 + " = " + vector1.isEqual(vector2));
            
        }
    }
}
