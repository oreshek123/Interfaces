using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modules;
using RandomNameGenerator;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = GenerateStudents();
            PrintList(students);

            Console.ReadLine();

        }

        public static List<Student> GenerateStudents()
        {
            Random Rnd = new Random();
            List<Student> students = new List<Student>();
            for (int i = 0; i < Rnd.Next(15,25); i++)
            {
                Student student = new Student()
                {
                    Name = NameGenerator.GenerateFirstName((Gender) Rnd.Next(0, 2)),
                    FullName = NameGenerator.GenerateLastName(),
                    Grades = new int[Rnd.Next(5,10)]
                };
                for (int j = 0; j < student.Grades.Length; j++)
                {
                    student.Grades[j] = Rnd.Next(2, 6);
                    if (student.Grades[0] == 4 || student.Grades[0] == 5)
                        student.Grades[j] = Rnd.Next(4, 6);
                    
                }
                students.Add(student);
            }
            return students;
        }

        public static void PrintList(List<Student> students)
        {
            foreach (Student item in students)
            {
                Console.WriteLine($"Имя : {item.GetName()}\nФамилия: {item.FullName}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Средний балл : {item.GetAvgGrade()}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
