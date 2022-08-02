using System;
using System.Collections.Generic;

namespace EnterpriseAdmin_BE.Data
{
    public partial class DepartmentsEmployee
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdEmployee { get; set; }

        public virtual Department? IdDepartmentNavigation { get; set; }
        public virtual Employee? IdEmployeeNavigation { get; set; }
    }
}
