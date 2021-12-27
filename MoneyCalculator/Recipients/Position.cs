using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Recipients
{
    public class Position
    {

        public string ProductName { get; private set; }
        public HashSet<Person> Members { get; private set; }
        public decimal Cost { get; private set; }

        public Position(string name, HashSet<Person> members, decimal cost)
        {
            ProductName = name;
            Members = members;
            Cost = cost;
        }
    }
}
