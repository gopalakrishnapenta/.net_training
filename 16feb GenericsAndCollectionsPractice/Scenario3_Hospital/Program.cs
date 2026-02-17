using System;
using System.Collections.Generic;
using System.Linq;

namespace Scenario3_Hospital
{
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }

    public class PriorityQueue<T> where T : IPatient
    {
        private readonly SortedDictionary<int, Queue<T>> _queues = new();

        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentException("Invalid Priority");

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        public T Dequeue()
        {
            foreach (var q in _queues.OrderBy(x => x.Key))
                if (q.Value.Any())
                    return q.Value.Dequeue();

            throw new InvalidOperationException("Empty Queue");
        }
    }

    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public double Weight { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var queue = new PriorityQueue<PediatricPatient>();

            var p1 = new PediatricPatient { PatientId = 1, Name = "Child1", DateOfBirth = DateTime.Now.AddYears(-5), BloodType = BloodType.O };

            queue.Enqueue(p1, 1);
            var next = queue.Dequeue();

            Console.WriteLine("Next Patient: " + next.Name);
        }
    }
}
