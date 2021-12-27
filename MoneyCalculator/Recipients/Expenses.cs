using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MoneyCalculator.Recipients
{
    public class Expenses
    {
        public Person Person { get; private set; }
        public List<Position> Debts { get; private set; } = new ();

        public Expenses(Person person)
        {
            Person = person;
        }

        public void AddExpens(HashSet<Person> people, decimal money, string name)
        {
            Debts.Add(new Position(name, people, money));
        }

        public override bool Equals(Object other)
        {
            if (other is null)
                return false;
            return Person.Equals(((Expenses)other).Person);
        }

        public override int GetHashCode()
        {
            return Person.GetHashCode();
        }
    }
}
