using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Recipients
{
    public class InputData
    {
        public List<Expenses> Expenses { get; private set; }

        public InputData(List<Expenses> expenses)
        {
            Expenses = expenses;
        }
    }
}
