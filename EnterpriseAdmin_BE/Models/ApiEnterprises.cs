namespace EnterpriseAdmin_BE.Models
{
    public class ApiEnterprises
    {
        public int id { get; set; }

        public string Created_By { get; set; }

        public DateTime? Created_Date { get; set; }

        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public bool Status { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
