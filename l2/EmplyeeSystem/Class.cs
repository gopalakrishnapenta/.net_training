using System;

namespace EmployeeSystem
{
    // Base class
    public class Employee
    {
        public int id;
        public string name;
        public int salary;
    
    public Employee(int id, string name, int salary)
        {
            this.id=id;
            this.name = name;
            this.salary = salary;

        }
        public virtual string getDetails()
        {
            return $"id id {id}, name is {name}, salary is {salary}";
        }
    }
    public class Developer : Employee
    {
        public string technology;
        public Developer(int id, string name, int salary, string technology) : base(id,name,salary)
        {
            this.technology = technology;
        }
        public override string getDetails()
        {
            return base.getDetails() + $", technology is {technology}"; 
        }        
    }
    public class Manager : Employee
    {
        public string teamsize;
        public Manager(int id, string name ,int salary, string teamsize) : base(id, name, salary)
        {
            this.teamsize = teamsize;
        }
        public virtual string getDetails()
        {
            return base.getDetails() + $", teamsize is {teamsize}";
        }
    }
}