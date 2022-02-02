using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student
    {
        int IdStudent;
        String nume;
        String prenume;
        int varsta;
        char gen;
        String numarTelefon;
        String contractOrBuget;

        public Student(int IdStudent, String nume, String prenume, char gen, int varsta, String numarTelefon, String contractOrBuget)
        {
            this.IdStudent = IdStudent;
            this.nume = nume;
            this.prenume = prenume;
            this.gen = gen;
            this.varsta = varsta;
            this.numarTelefon = numarTelefon;
            this.contractOrBuget = contractOrBuget;
        }

        private static void printStudent(Student student)
        {
            String result = $"{student.IdStudent} {student.nume} {student.prenume} {student.varsta} "
                + $"{student.gen} {student.numarTelefon} {student.contractOrBuget}";
            Console.WriteLine(result);
        }

        public static void printListOfStudents(List<Student> studens)
        {
            foreach (Student student in studens)
            {
                printStudent(student);
            }
        }

        public static List<Student> getStudentsOlder(List<Student> students, int age)
        {
            return students.Where(s => s.varsta > age).ToList();
        }

        public static List<Student> getStudentsNumberContains(List<Student> students, String partOfNumber)
        {
            return students.Where(s => s.numarTelefon.Contains(partOfNumber)).ToList();
        }

        public static List<Student> getStudentsNameContains(List<Student> students, String partOfName)
        {
            return students.Where(s => s.nume.Contains(partOfName)).ToList();
        }

        public static List<Student> getStudentsOnContract(List<Student> students)
        {
            return students.Where(s => s.contractOrBuget.Equals("Contract")).ToList();
        }

    }
}
