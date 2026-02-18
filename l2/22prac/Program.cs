using System;
using System.ComponentModel.DataAnnotations;
using OopsSession;
namespace OopsSession
{
    public class Program
    {
        public static void Main(String [] args)
        {
            //Associate a1 = new Associate(6, "");
            //Associate a2 = new Associate(0, "gopi");
            //Console.WriteLine($"Associate Details: Id = {a1.Id}, Name = {a1.Name}");
            //Console.WriteLine($"Associate Details : ID = {a2.Id} Name = {a2.Name}");
            try
            {
                Associate a1 = new Associate(0, "");   
            }
            catch(InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // try
            // {
            //     Associate a2 = new Associate(0, "gopi");
            // }
            // catch(InvalidDataException ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
        }
    }
}