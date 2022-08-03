using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Extensions;
using EnterpriseAdmin_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAdmin_BE.Core.Admin
{
    public partial class Core
    {
        public async static Task<IEnumerable<ApiDepartments>> getAllDepartmentsAsync(IConfiguration configuration)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var departments = await context.Departments
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToArrayAsync();

            return departments.ToApiDepartments();
        }

        public async static Task<bool> createDepartmentAsync(IConfiguration configuration, ApiDepartments newDepartment)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.Departments.Add(newDepartment.ToDepartment());
                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> updateDepartmentAsync(IConfiguration configuration, ApiDepartments modifiedDepartment)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var department = context.Departments.Where(x => x.Id == modifiedDepartment.Id).FirstOrDefault();
                if (department != null)
                {
                    department.CreatedBy = modifiedDepartment.CreatedBy;
                    department.CreatedDate = modifiedDepartment.CreatedDate;
                    department.ModifiedBy = modifiedDepartment.ModifiedBy;
                    department.ModifiedDate = modifiedDepartment.ModifiedDate;
                    department.Status = modifiedDepartment.Status;
                    department.Description = modifiedDepartment.Description;
                    department.Name = modifiedDepartment.Name;
                    department.Phone = modifiedDepartment.Phone;
                    department.IdEnterprise = modifiedDepartment.IdEnterprise;

                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
