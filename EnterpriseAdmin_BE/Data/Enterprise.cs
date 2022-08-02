using System;
using System.Collections.Generic;

namespace EnterpriseAdmin_BE.Data
{
    public partial class Enterprise
    {
        public Enterprise()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
    }
}
