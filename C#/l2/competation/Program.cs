using System;
using System.Reflection.Metadata;
public class Program
{
    public class Employee
    {
        public int empid;
        public string empname;
    
    public Employee(int empid,string empname)
    {
        this.empid=empid;
        this.empname=empname;

    }
    public string getEmp()
    {
        return "Employee ID: "+empid+" Employee Name: "+empname;
    }
    }
    public class Competition
    {
        
        public int compid;
        public int compdate;
        public int winnerScore;
        public string empname;
    
    public Competition(int compid,int compdate)
    {

        this.compid=compid;
        this.compdate=compdate;
    }
    public string getComp()
    {
        return " Competition ID: "+compid+" Competition Date: "+compdate;
    }
    public void Winner(int winnerScore,string empname)
    {
        this.winnerScore=winnerScore;
        this.empname=empname;
    }
    
    public string getWinner()
        {
            return "Winner Name: "+empname+" Winner Score: "+winnerScore;
        }
    }
    public static void Main(String[] args)
    {
        Employee emp1 = new Employee(101,"Alice");
        Employee emp2 = new Employee(102,"Bob");
        Competition comp1 = new Competition(201,20240615);
        Competition comp2 = new Competition(202,20240720);
        comp1.Winner(95,"Alice");
        Console.WriteLine(emp1.getEmp());
        Console.WriteLine(comp1.getComp());
        Console.WriteLine(comp1.getWinner());
    }
}


