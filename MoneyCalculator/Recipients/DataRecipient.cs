using MoneyCalculator.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

namespace MoneyCalculator.Recipients
{
    public class DataRecipient : IDataRecipient
    {
        private IParser _parser;

        public DataRecipient(IParser parser)
        {
            _parser = parser;
        }

        public InputData GetData()
        {
            var path = "d.txt";//GetPath();
            var lines = File.ReadAllLines(path);
            return _parser.Parse(lines);
        }

        private string GetPath()
        {
            Write("Enter path of txt file: ");
            return ReadLine();
        }
    }
}
