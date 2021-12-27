using System;
using Xunit;
using MoneyCalculator;
using MoneyCalculator.Processors;
using MoneyCalculator.Recipients;
using System.Collections.Generic;
using System.Linq;


namespace XUnitTests
{
    public class ProcessorTests
    {
        [Fact]
        public void CorrectProcessing()
        {
            var people = new HashSet<Person>()
            {
                new Person("Daniel"),
                new Person("Vitali"),
                new Person("Poul"),
                new Person("Anne")
            };
            var expenses = new List<Expenses>()
            {
                new Expenses(people.FirstOrDefault(x => x.Name.Equals("Daniel"))),
                new Expenses(people.FirstOrDefault(x => x.Name.Equals("Vitali"))),
                new Expenses(people.FirstOrDefault(x => x.Name.Equals("Poul"))),
                new Expenses(people.FirstOrDefault(x => x.Name.Equals("Anne")))
            };
            expenses[0].Debts.Add(new Position("chocolate", people, 50));
            expenses[0].Debts.Add(new Position("cucumber", people.Where(x => x.Name == "Daniel").ToHashSet(), 100));
            expenses[1].Debts.Add(new Position("bread", people.Where(x => x.Name == "Daniel" || x.Name == "Poul" || x.Name == "Vitali").ToHashSet(), 15));
            expenses[2].Debts.Add(new Position("cocount", people.Where(x => x.Name == "Anne" || x.Name == "Poul").ToHashSet(), 62));
            var inputData = new InputData(expenses);
            var actualOutputData = new Processor().Process(inputData);

            var expectedOutputData = new OutputData(new List<PersonalDebts>()
            {
                new PersonalDebts(people.FirstOrDefault(x => x.Name.Equals("Daniel"))),
                new PersonalDebts(people.FirstOrDefault(x => x.Name.Equals("Vitali"))),
                new PersonalDebts(people.FirstOrDefault(x => x.Name.Equals("Poul"))),
                new PersonalDebts(people.FirstOrDefault(x => x.Name.Equals("Anne")))
            });
            //Daniel
            expectedOutputData.PersonalDebts[0].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Daniel")), 112.5M);//self
            expectedOutputData.PersonalDebts[0].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Vitali")), 0);//5M
            //Vitali
            expectedOutputData.PersonalDebts[1].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Daniel")), 7.5M);//12.5M
            expectedOutputData.PersonalDebts[1].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Vitali")), 5M);//self
            //Poul
            expectedOutputData.PersonalDebts[2].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Daniel")), 12.5M);
            expectedOutputData.PersonalDebts[2].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Vitali")),5M);
            expectedOutputData.PersonalDebts[2].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Poul")),31M);// self
            //Anne
            expectedOutputData.PersonalDebts[3].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Daniel")), 12.5M);
            expectedOutputData.PersonalDebts[3].AddDebt(people.FirstOrDefault(x => x.Name.Equals("Poul")), 31M);


            Assert.True(new OutputDataComparer().IsEqual(expectedOutputData, actualOutputData));
        }
    }
}
