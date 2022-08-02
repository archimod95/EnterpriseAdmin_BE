using System;
using System.Collections.Generic;

namespace EnterpriseAdmin_BE.Data
{
    public partial class Department
    {
        public Department()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployee>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public string Phone { get; set; } = null!;
        public int? IdEnterprise { get; set; }

        public virtual Enterprise? IdEnterpriseNavigation { get; set; }
        public virtual ICollection<DepartmentsEmployee> DepartmentsEmployees { get; set; }
    }
}
