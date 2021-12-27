using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MoneyCalculator
{
    public class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public override bool Equals(Object other)
        {
            if (other is null)
                return false;
            return Name == ((Person)other).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
