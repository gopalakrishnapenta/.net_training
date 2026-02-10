using System;
using System.Collections.Generic;
using System.Linq;
using HospitalPatientManagementSystem.Models;

namespace HospitalPatientManagementSystem.Helpers
{
    public class MedicalRecord<T> where T : IPatient
    {
        private readonly T _patient;
        private readonly List<(DateTime date, string diagnosis)> _diagnoses = new();
        private readonly Dictionary<DateTime, string> _treatments = new();

        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            _diagnoses.Add((date, diagnosis));
        }

        public void AddTreatment(string treatment, DateTime date)
        {
            _treatments[date] = treatment;
        }

        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            return _treatments.OrderBy(t => t.Key);
        }
    }
}
