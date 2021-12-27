using MoneyCalculator.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Senders
{
    public interface IDataSender
    {
        public void SendData(OutputData outputData);
    }
}
