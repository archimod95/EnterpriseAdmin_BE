using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Models;

namespace EnterpriseAdmin_BE.Extensions
{
    public static class DepartmentsExtension
    {
        public static IEnumerable<ApiDepartments> ToApiDepartments(this IEnumerable<Department> departments) =>
          departments?.Select(x => x.ToApiDepartment()).ToArray() ?? Enumerable.Empty<ApiDepartments>();

        public static ApiDepartments ToApiDepartment(this Department department)
        {
            if (department == null) return null;

            return new()
            {
                Id = department.Id,
                Created_By = department.CreatedBy,
                Created_Date = department.CreatedDate,
                Modified_By = department.ModifiedBy,
                Modified_Date = department.ModifiedDate,
                Status = department.Status,
                Description = department.Description,
                Name = department.Name,
                Phone = department.Phone,
                IdEnterprise = department.IdEnterprise,
                EnterpriseName = department.IdEnterpriseNavigation?.Name
            };
        }

        public static IEnumerable<Department> ToDepartments(this IEnumerable<ApiDepartments> departments) =>
            departments?.Select(x => x.ToDepartment()).ToArray() ?? Enumerable.Empty<Department>();

        public static Department ToDepartment(this ApiDepartments department)
        {
            if (department == null) return null;

            return new()
            {
                Id = department.Id,
                CreatedBy = department.Created_By,
                CreatedDate = department.Created_Date,
                ModifiedBy = department.Modified_By,
                ModifiedDate = department.Modified_Date,
                Status = department.Status,
                Description = department.Description,
                Name = department.Name,
                Phone = department.Phone,
                IdEnterprise = department.IdEnterprise
            };
        }
    }
}
