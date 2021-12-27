using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MoneyCalculator.Processors
{
    public class PersonalDebts
    {
        public Person Person { get; private set; }

        public Dictionary<Person, decimal> DebtToPay { get; private set; } = new();

        public PersonalDebts(Person person)
        {
            Person = person;
        }

        public void AddDebt(Person person, decimal money)
        {
            if (DebtToPay.ContainsKey(person))
            {
                DebtToPay[person] += money;
            }
            else
            {
                DebtToPay.Add(person, money);
            }
        }

        public void ReduceDebt(Person person, decimal money)
        {
            DebtToPay[person] -= money;
        }

        public override bool Equals(object other)
        {
            if (other is null)
                return false;
            return Person.Equals(((PersonalDebts)other).Person);
        }

        public override int GetHashCode()
        {
            return Person.GetHashCode();
        }
    }
}
