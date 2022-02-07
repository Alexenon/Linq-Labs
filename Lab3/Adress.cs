using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Lab3
{
    public class Address
    {
        private static int count = 0;
        public int id { get; private set; }
        private string street { get; set; }
        private int block { get; set; }
        private int apartament { get; set; }

        public Address(string street, int block, int apartament)
        {
            this.id = ++count;
            this.street = street;
            this.block = block;
            this.apartament = apartament;
        }

        public override string ToString()
        {
            return $"{street} {block}/{apartament}";
        }
    }
 
}
