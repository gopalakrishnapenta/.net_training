using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenario4_Trading
{
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; }
    }

    public class Portfolio<T> where T : IFinancialInstrument
    {
        private readonly Dictionary<T, int> _holdings = new();

        public void Buy(T instrument, int quantity)
        {
            if (!_holdings.ContainsKey(instrument))
                _holdings[instrument] = 0;

            _holdings[instrument] += quantity;
        }

        public decimal CalculateTotalValue()
            => _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public class Stock : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var portfolio = new Portfolio<Stock>();

            var s1 = new Stock { Symbol = "TCS", CurrentPrice = 3500 };
            portfolio.Buy(s1, 10);

            Console.WriteLine("Portfolio Value: " + portfolio.CalculateTotalValue());
        }
    }
}
