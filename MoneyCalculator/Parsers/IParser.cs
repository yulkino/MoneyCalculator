using MoneyCalculator.Recipients;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Parsers
{
    public interface IParser
    {
        public InputData Parse(string[] lines);
    }
}
