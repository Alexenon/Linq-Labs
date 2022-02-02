using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp
{
    internal class MainClass
    {
        public static void Main(String[] args)
        {
            callXML();
        }

        private static void callXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:/Alex/Programming/C#/ConsoleApp/Lab4/xmlFile.xml");
            
            XmlElement xRoot = xDoc.DocumentElement;
            
            foreach (XmlNode xnode in xRoot)
            {
                
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Numele companiei: {childnode.InnerText}");
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Varsta: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void printMovieOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1.Afisati filmele cu bugetul peste x dolari");
            Console.WriteLine("2.Afisati filmele care se incep cu o litere oarecare");
            Console.WriteLine("3.Afisati filmele dintr-un an anumit");
            Console.WriteLine("4.Afisati filmele in care se gaseste o litera oarecare");
            Console.WriteLine("5.Sortati filmele in ordine crescatoare");
            Console.WriteLine("6.Afisati primul film din lista");
            Console.WriteLine("7.Afisati ultimul film din lista");
            Console.WriteLine("8.Afisati filmele cu ratingul mai mare de");
            Console.WriteLine("9.Afisati filmele pina cind denumirea lor depaseste n caractere.");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("");
        }

        private static void chooseMovie()
        {

            List<Movie> movies = new List<Movie>()
            {
                new Movie("My Little Ponny", 2020, 8.8, 2_600_000),
                new Movie("Mad Max", 2010, 9.0, 8_900_000),
                new Movie("Dancing Little Shoe", 2015, 4.6, 500_000),
                new Movie("Last Repository", 2022, 5.2, 2_000_000),
                new Movie("Turn around", 2012, 7.0, 4_000_000),
                new Movie("Alone", 2020, 6.7, 12_000_000),
                new Movie("Warm sand, cold shower", 2000, 7.4, 10_000_000),
                new Movie("Look at me", 2018, 8.0, 5_500_000),
                new Movie("Dark Passenger", 2008, 7.4, 23_600_000),
                new Movie("Dexter", 2004, 9.2, 1_800_000)
            };



            printMovieOptions();
            Console.Write("Introduceti optiunea:");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Console.WriteLine("Afisati filmele cu bugetul peste x dolari");
                    Movie.printMovies(Movie.getMovieWithBudgetHigher(movies, 1_000_000));
                    break;
                case 2:
                    Console.WriteLine("Afisati filmele care se incep cu o litere oarecare");
                    Movie.printMovies(Movie.getMovieBeginsWith(movies, "m"));
                    break;
                case 3:
                    Console.WriteLine("Afisati filmele dintr-un an anumit");
                    Movie.printMovies(Movie.getMovieFrom(movies, 2010));
                    break;
                case 4:
                    Console.WriteLine("Afisati filmele in care se gaseste o litera oarecare");
                    Movie.printMovies(Movie.getMovieContains(movies, "a"));
                    break;
                case 5:
                    Console.WriteLine("Sortati filmele in ordine crescatoare");
                    Movie.getSortedFilmsByName(movies);
                    break;
                case 6:
                    Console.WriteLine("Afisati primul film din lista");
                    Movie.printMovie(Movie.getFirstMovie(movies));
                    break;
                case 7:
                    Console.WriteLine("Afisati ultimul film din lista");
                    Movie.printMovie(Movie.getLastMovie(movies));
                    break;
                case 8:
                    Console.WriteLine("Afisati filmele cu ratingul mai mare de");
                    Movie.printMovies(Movie.getMovieWithRatingHigher(movies, 8.50));
                    break;
                case 9:
                    Console.WriteLine("Afisati filmele pina cind denumirea lor depaseste n caractere.");
                    Movie.printMovies(Movie.getMovieWhileTitleIsLonger(movies, 7));
                    break;
                default:
                    break;
            }


        }

        public static void chooseStudent()
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
