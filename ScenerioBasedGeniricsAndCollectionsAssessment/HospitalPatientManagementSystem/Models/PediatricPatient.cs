using System;

namespace HospitalPatientManagementSystem.Models
{
    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public string GuardianName { get; set; }
        public double Weight { get; set; } // kg

        public override string ToString()
            => $"{Name} (Child, {Weight}kg)";
    }
}
