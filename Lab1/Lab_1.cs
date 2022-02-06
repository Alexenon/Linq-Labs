using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lab1
{
    class Lab_1
    {
        public static void mainMethod()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student(1, "Bat", "Alex", 'm', 19, "079128818", "contract"));
            students.Add(new Student(2, "Covrig", "Petru", 'm', 17, "079543122", "bursa"));
            students.Add(new Student(3, "Stici", "Vlad", 'm', 20, "065432677", "contract"));
            students.Add(new Student(4, "Zgardan", "Razvan", 'm', 19, "065754777", "bursa"));
            students.Add(new Student(5, "Apostol", "Andreia", 'm', 19, "075420355", "contract"));
            students.Add(new Student(6, "Lungu", "Dima", 'm', 19, "070987204", "bursa"));
            students.Add(new Student(7, "Draguta", "Ulic", 'm', 17, "067543556", "bursa"));
            students.Add(new Student(8, "Bulhac", "Max", 'm', 19, "067654554", "contract"));
            students.Add(new Student(9, "Efros", "Jojo", 'm', 16, "078965433", "bursa"));
            students.Add(new Student(10, "Savva", "Xenia", 'f', 20, "076993612", "contract"));

            /* print just all students */
            Student.printListOfStudents(students);

            /* print students older 18 years */
            Student.printListOfStudents(Student.getStudentsOlder(students, 18));

            /* print students that contains 'O' in name */
            Student.printListOfStudents(Student.getStudentsNameContains(students, "o"));

            /* print students on contract */
            Student.printListOfStudents(Student.getStudentsOnContract(students));
        }
    }
}
