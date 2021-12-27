using MoneyCalculator.Processors;
using MoneyCalculator.Recipients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyCalculator.Processors
{
    public class Processor : IProcessor
    {
        public OutputData Process(InputData inputData)
        {
            var result = new List<PersonalDebts>();
            foreach(var expens in inputData.Expenses)
            {
                foreach(var position in expens.Debts)
                {
                    foreach(var member in position.Members)
                    {
                        var personalDebt = new PersonalDebts(member);
                        if(!result.Contains(personalDebt))
                        {
                            result.Add(personalDebt);                          
                        }                
                        result.FirstOrDefault(x => x.Person.Equals(personalDebt.Person)).AddDebt(expens.Person, CalculateDebt(position.Cost, position.Members.Count));
                    }
                }
            }
            return new OutputData(Optimize(result));
        }

        private decimal CalculateDebt(decimal cost, int countOfPeople)
        {
            return Math.Round(cost / countOfPeople, 2);
        }

        private List<PersonalDebts> Optimize(List<PersonalDebts> personalDebts)
        {
            foreach(var p in personalDebts)
            {
                var keys = new List<Person>(p.DebtToPay.Keys);
                foreach(var person in keys)
                {
                    var money = p.DebtToPay[person];
                    var otherDebts = personalDebts.FirstOrDefault(x => x.Person.Equals(person));
                    if(!otherDebts.Person.Equals(p.Person))
                    {
                        if (otherDebts.DebtToPay.ContainsKey(p.Person))
                        {
                            var otherMoney = otherDebts.DebtToPay[p.Person];
                            if (otherMoney >= money)
                            {
                                p.ReduceDebt(person, money);
                                otherDebts.ReduceDebt(p.Person, money);
                            }
                            else
                            {
                                otherDebts.ReduceDebt(p.Person, otherMoney);
                                p.ReduceDebt(person, otherMoney);
                            }
                        }
                    }

                }
            }
            return personalDebts;
        }
    }
}
