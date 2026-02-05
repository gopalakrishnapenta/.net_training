using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManagement
{
    // Member class
    class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MembershipType { get; set; } // Basic / Premium / Platinum
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    // FitnessClass class
    class FitnessClass
    {
        public string ClassName { get; set; }
        public string Instructor { get; set; }
        public DateTime Schedule { get; set; }
        public int MaxParticipants { get; set; }
        public List<string> RegisteredMembers { get; set; }

        public FitnessClass()
        {
            RegisteredMembers = new List<string>();
        }
    }

    // GymManager class
    class GymManager
    {
        private List<Member> members = new List<Member>();
        private List<FitnessClass> classes = new List<FitnessClass>();
        private int memberIdCounter = 1;

        // Creates membership with expiry date
        public void AddMember(string name, string membershipType, int months)
        {
            Member member = new Member
            {
                MemberId = memberIdCounter++,
                Name = name,
                MembershipType = membershipType,
                JoinDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(months)
            };

            members.Add(member);
            Console.WriteLine("Member added successfully");
        }

        public void AddClass(string className, string instructor,
                             DateTime schedule, int maxParticipants)
        {
            FitnessClass fitnessClass = new FitnessClass
            {
                ClassName = className,
                Instructor = instructor,
                Schedule = schedule,
                MaxParticipants = maxParticipants
            };

            classes.Add(fitnessClass);
            Console.WriteLine("Class added successfully");
        }

        // Registers member if class has space
        public bool RegisterForClass(int memberId, string className)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == memberId);
            FitnessClass fitnessClass =
                classes.FirstOrDefault(c => c.ClassName == className);

            if (member == null || fitnessClass == null)
                return false;

            if (member.ExpiryDate < DateTime.Now)
                return false;

            if (fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
                return false;

            fitnessClass.RegisteredMembers.Add(member.Name);
            return true;
        }

        // Groups members by their plan
        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            return members
                .GroupBy(m => m.MembershipType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Returns classes scheduled for next 7 days
        public List<FitnessClass> GetUpcomingClasses()
        {
            DateTime today = DateTime.Now;
            DateTime nextWeek = today.AddDays(7);

            return classes
                .Where(c => c.Schedule >= today && c.Schedule <= nextWeek)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            GymManager manager = new GymManager();

            manager.AddMember("Ravi", "Premium", 6);
            manager.AddMember("Anita", "Basic", 3);

            manager.AddClass("Yoga", "Suman", DateTime.Now.AddDays(3), 2);
            manager.AddClass("Zumba", "Rahul", DateTime.Now.AddDays(10), 5);

            bool status = manager.RegisterForClass(1, "Yoga");
            Console.WriteLine("Registration Status: " + status);

            Console.WriteLine("\nMembers Grouped By Membership Type:");
            var groupedMembers = manager.GroupMembersByMembershipType();
            foreach (var group in groupedMembers)
            {
                Console.WriteLine(group.Key);
                foreach (var member in group.Value)
                    Console.WriteLine(member.Name);
            }

            Console.WriteLine("\nUpcoming Classes (Next 7 Days):");
            var upcomingClasses = manager.GetUpcomingClasses();
            foreach (var cls in upcomingClasses)
                Console.WriteLine(cls.ClassName + " - " + cls.Schedule);
        }
    }
}
