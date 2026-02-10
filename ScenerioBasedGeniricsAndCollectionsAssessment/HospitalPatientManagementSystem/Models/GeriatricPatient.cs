using System.Collections.Generic;

namespace HospitalPatientManagementSystem.Models
{
    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }

        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; } // 1–10

        public override string ToString()
            => $"{Name} (Senior, Mobility {MobilityScore})";
    }
}
