using MoneyCalculator.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MoneyCalculator;

namespace XUnitTests
{
    public class OutputDataComparer
    {
        public bool IsEqual(OutputData expectedOutputData, OutputData actualOutputData)
        {
            foreach(var personalDebts in expectedOutputData.PersonalDebts)
            {
                foreach(var personMoneyPair in personalDebts.DebtToPay)
                {
                    if(actualOutputData.PersonalDebts.Any(x => x.Person.Equals(personalDebts.Person)))
                    {
                        DeleteCoincidence(actualOutputData, personalDebts, personMoneyPair);
                    }
                }
            }
            return IsEmpty(actualOutputData);
        }

        private void DeleteCoincidence(OutputData actualOutputData, PersonalDebts personalDebts, KeyValuePair<Person, decimal> personMoneyPair)
        {
            var personalDebt = actualOutputData.PersonalDebts.FirstOrDefault(x => x.Person.Equals(personalDebts.Person)).DebtToPay;
            if(personalDebt.Contains(personMoneyPair))
            {
                personalDebt.Remove(personMoneyPair.Key);
            }
        }

        private bool IsEmpty(OutputData actualOutputData)
        {
            var isEmpty = true;
            foreach(var debts in actualOutputData.PersonalDebts)
            {
                if (debts.DebtToPay.Any())
                    isEmpty = false;
            }
            return isEmpty;
        }
    }
}
