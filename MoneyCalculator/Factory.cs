using MoneyCalculator.Parsers;
using MoneyCalculator.Processors;
using MoneyCalculator.Recipients;
using MoneyCalculator.Senders;

namespace MoneyCalculator
{
    public static class Factory
    {
        public static Controller GetController()
        {
            return new Controller(GetDataRecipient(), GetProcessor(), GetDataSender());
        }

        private static IDataRecipient GetDataRecipient()
        {
            return new DataRecipient(GetParser());
        }

        private static IProcessor GetProcessor()
        {
            return new Processor();
        }

        private static IDataSender GetDataSender()
        {
            return new DataSender();
        }

        private static IParser GetParser()
        {
            return new Parser();
        }
    }
}
