using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class Office
    {
        //Contains information about an office:
        //It's name, the code for the local currency and the exchange rate from USD to local currency.
        public Office(string name, string currencyCode, double exchangeRate)
        {
            Name = name;
            this.currencyCode = currencyCode;
            ExchangeRate = exchangeRate;
        }

        public string Name { get; set; }
        public string currencyCode { get; set; }
        public double ExchangeRate { get; set; }
    }
}
