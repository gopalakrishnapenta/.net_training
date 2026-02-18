using System;
using BankAccountSecurity;
namespace BankAccountSecurity
{
    public class BankAccount
    {
        private decimal balance;

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance+=amount;
                
            }

        }   
        public bool Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance-=amount;
                return true;
            }
            return false;            
        }
        public decimal getBalance()
        {
            return balance;
        }
    }
}