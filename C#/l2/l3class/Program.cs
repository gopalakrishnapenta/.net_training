using System;
//This is the main class of the program
public class Lecture3
{
    //This is a nested (inner) class inside the main class
    public class details
    {
        //These are variables that store student information
       public string name;
       public int age;
       public int id;

       //Constructor to initialize the variables
       public details(string name,int age,int id)
        {
            //Assigns the parameter name to the class variable name
            this.name = name;
            this.age = age;
            this.id=id;
            
        } 
        //Method to get the details of the student
        public string getDetails()
        {
            return "Name: "+name+" Age: "+age+" Id: "+id;
        }
    }
    //Main method - entry point of the program
    public static void Main(String [] args)
    {
        //Creating an object of the nested class details
        details stu1 = new details("Gopi",20,12207176);
        Console.WriteLine(stu1.getDetails());
    }
}