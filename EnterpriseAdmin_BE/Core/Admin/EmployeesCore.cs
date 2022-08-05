using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Extensions;
using EnterpriseAdmin_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAdmin_BE.Core.Admin
{
    public partial class Core
    {
        public async static Task<IEnumerable<ApiEmployees>> getAllEmployeesAsync(IConfiguration configuration)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var employees = await context.Employees
                                .AsNoTracking()
                                .OrderBy(x => x.Surname)
                                .ToArrayAsync();

            return employees.ToApiEmployees();
        }

        public async static Task<ApiResponse> createEmployeeAsync(IConfiguration configuration, ApiEmployees newEmployees)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.Employees.Add(newEmployees.ToEmployee());
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

        public async static Task<ApiResponse> updateEmployeeAsync(IConfiguration configuration, ApiEmployees modifiedEmployees)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var employees = context.Employees.Where(x => x.Id == modifiedEmployees.Id).FirstOrDefault();
                if (employees != null)
                {
                    employees.CreatedBy = modifiedEmployees.CreatedBy;
                    employees.CreatedDate = modifiedEmployees.CreatedDate;
                    employees.ModifiedBy = modifiedEmployees.ModifiedBy;
                    employees.ModifiedDate = modifiedEmployees.ModifiedDate;
                    employees.Status = modifiedEmployees.Status;
                    employees.Age = modifiedEmployees.Age;
                    employees.Email = modifiedEmployees.Email;
                    employees.Name = modifiedEmployees.Name;
                    employees.Position = modifiedEmployees.Position;
                    employees.Surname = modifiedEmployees.Surname;

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

        public async static Task<ApiEmployees> getEmployeeByEmailAsync(IConfiguration configuration, string email)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var employees = await context.Employees
                                .AsNoTracking()
                                .Where(x => x.Email == email)
                                .FirstOrDefaultAsync();

            return employees.ToApiEmployee();
        }

        public async static Task<ApiEmployees> getEmployeeByIdAsync(IConfiguration configuration, int id)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var employees = await context.Employees
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

            return employees.ToApiEmployee();
        }
    }
}
