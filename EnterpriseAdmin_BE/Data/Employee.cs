using System;
using System.Collections.Generic;

namespace EnterpriseAdmin_BE.Data
{
    public partial class Employee
    {
        public Employee()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployee>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; set; }
    }
}
