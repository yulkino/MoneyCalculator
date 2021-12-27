using MoneyCalculator.Recipients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyCalculator.Parsers
{
    public class Parser : IParser
    {
        public InputData Parse(string[] lines)
        {
            var members = lines[0].Split("; ").Select(x => new Person(x)).ToHashSet();
            var result = new List<Expenses>();
            for(var i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Split("; ");
                var person = FindPersonInMemders(members, line[0]);
                var name = line[1];
                var money = decimal.Parse(line[2]);
                var expens = new Expenses(person);
                var people = new HashSet<Person>();
                for (var j = 3; j < line.Length; j++)
                {
                    if(line[j] == "*")
                    {
                        people = members;
                    }
                    else
                    {
                        people.Add(FindPersonInMemders(members, line[j]));
                    }
                }
                //if(!result.Contains(expens))
                //{
                    result.Add(expens);
                //}
                expens.AddExpens(people, money, name);

            }
            return new InputData(result);
        }

        private Person FindPersonInMemders(HashSet<Person> people, string name)
        {
            return people.FirstOrDefault(x => x.Equals(new Person(name)));
        }
    }
}
