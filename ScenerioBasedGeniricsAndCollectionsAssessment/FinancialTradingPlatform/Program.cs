using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialTradingPlatform
{
    #region DOMAIN

    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; set; }
        InstrumentType Type { get; }
    }

    public enum InstrumentType
    {
        Stock,
        Bond,
        Option,
        Future
    }

    public enum Trend
    {
        Upward,
        Downward,
        Sideways
    }

    public class Stock : IFinancialInstrument
    {
        public required string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Stock;

        public required string CompanyName { get; set; }
        public decimal DividendYield { get; set; }

        public override string ToString() => $"{Symbol} ({CompanyName})";
    }

    public class Bond : IFinancialInstrument
    {
        public required string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Bond;

        public DateTime MaturityDate { get; set; }
        public decimal CouponRate { get; set; }

        public override string ToString() => $"{Symbol} (Bond)";
    }

    #endregion

    #region PORTFOLIO

    public class Portfolio<T> where T : IFinancialInstrument
    {
        private readonly Dictionary<T, int> _holdings = new();

        public IReadOnlyDictionary<T, int> Holdings => _holdings;

        public void Buy(T instrument, int quantity)
        {
            if (instrument == null)
                throw new ArgumentNullException(nameof(instrument));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (_holdings.ContainsKey(instrument))
                _holdings[instrument] += quantity;
            else
                _holdings[instrument] = quantity;
        }

        public decimal Sell(T instrument, int quantity)
        {
            if (!_holdings.ContainsKey(instrument))
                throw new InvalidOperationException("Instrument not in portfolio.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (_holdings[instrument] < quantity)
                throw new InvalidOperationException("Insufficient quantity.");

            _holdings[instrument] -= quantity;

            if (_holdings[instrument] == 0)
                _holdings.Remove(instrument);

            return quantity * instrument.CurrentPrice;
        }

        public decimal CalculateTotalValue()
        {
            return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
        }

        public (T instrument, decimal returnPercentage)? GetTopPerformer(
            Dictionary<T, decimal> purchasePrices)
        {
            if (purchasePrices == null || purchasePrices.Count == 0)
                return null;

            var performance = new List<(T, decimal)>();

            foreach (var holding in _holdings)
            {
                if (!purchasePrices.ContainsKey(holding.Key))
                    continue;

                var buyPrice = purchasePrices[holding.Key];
                var currentPrice = holding.Key.CurrentPrice;

                if (buyPrice == 0) continue;

                var returnPct = ((currentPrice - buyPrice) / buyPrice) * 100;
                performance.Add((holding.Key, returnPct));
            }

            return performance
                .OrderByDescending(p => p.Item2)
                .FirstOrDefault();
        }
    }

    #endregion

    #region TRADING STRATEGY

    public class TradingStrategy<T> where T : IFinancialInstrument
    {
        public void Execute(
            Portfolio<T> portfolio,
            IEnumerable<T> marketData,
            Func<T, bool> buyCondition,
            Func<T, bool> sellCondition)
        {
            foreach (var instrument in marketData)
            {
                if (buyCondition(instrument))
                {
                    portfolio.Buy(instrument, 10);
                }
                else if (sellCondition(instrument))
                {
                    if (portfolio.Holdings.ContainsKey(instrument))
                        portfolio.Sell(instrument, 5);
                }
            }
        }

        public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
        {
            var prices = instruments.Select(i => i.CurrentPrice).ToList();

            if (!prices.Any())
                return new Dictionary<string, decimal>();

            var avg = prices.Average();
            var variance = prices.Average(p => Math.Pow((double)(p - avg), 2));
            var volatility = (decimal)Math.Sqrt(variance);

            var sharpe = volatility == 0 ? 0 : avg / volatility;

            return new Dictionary<string, decimal>
            {
                { "Volatility", volatility },
                { "Beta", 1.0m }, // simplified
                { "SharpeRatio", sharpe }
            };
        }
    }

    #endregion

    #region PRICE HISTORY

    public class PriceHistory<T> where T : IFinancialInstrument
    {
        private readonly Dictionary<T, List<(DateTime time, decimal price)>> _history = new();

        public void AddPrice(T instrument, DateTime timestamp, decimal price)
        {
            if (!_history.ContainsKey(instrument))
                _history[instrument] = new List<(DateTime, decimal)>();

            _history[instrument].Add((timestamp, price));
        }

        public decimal? GetMovingAverage(T instrument, int days)
        {
            if (!_history.ContainsKey(instrument))
                return null;

            var recent = _history[instrument]
                .OrderByDescending(p => p.time)
                .Take(days)
                .Select(p => p.price)
                .ToList();

            return recent.Any() ? recent.Average() : null;
        }

        public Trend DetectTrend(T instrument, int period)
        {
            if (!_history.ContainsKey(instrument) ||
                _history[instrument].Count < period)
                return Trend.Sideways;

            var recent = _history[instrument]
                .OrderByDescending(p => p.time)
                .Take(period)
                .Select(p => p.price)
                .ToList();

            if (recent.First() > recent.Last())
                return Trend.Upward;

            if (recent.First() < recent.Last())
                return Trend.Downward;

            return Trend.Sideways;
        }
    }

    #endregion

    #region SIMULATION

    class Program
    {
        static void Main()
        {
            var apple = new Stock
            {
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                CurrentPrice = 150,
                DividendYield = 0.6m
            };

            var govBond = new Bond
            {
                Symbol = "GOVT10Y",
                CurrentPrice = 1000,
                CouponRate = 5,
                MaturityDate = DateTime.Now.AddYears(10)
            };

            var portfolio = new Portfolio<IFinancialInstrument>();

            portfolio.Buy(apple, 20);
            portfolio.Buy(govBond, 5);

            Console.WriteLine($"Initial Portfolio Value: {portfolio.CalculateTotalValue()}");

            // Simulate price changes
            apple.CurrentPrice = 170;
            govBond.CurrentPrice = 980;

            Console.WriteLine($"Updated Portfolio Value: {portfolio.CalculateTotalValue()}");

            var strategy = new TradingStrategy<IFinancialInstrument>();

            strategy.Execute(
                portfolio,
                new IFinancialInstrument[] { apple, govBond },
                buyCondition: i => i.CurrentPrice < 120,
                sellCondition: i => i.CurrentPrice > 160);

            Console.WriteLine($"After Strategy Value: {portfolio.CalculateTotalValue()}");

            var risk = strategy.CalculateRiskMetrics(
                new IFinancialInstrument[] { apple, govBond });

            Console.WriteLine("\nRisk Metrics:");
            foreach (var metric in risk)
                Console.WriteLine($"{metric.Key}: {metric.Value:F2}");

            var history = new PriceHistory<IFinancialInstrument>();

            history.AddPrice(apple, DateTime.Now.AddDays(-3), 140);
            history.AddPrice(apple, DateTime.Now.AddDays(-2), 150);
            history.AddPrice(apple, DateTime.Now.AddDays(-1), 170);

            Console.WriteLine($"\nMoving Average (3 days): {history.GetMovingAverage(apple, 3)}");
            Console.WriteLine($"Trend: {history.DetectTrend(apple, 3)}");

            var purchasePrices = new Dictionary<IFinancialInstrument, decimal>
            {
                { apple, 150 },
                { govBond, 1000 }
            };

            var top = portfolio.GetTopPerformer(purchasePrices);

            if (top.HasValue)
                Console.WriteLine($"\nTop Performer: {top.Value.instrument.Symbol} | Return: {top.Value.returnPercentage:F2}%");
        }
    }

    #endregion
}
