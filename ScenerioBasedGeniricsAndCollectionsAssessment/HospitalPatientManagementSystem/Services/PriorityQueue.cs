using System;
using System.Collections.Generic;
using HospitalPatientManagementSystem.Models;

namespace HospitalPatientManagementSystem.Services
{
    public class PriorityQueue<T> where T : IPatient
    {
        private readonly SortedDictionary<int, Queue<T>> _queues = new();

        public void Enqueue(T patient, int priority)
        {
            if (priority < 1 || priority > 5)
                throw new ArgumentOutOfRangeException(nameof(priority));

            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        public T Dequeue()
        {
            foreach (var q in _queues)
            {
                if (q.Value.Count > 0)
                    return q.Value.Dequeue();
            }

            throw new InvalidOperationException("Queue is empty");
        }

        public T Peek()
        {
            foreach (var q in _queues)
            {
                if (q.Value.Count > 0)
                    return q.Value.Peek();
            }

            throw new InvalidOperationException("Queue is empty");
        }

        public int GetCountByPriority(int priority)
        {
            return _queues.ContainsKey(priority)
                ? _queues[priority].Count
                : 0;
        }
    }
}
