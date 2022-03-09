using System;
using System.Data;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace lab6
{
    class Student
    {
        public int Id;
        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            static DataTable GetDataTable(Student[] students)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Id", typeof(Int32));
                table.Columns.Add("Name", typeof(string));
                foreach (Student student in students)
                {
                    table.Rows.Add(student.Id, student.Name);
                }
                return (table);
            }
            static void OutputdataTableHeader(DataTable dt, int columnWidth)
            {
                string format = string.Format("{0}0,-{1}{2}", "{", columnWidth, "}");
                foreach (DataColumn column in dt.Columns)
                {
                    Console.Write(format, column.ColumnName);
                }
                Console.WriteLine();
                foreach (DataColumn column in dt.Columns)
                {
                    for (int i = 0; i < columnWidth; i++)
                    {
                        Console.Write("=");
                    }
                }
                Console.WriteLine();
            }

            Student[] students1 =
            {
                new Student {Id = 1, Name="Alexei Mateievici"},
                new Student {Id = 7, Name="Valcionoc Andrii"},
                new Student {Id = 13, Name="Amur Niuh"},
                new Student {Id = 72, Name="Harcia Bobeicu"}
            };

            Student[] students2 =
            {
                new Student {Id = 5, Name="Muhamed Ali"},
                new Student {Id = 7, Name="Valcionoc Andrii"},
                new Student {Id = 29, Name="Ciuh Ciuhovici"},
                new Student {Id = 72, Name="Harcia Bobeicu"}
            };

            DataTable dt1 = GetDataTable(students1);
            IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
            DataTable dt2 = GetDataTable(students2);
            IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

            IEnumerable<DataRow> except =
                seq1.Except(seq2, System.Data.DataRowComparer.Default);

            Console.WriteLine("{0}Except cu comparator(){0}",
                System.Environment.NewLine);

            OutputdataTableHeader(dt1, 15);

            foreach (DataRow dataRow in except)
            {
                Console.WriteLine("{0,-15}{1,-15}",
                    dataRow.Field<int>(0),
                    dataRow.Field<string>(1));
            }

            except = seq1.Except(seq2);

            Console.WriteLine("{0}Fara Except fatra comparator(){0}",
                System.Environment.NewLine);

            OutputdataTableHeader(dt1, 15);
            foreach (DataRow dataRow in except)
            {
                Console.WriteLine("{0,-15}{1,-15}",
                    dataRow.Field<int>(0),
                    dataRow.Field<string>(1));
            }

            Student[] students =
            {
                new Student {Id = 1, Name="Alexei Mateievici"},
                new Student {Id = 5, Name="Muhamed Ali"},
                new Student { Id=9, Name="Creangoi Marin"},
                new Student {Id = 1, Name="Alexei Mateievici"},
                new Student { Id=16, Name="Salivoi Ion"},
                new Student { Id=20, Name="Zeama Vasile"},
                new Student { Id=28, Name="Creganuta Misulica"}
            };

            DataTable dt = GetDataTable(students);
            Console.WriteLine("{0}Pana la distinct(){0}",
                System.Environment.NewLine);

            OutputdataTableHeader(dt, 15);

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine("{0,-15}{1,-15}",
                    dataRow.Field<int>(0),
                    dataRow.Field<string>(1));
            }
            IEnumerable<DataRow> distinct =
                dt.AsEnumerable().Distinct(DataRowComparer.Default);

            Console.WriteLine("{0}Dupa Distinct(){0}",
                System.Environment.NewLine);

            OutputdataTableHeader(dt, 15);

            foreach (DataRow dataRow in distinct)
            {
                Console.WriteLine("{0,-15}{1,-15}",
                    dataRow.Field<int>(0),
                    dataRow.Field<string>(1));
            }
            //------------------------------Intersect-------------------------------------------------
            IEnumerable<DataRow> duplicates = dt1.AsEnumerable().Intersect(dt2.AsEnumerable(), DataRowComparer.Default);
            Console.WriteLine("{0}Intersect(){0}", System.Environment.NewLine);

            OutputdataTableHeader(dt, 15);

            foreach (DataRow dataRow in duplicates)
            {
                Console.WriteLine("{0,-15}{1,-15}", dataRow.Field<int>(0), dataRow.Field<string>(1));
            }
            //------------------------------Union-------------------------------------------------
            IEnumerable<DataRow> uneon = dt1.AsEnumerable().Union(dt2.AsEnumerable(), DataRowComparer.Default);
            Console.WriteLine("{0}Union(){0}", System.Environment.NewLine);

            OutputdataTableHeader(dt, 15);

            foreach (DataRow dataRow in uneon)
            {
                Console.WriteLine("{0,-15}{1,-15}", dataRow.Field<int>(0), dataRow.Field<string>(1));
            }
        }
    }
}




