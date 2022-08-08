namespace EnterpriseAdmin_BE.Models
{
    public class ApiDepartments
    {
        public int Id { get; set; }

        public string Created_By { get; set; }

        public DateTime? Created_Date { get; set; }

        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public bool Status { get; set; }

        public string? Description { get; set; }

        public string? Name { get; set; }

        public string Phone { get; set; }

        public int? IdEnterprise { get; set; }

        public string? EnterpriseName { get; set; }
    }

    public class ApiDepartmentsById
    {
        public int Id { get; set; }
    }
}
