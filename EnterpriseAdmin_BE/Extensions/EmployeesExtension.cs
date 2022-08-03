using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Models;

namespace EnterpriseAdmin_BE.Extensions
{
    public static class EmployeesExtension
    {
        public static IEnumerable<ApiEmployees> ToApiEmployees(this IEnumerable<Employee> employees) =>
          employees?.Select(x => x.ToApiEmployee()).ToArray() ?? Enumerable.Empty<ApiEmployees>();

        public static ApiEmployees ToApiEmployee(this Employee employee)
        {
            if (employee == null) return null;

            return new()
            {
                Id = employee.Id,
                CreatedBy = employee.CreatedBy,
                CreatedDate = employee.CreatedDate,
                ModifiedBy = employee.ModifiedBy,
                ModifiedDate = employee.ModifiedDate,
                Status = employee.Status,
                Age = employee.Age,
                Email = employee.Email,
                Name = employee.Name,
                Position = employee.Position,
                Surname = employee.Surname
            };
        }

        public static IEnumerable<Employee> ToEmployees(this IEnumerable<ApiEmployees> employees) =>
            employees?.Select(x => x.ToEmployee()).ToArray() ?? Enumerable.Empty<Employee>();

        public static Employee ToEmployee(this ApiEmployees employee)
        {
            if (employee == null) return null;

            return new()
            {
                Id = employee.Id,
                CreatedBy = employee.CreatedBy,
                CreatedDate = employee.CreatedDate,
                ModifiedBy = employee.ModifiedBy,
                ModifiedDate = employee.ModifiedDate,
                Status = employee.Status,
                Age = employee.Age,
                Email = employee.Email,
                Name = employee.Name,
                Position = employee.Position,
                Surname = employee.Surname
            };
        }
    }
}
