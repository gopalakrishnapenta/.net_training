using System;
using System.Data;
public class AdmissionEligibility
{
    public static void Main(String[] args)
    {
        Console.Write("Enter maths,physics,Chemistry marks: ");
        String input1 = Console.ReadLine();
        String input2 = Console.ReadLine();
        String input3 = Console.ReadLine();
        if(int.TryParse(input1, out int maths) && int.TryParse(input2 , out int physics) && int.TryParse(input3,out int chemistry))
        {
            int total = maths+physics+chemistry;
            if(maths >=65 && physics >=55 && chemistry >=50 && (total > 180 ||(maths+physics)> 140))
            {
                Console.WriteLine("You are eligible for admission. ");
            }
            else
            {
                Console.WriteLine("You are not eligible for admission. ");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter valid marks. ");
        }

    }
}