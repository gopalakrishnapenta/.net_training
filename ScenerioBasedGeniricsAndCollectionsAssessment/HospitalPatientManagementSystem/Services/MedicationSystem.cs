using System;
using System.Collections.Generic;
using System.Linq;
using HospitalPatientManagementSystem.Models;

namespace HospitalPatientManagementSystem.Services
{
    public class MedicationSystem<T> where T : IPatient
    {
        private readonly Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

        public void PrescribeMedication(
            T patient,
            string medication,
            Func<T, bool> dosageValidator)
        {
            if (!dosageValidator(patient))
                throw new InvalidOperationException("Dosage validation failed");

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<(string, DateTime)>();

            _medications[patient].Add((medication, DateTime.Now));
        }

        public bool CheckInteractions(T patient, string newMedication)
        {
            if (!_medications.ContainsKey(patient))
                return false;

            return _medications[patient]
                .Any(m => m.medication.Equals(newMedication, StringComparison.OrdinalIgnoreCase));
        }
    }
}
