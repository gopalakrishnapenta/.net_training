using System;
using OopsSession;
using System.Data;
using System.Security.Principal;
namespace OopsSession
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Account acc1 = new Account{AccountId = 101, AccountName = "Gopi"};
            
            Console.WriteLine(acc1.getAccountDetails());

            SalesAccount salesAcc = new SalesAccount
            {
                AccountId = 201,
                AccountName = "Krishna",
                SalesInfo = "xyz",
            };
            Console.WriteLine(salesAcc.getSalesAccountDetails());

        }
    }
}