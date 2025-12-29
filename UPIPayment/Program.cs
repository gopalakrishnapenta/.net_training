namespace UPIPayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Payment u1 = new UpiPayment(5000, "gopalkrishnapenta@axl");
            u1.Pay();
            u1.PrintReciept();
        }
    }
}
