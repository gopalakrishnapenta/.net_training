using System;
namespace OopsSession
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    
        public string getAccountDetails()
        {
             return $"Account Details: Id = {AccountId}, Name = {AccountName}";
        }
    }   
    public class SalesAccount : Account
    {
        public string SalesInfo{get; set;}
        public string getSalesAccountDetails()
        {
            return base.getAccountDetails() + $"SalesInfo = {SalesInfo}.{Environment.NewLine} This is a Sales Account.";
        }
    }
    public class  PurchaseAccount : Account
    {
        public string PurchaseInfo{get; set;}
        public string getPuechaseAccountDetails()
        {
            return base.getAccountDetails() + $"PurchaseInfo = {PurchaseInfo}.{Environment.NewLine} This is a Purchase Account.";
        }
    }
}