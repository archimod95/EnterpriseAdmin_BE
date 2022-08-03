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
                CreatedBy = department.CreatedBy,
                CreatedDate = department.CreatedDate,
                ModifiedBy = department.ModifiedBy,
                ModifiedDate = department.ModifiedDate,
                Status = department.Status,
                Description = department.Description,
                Name = department.Name,
                Phone = department.Phone,
                IdEnterprise = department.IdEnterprise
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
                CreatedBy = department.CreatedBy,
                CreatedDate = department.CreatedDate,
                ModifiedBy = department.ModifiedBy,
                ModifiedDate = department.ModifiedDate,
                Status = department.Status,
                Description = department.Description,
                Name = department.Name,
                Phone = department.Phone,
                IdEnterprise = department.IdEnterprise
            };
        }
    }
}
