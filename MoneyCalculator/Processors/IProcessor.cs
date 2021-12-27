using MoneyCalculator.Processors;
using MoneyCalculator.Recipients;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Processors
{
    public interface IProcessor
    {
        public OutputData Process(InputData inputData);
    }
}
