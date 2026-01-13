using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_15
{
    public class LinqExample
    {
        public LinqExample(string name)
        {
            string[] names = { "A", "B", "C", "D" };
            var findname = from item in names where item == name select item;
            if (findname != null)
            {
                Console.WriteLine($"Found name {name}");
            }
        }
        public void LinqEx(string name)
        {
            string[] names = { "Aman", "Ananth", "Indra", "Viswa", "Vardhan", "Gopi" };
            var findname = from item in names orderby item ascending select IsPalindrome(item);
            foreach(var items in names)
            {
                Console.WriteLine(items);
            }
        }
        public static bool IsPalindrome(string str)
        {
            int min = 0;
            int max = str.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = str[min];
                char b = str[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
    public class LinqMain
    {
        public static void Main(string[] args)
        {
            LinqExample linq = new LinqExample("C");

        }
    }
}
