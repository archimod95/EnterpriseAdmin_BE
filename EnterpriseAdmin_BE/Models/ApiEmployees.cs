namespace EnterpriseAdmin_BE.Models
{
    public class ApiEmployees
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Status { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Surname { get; set; }
    }

    public class ApiEmployeeByEmail
    {
        public string Email { get; set; }
    }

    public class ApiEmployeeById
    {
        public int Id { get; set; }
    }

}
