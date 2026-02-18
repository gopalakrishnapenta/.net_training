using System;
using System.Collections.Generic;

namespace NumericAggregationStruct
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Sum(new List<int> { 1, 2, 3 }));
            Console.WriteLine(Sum(new List<double> { 1.5, 2.5 }));
        }

        public static T Sum<T>(IEnumerable<T> items) where T : struct
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            dynamic total = default(T);

            foreach (var item in items)
                total += (dynamic)item;

            return (T)total;
        }
    }
}