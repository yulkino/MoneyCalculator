using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Processors
{
    public class OutputData 
    {
        public List<PersonalDebts> PersonalDebts { get; private set; }

        public OutputData(List<PersonalDebts> personalDebts)
        {
            PersonalDebts = personalDebts;
        }
    }
}
