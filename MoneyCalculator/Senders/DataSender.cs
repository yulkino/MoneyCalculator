using MoneyCalculator.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MoneyCalculator.Senders
{
    public class DataSender : IDataSender
    {
        public void SendData(OutputData outputData)
        {
            Clear();
            WriteLine("Список долгов: ");
            foreach(var debts in outputData.PersonalDebts)
            {
                WriteLine($"{ debts.Person.Name, 10}" + ": ");
                foreach(var (person, money) in debts.DebtToPay)
                {
                    if(money != 0M)
                    {
                        if (!debts.Person.Equals(person))
                        {
                            WriteLine($"{"\t" + person.Name,-15} - " + money + " руб.");
                        }
                    }
                }
            }
        }
    }
}
