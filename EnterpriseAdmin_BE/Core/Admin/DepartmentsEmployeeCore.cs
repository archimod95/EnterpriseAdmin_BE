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
                                .Include(x => x.IdDepartmentNavigation)
                                .Include(x => x.IdEmployeeNavigation)
                                .OrderBy(x => x.Id)
                                .ToArrayAsync();

            return departmentsEmployees.ToApiDepartmentsEmployee();
        }

        public async static Task<ApiResponse> createDepartmentEmployeeAsync(IConfiguration configuration, ApiDepartmentsEmployee newDepartmentEmployee)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.DepartmentsEmployees.Add(newDepartmentEmployee.ToDepartmentEmployee());
                await context.SaveChangesAsync();

                response.Success = true;
                return response;
            }
            catch
            {
                response.Success = false;
                return response;
            }
        }

        public async static Task<ApiResponse> updateDepartmentEmployeeAsync(IConfiguration configuration, ApiDepartmentsEmployee modifiedDepartmentEmployee)
        {
            ApiResponse response = new ApiResponse();
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

                    response.Success = true;
                    return response;
                }

                response.Success = false;
                return response;
            }
            catch
            {
                response.Success = false;
                return response;
            }
        }

        public async static Task<ApiDepartmentsEmployee> getDeparmentsEmployeesByIdAsync(IConfiguration configuration, int id)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var departmentsEmployees = await context.DepartmentsEmployees
                                .AsNoTracking()
                                .Include(x => x.IdDepartmentNavigation)
                                .Include(x => x.IdEmployeeNavigation)
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

            return departmentsEmployees.ToApiDepartmentEmployee();
        }
    }
}
