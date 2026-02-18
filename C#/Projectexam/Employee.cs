using System;
using System.Collections.Generic;
using System.Text;

namespace Projectexam
{
    /// <summary>
    /// Base abstract type for all employee-like roles (HOD, Examiner, etc.).
    /// Encapsulates common properties shared across employee subtypes.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Identifier for the employee record.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Display name of the employee.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Department name or code the employee belongs to.
        /// </summary>
        public string Department { get; set; }

        // Placeholder for role semantics if required later.
        //public abstract string Role { get; };
    }

}