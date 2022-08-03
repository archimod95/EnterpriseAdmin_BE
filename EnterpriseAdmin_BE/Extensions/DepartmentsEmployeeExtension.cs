using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Models;

namespace EnterpriseAdmin_BE.Extensions
{
    public static class DepartmentsEmployeeExtension
    {
        public static IEnumerable<ApiDepartmentsEmployee> ToApiDepartmentsEmployee(this IEnumerable<DepartmentsEmployee> departmentsEmployees) =>
          departmentsEmployees?.Select(x => x.ToApiDepartmentEmployee()).ToArray() ?? Enumerable.Empty<ApiDepartmentsEmployee>();

        public static ApiDepartmentsEmployee ToApiDepartmentEmployee(this DepartmentsEmployee departmentEmployee)
        {
            if (departmentEmployee == null) return null;

            return new()
            {
                Id = departmentEmployee.Id,
                CreatedBy = departmentEmployee.CreatedBy,
                CreatedDate = departmentEmployee.CreatedDate,
                ModifiedBy = departmentEmployee.ModifiedBy,
                ModifiedDate = departmentEmployee.ModifiedDate,
                Status = departmentEmployee.Status,
                IdDepartment = departmentEmployee.Id,
                IdEmployee = departmentEmployee.IdEmployee
            };
        }

        public static IEnumerable<DepartmentsEmployee> ToDepartmentsEmployee(this IEnumerable<ApiDepartmentsEmployee> departmentsEmployees) =>
            departmentsEmployees?.Select(x => x.ToDepartmentEmployee()).ToArray() ?? Enumerable.Empty<DepartmentsEmployee>();

        public static DepartmentsEmployee ToDepartmentEmployee(this ApiDepartmentsEmployee departmentEmployee)
        {
            if (departmentEmployee == null) return null;

            return new()
            {
                Id = departmentEmployee.Id,
                CreatedBy = departmentEmployee.CreatedBy,
                CreatedDate = departmentEmployee.CreatedDate,
                ModifiedBy = departmentEmployee.ModifiedBy,
                ModifiedDate = departmentEmployee.ModifiedDate,
                Status = departmentEmployee.Status,
                IdDepartment = departmentEmployee.Id,
                IdEmployee = departmentEmployee.IdEmployee
            };
        }
    }
}
