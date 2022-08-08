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
                Created_By = employee.CreatedBy,
                Created_Date = employee.CreatedDate,
                Modified_By = employee.ModifiedBy,
                Modified_Date = employee.ModifiedDate,
                Status = employee.Status,
                Age = employee.Age,
                Email = employee.Email,
                Name = employee.Name,
                Position = employee.Position,
                Surname = employee.Surname,
                idDepartment = employee.DepartmentsEmployees.Where(x => x.IdEmployee == employee.Id).Select(x=>x.IdDepartment).FirstOrDefault()
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
                CreatedBy = employee.Created_By,
                CreatedDate = employee.Created_Date,
                ModifiedBy = employee.Modified_By,
                ModifiedDate = employee.Modified_Date,
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
