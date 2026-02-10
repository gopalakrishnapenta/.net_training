using System;

namespace HospitalPatientManagementSystem.Models
{
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }
}
