using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UPIPayment
{
    /// <summary>
    /// Represents a payment transaction with a specified amount. Serves as a base class for implementing specific
    /// payment methods.
    /// </summary>
    public abstract  class Payment
    {

        public decimal Amount { get; }
        protected Payment(decimal amount)
        {
            this.Amount = amount;
        }

        public void PrintReciept()
        {
            Console.WriteLine($"Reciept: {Amount}rupees.");
        }
 
        public abstract void Pay();

    }   
    /// <summary>
    /// Represents a payment made using the Unified Payments Interface (UPI) system.
    /// </summary>
    public class UpiPayment :Payment
    {

        public string UpiId { get; }
        public UpiPayment(decimal amount, string upiId) :base (amount)
        {
            this.UpiId = upiId;
        }
        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via UpiId: {UpiId}");

        }

    }
    
}
