using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCalculator.Recipients
{
    public interface IDataRecipient
    {
        public InputData GetData();
    }
}
