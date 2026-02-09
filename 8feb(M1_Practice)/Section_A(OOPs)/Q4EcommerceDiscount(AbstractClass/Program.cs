using System;

namespace ECommerceApp
{
    // Abstract base class
    public abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }

    // Festival discount
    public class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 5000)
                return amount - (amount * 0.10);
            else
                return amount - (amount * 0.05);
        }
    }

    // Member discount
    public class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 2000)
                return amount - 300;
            else
                return amount;
        }
    }

    // Program entry
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter purchase amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Choose discount (Festival / Member): ");
            string choice = Console.ReadLine();

            DiscountPolicy policy = null;

            if (choice == "Festival")
                policy = new FestivalDiscount();
            else if (choice == "Member")
                policy = new MemberDiscount();
            else
            {
                Console.WriteLine("Invalid discount type");
                return;
            }

            double finalAmount = policy.GetFinalAmount(amount);
            Console.WriteLine("Final Payable Amount: " + finalAmount);
        }
    }
}
