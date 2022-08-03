namespace EnterpriseAdmin_BE.Models
{
    public class ApiDepartments
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public string? Description { get; set; }

        public string? Name { get; set; }

        public string Phone { get; set; }

        public int? IdEnterprise { get; set; }
    }
}
