using System;
using System.Collections.Generic;
using System.Text;
using MoneyCalculator.Parsers;
using MoneyCalculator.Recipients;
using MoneyCalculator.Senders;

namespace MoneyCalculator.Processors
{
    public class Controller
    {
        private IDataRecipient _dataRecipient;
        private IProcessor _processor;
        private IDataSender _dataSender;

        public Controller(IDataRecipient dataRecipient, IProcessor processor, IDataSender dataSender)
        {
            _dataRecipient = dataRecipient;
            _processor = processor;
            _dataSender = dataSender;
        }

        public void Start()
        {
            var inputData = _dataRecipient.GetData();
            var outputData = _processor.Process(inputData);
            _dataSender.SendData(outputData);

        }
    }
}
