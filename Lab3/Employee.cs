namespace ConsoleApp.Lab3
{
    public class Employee
    {
        public static int count = 0;
        public int id;
        public string name;
        public bool qualified;
        public int salary;
        public Address address;

        public Employee(string name, bool qualified, int salary, Address address)
        {
            this.id = ++count;
            this.name = name;
            this.qualified = qualified;
            this.salary = salary;
            this.address = address;
        }

        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, Qualified: {(qualified ? "Yes" : "Nope")}, Salary: {salary}, Address: {address}";
        }
    }
}
