using System.Data;

namespace lab8
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student(int id, string nume)
        {
            Id = id;
            Name = nume;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            static DataTable GetDataTable(Student[] student)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                foreach (Student studen in student)
                {
                    dt.Rows.Add(studen.Id, studen.Name);
                }
                return dt;
            }

            static void OutputDataTableHeader(DataTable dt, int columnWidth)
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
                        Console.Write("=");
                }
                Console.WriteLine();
            }

            Student[] students =
                {
                new Student ( 1, "Bombila Ion"),
                new Student ( 5, "Crenga Vadim"),
                new Student ( 9, "Vasile Vasilovici"),
                new Student ( 16, "Efros Gheorghe")
                };

            DataTable dt1 = GetDataTable(students);
            IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

            Console.WriteLine("Obiectul principal DataTable: \n");
            foreach (DataRow dr in seq1)
            {
                Console.WriteLine("Studentul cu Id = {0} - {1}", dr.Field<int>("Id"),
                    dr.Field<string>("Name"));
            }

            //facem schimbari
            (from s in seq1
             where s.Field<string>("Name") == "Vasile Vasilovici"
             select s).Single<DataRow>().SetField("Name", "Vasile Maximciuc");

            Console.WriteLine("\nNoul Obiect DataTable: \n");
            DataTable newTable = seq1.CopyToDataTable();
            foreach (DataRow dr in newTable.AsEnumerable())
            {
                Console.WriteLine("Studentul cu Id = {0} - {1}", dr.Field<int>("Id"),
                    dr.Field<string>("Name"));
            }

            Console.WriteLine("\nInainte de update DataTable: \n");
            foreach (DataRow dr in newTable.AsEnumerable())
            {
                Console.WriteLine("Sutend cu Id = {0} : Original {1} : Curent {2}", dr.Field<int>("Id"),
                    dr.Field<string>("Name", DataRowVersion.Original)
                    , dr.Field<string>("Name", DataRowVersion.Current));
            }

            (from s in dt1.AsEnumerable()
             where s.Field<string>("Name") == "Bombila Ion"
             select s).Single<DataRow>().SetField("Name", "Alex Erohin");

            dt1.AsEnumerable().CopyToDataTable(newTable, LoadOption.Upsert);

            Console.WriteLine("\nDupa update DataTable: \n");
            foreach (DataRow dr in newTable.AsEnumerable())
            {
                Console.WriteLine("Student cu Id = {0} : Original {1} : Curent {2}", dr.Field<int>("Id"),
                    dr.HasVersion(DataRowVersion.Original) ?
                    dr.Field<string>("Name", DataRowVersion.Original) : " Nu exista"
                    , dr.Field<string>("Name", DataRowVersion.Current));
            }
            ////Cerintile lab 8
            Console.WriteLine();
            DataTable datatable = new DataTable();
            datatable.Clear();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("Marks");

            DataRow _ravi = datatable.NewRow();
            _ravi["Name"] = "ravi";
            _ravi["Marks"] = "500";
            datatable.Rows.Add(_ravi);

            DataRow _ravi1 = datatable.NewRow();
            _ravi1["Name"] = "Branza";
            _ravi1["Marks"] = "500";
            datatable.Rows.Add(_ravi1);

            DataRow _ravi2 = datatable.NewRow();
            _ravi2["Name"] = "Smantana";
            _ravi2["Marks"] = "500";
            datatable.Rows.Add(_ravi2);

            var results = from myRow in datatable.AsEnumerable()
                          where myRow.Field<string>("Marks") == "500"
                          select myRow;


            Console.WriteLine("Afisarea persoanelor cu Marks = 500");
            foreach (DataRow dr in results)
            {
                Console.WriteLine("Nume: " + dr.Field<string>("Name"));
                Console.WriteLine("Marks: " + dr.Field<string>("Marks"));
                Console.WriteLine();
            }


        }
    }
}

