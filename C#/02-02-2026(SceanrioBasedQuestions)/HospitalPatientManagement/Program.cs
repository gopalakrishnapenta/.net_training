using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement
{
    // Patient class
    class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }
        public List<string> MedicalHistory { get; set; }

        public Patient()
        {
            MedicalHistory = new List<string>();
        }
    }

    // Doctor class
    class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<DateTime> AvailableSlots { get; set; }

        public Doctor()
        {
            AvailableSlots = new List<DateTime>();
        }
    }

    // Appointment class
    class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; } // Scheduled / Completed / Cancelled
    }

    // HospitalManager class
    class HospitalManager
    {
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();

        private int patientIdCounter = 1;
        private int doctorIdCounter = 1;
        private int appointmentIdCounter = 1;

        // Add patient
        public void AddPatient(string name, int age, string bloodGroup)
        {
            Patient patient = new Patient
            {
                PatientId = patientIdCounter++,
                Name = name,
                Age = age,
                BloodGroup = bloodGroup
            };

            patients.Add(patient);
            Console.WriteLine("Patient added successfully");
        }

        // Add doctor
        public void AddDoctor(string name, string specialization)
        {
            Doctor doctor = new Doctor
            {
                DoctorId = doctorIdCounter++,
                Name = name,
                Specialization = specialization
            };

            doctors.Add(doctor);
            Console.WriteLine("Doctor added successfully");
        }

        // Schedule appointment
        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            Patient patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);

            if (patient == null || doctor == null)
                return false;

            Appointment appointment = new Appointment
            {
                AppointmentId = appointmentIdCounter++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            };

            appointments.Add(appointment);
            return true;
        }

        // Group doctors by specialization
        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(d => d.Specialization)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get today’s appointments
        public List<Appointment> GetTodayAppointments()
        {
            DateTime today = DateTime.Today;

            return appointments
                .Where(a => a.AppointmentTime.Date == today)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            HospitalManager manager = new HospitalManager();

            // Register patients
            manager.AddPatient("Ravi", 30, "O+");
            manager.AddPatient("Anita", 25, "A+");

            // Register doctors
            manager.AddDoctor("Dr. Sharma", "Cardiology");
            manager.AddDoctor("Dr. Meena", "Neurology");

            // Schedule appointments
            bool status = manager.ScheduleAppointment(1, 1, DateTime.Now);
            Console.WriteLine("Appointment Scheduled: " + status);

            // View doctors by specialization
            Console.WriteLine("\nDoctors Grouped By Specialization:");
            var groupedDoctors = manager.GroupDoctorsBySpecialization();
            foreach (var group in groupedDoctors)
            {
                Console.WriteLine(group.Key);
                foreach (var doctor in group.Value)
                    Console.WriteLine(doctor.Name);
            }

            // View today's appointments
            Console.WriteLine("\nToday's Appointments:");
            var todayAppointments = manager.GetTodayAppointments();
            foreach (var appt in todayAppointments)
                Console.WriteLine("Appointment ID: " + appt.AppointmentId +
                                  " Doctor ID: " + appt.DoctorId +
                                  " Patient ID: " + appt.PatientId);
        }
    }
}
