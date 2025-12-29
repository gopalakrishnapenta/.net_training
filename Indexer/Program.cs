namespace Indexer
{
    public class MyData
    {
        private string[] values = new string[3];

        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyData obj = new MyData();

            obj[0] = "C";
            obj[1] = "c++";
            obj[2] = "c#";

            Console.WriteLine("first one = " + obj[0]);
            Console.WriteLine("second one = " + obj[1]);
            Console.WriteLine("third one= " + obj[2]);
        }
    }
}
