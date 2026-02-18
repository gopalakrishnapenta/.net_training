using System;

namespace SmartBank
{
    public class InvalidEx : Exception
    {
        public InvalidEx(string message) : base(message)
        {
        }
    }

    public class CreditRiskProcessor
    {
        public static bool validateCustomerDetails(
            int age,
            string employmentType,
            double monthlyIncome,
            double dues,
            int creditScore,
            int defaults)
        {
            if (age < 21 || age > 65)
                throw new InvalidEx("Invalid age");

            if (employmentType != "Salaried" && employmentType != "Self-Employed")
                throw new InvalidEx("Invalid employment type");

            if (monthlyIncome < 20000)
                throw new InvalidEx("Invalid monthly income");

            if (dues < 0)
                throw new InvalidEx("Invalid credit dues");

            if (creditScore < 300 || creditScore > 900)
                throw new InvalidEx("Invalid credit score");

            if (defaults < 0)
                throw new InvalidEx("Invalid default count");

            return true;
        }

        public static double CalCreditLimt(
            double monthlyIncome,
            double dues,
            int creditScore,
            int defaults)
        {
            double debtRatio = dues / (monthlyIncome * 12);

            if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
                return 50000;

            if ((creditScore >= 600 && creditScore <= 749) ||
                (defaults == 1 || defaults == 2))
                return 150000;

            if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
                return 300000;

            return 50000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();

                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter employment type: ");
                string employmentType = Console.ReadLine();

                Console.Write("Enter monthly income: ");
                double monthlyIncome = double.Parse(Console.ReadLine());

                Console.Write("Enter existing credit dues: ");
                double dues = double.Parse(Console.ReadLine());

                Console.Write("Enter credit score: ");
                int creditScore = int.Parse(Console.ReadLine());

                Console.Write("Enter number of loan defaults: ");
                int defaults = int.Parse(Console.ReadLine());

                CreditRiskProcessor.validateCustomerDetails(
                    age, employmentType, monthlyIncome, dues, creditScore, defaults);

                double creditLimit = CreditRiskProcessor.CalCreditLimt(
                    monthlyIncome, dues, creditScore, defaults);

                Console.WriteLine($"Customer Name: {name}");
                Console.WriteLine($"Approved Credit Limit: ₹{creditLimit}");
            }
            catch (InvalidEx ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input format");
            }
        }
    }
}
