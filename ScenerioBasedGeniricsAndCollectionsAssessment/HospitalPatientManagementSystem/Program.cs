using System;
using HospitalPatientManagementSystem.Models;
using HospitalPatientManagementSystem.Services;
using HospitalPatientManagementSystem.Helpers;

class Program
{
    static void Main()
    {
        var queue = new PriorityQueue<IPatient>();

        var child1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Aarav",
            DateOfBirth = new DateTime(2018, 5, 12),
            BloodType = BloodType.O,
            Weight = 18,
            GuardianName = "Raj"
        };

        var senior1 = new GeriatricPatient
        {
            PatientId = 2,
            Name = "Mr. Sharma",
            DateOfBirth = new DateTime(1950, 3, 10),
            BloodType = BloodType.A,
            MobilityScore = 4
        };

        queue.Enqueue(child1, 2);
        queue.Enqueue(senior1, 1);

        Console.WriteLine($"Next patient: {queue.Peek()}");

        var record = new MedicalRecord<IPatient>(child1);
        record.AddDiagnosis("Viral Fever", DateTime.Today);
        record.AddTreatment("Paracetamol", DateTime.Today);

        var meds = new MedicationSystem<IPatient>();

        meds.PrescribeMedication(
            child1,
            "Paracetamol",
            p => p is PediatricPatient c && c.Weight >= 10
        );

        Console.WriteLine("Treatment history:");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key:d} - {t.Value}");
    }
}
