using System;
using BankAccountSecurity;
namespace BankAccountSecurity
{
    public class Program
    {
        public static void Main(){
        BankAccount gopi = new BankAccount();
        gopi.Deposit(5000);
        gopi.Withdraw(2000);
        Console.WriteLine(gopi.getBalance());

    }
    }
}