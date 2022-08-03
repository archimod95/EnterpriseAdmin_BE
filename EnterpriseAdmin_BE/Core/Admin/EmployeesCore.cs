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

        public async static Task<bool> createEmployeeAsync(IConfiguration configuration, ApiEmployees newEmployees)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.Employees.Add(newEmployees.ToEmployee());
                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> updateEmployeeAsync(IConfiguration configuration, ApiEmployees modifiedEmployees)
        {
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
