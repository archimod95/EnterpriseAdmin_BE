namespace EnterpriseAdmin_BE.Models
{
    public class ApiDepartmentsEmployee
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public int? IdDepartment { get; set; }

        public int? IdEmployee { get; set; }
    }

    public class ApiDepartmentsEmployeeById
    {
        public int Id { get; set; }
    }
}
