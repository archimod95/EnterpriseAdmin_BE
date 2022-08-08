namespace EnterpriseAdmin_BE.Models
{
    public class ApiEmployees
    {
        public int Id { get; set; }

        public string Created_By { get; set; }

        public DateTime? Created_Date { get; set; }

        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public bool Status { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Surname { get; set; }

        public int? idDepartment { get; set; } 
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
