using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Extensions;
using EnterpriseAdmin_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAdmin_BE.Core.Admin
{
    public partial class Core
    {
        public async static Task<IEnumerable<ApiDepartmentsEmployee>> getAllDepartmentsEmployeesAsync(IConfiguration configuration)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var departmentsEmployees = await context.DepartmentsEmployees
                                .AsNoTracking()
                                .OrderBy(x => x.Id)
                                .ToArrayAsync();

            return departmentsEmployees.ToApiDepartmentsEmployee();
        }

        public async static Task<bool> createDepartmentEmployeeAsync(IConfiguration configuration, ApiDepartmentsEmployee newDepartmentEmployee)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.DepartmentsEmployees.Add(newDepartmentEmployee.ToDepartmentEmployee());
                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> updateDepartmentEmployeeAsync(IConfiguration configuration, ApiDepartmentsEmployee modifiedDepartmentEmployee)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var departmentEmployee = context.DepartmentsEmployees.Where(x => x.Id == modifiedDepartmentEmployee.Id).FirstOrDefault();
                if (departmentEmployee != null)
                {
                    departmentEmployee.CreatedBy = modifiedDepartmentEmployee.CreatedBy;
                    departmentEmployee.CreatedDate = modifiedDepartmentEmployee.CreatedDate;
                    departmentEmployee.ModifiedBy = modifiedDepartmentEmployee.ModifiedBy;
                    departmentEmployee.ModifiedDate = modifiedDepartmentEmployee.ModifiedDate;
                    departmentEmployee.Status = modifiedDepartmentEmployee.Status;
                    departmentEmployee.IdDepartment = modifiedDepartmentEmployee.IdDepartment;
                    departmentEmployee.IdEmployee = modifiedDepartmentEmployee.IdEmployee;

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
