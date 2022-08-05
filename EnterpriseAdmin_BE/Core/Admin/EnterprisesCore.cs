using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Extensions;
using EnterpriseAdmin_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAdmin_BE.Core.Admin
{
    public partial class Core
    {
        public async static Task<IEnumerable<ApiEnterprises>> getAllEnterprisesAsync(IConfiguration configuration)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var enterprises = await context.Enterprises
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToArrayAsync();

            return enterprises.ToApiEnterprises();
        }

        public async static Task<ApiResponse> createEnterpriseAsync(IConfiguration configuration, ApiEnterprises newEnterprise)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                newEnterprise.Created_Date = DateTime.Now;
                newEnterprise.Modified_Date = DateTime.Now;
                context.Enterprises.Add(newEnterprise.ToEnterprise());
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

        public async static Task<ApiResponse> updateEnterpriseAsync(IConfiguration configuration, ApiEnterprises modifiedEnterprise)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var enterprise = context.Enterprises.Where(x => x.Id == modifiedEnterprise.id).FirstOrDefault();
                if (enterprise != null)
                {
                    enterprise.CreatedBy = modifiedEnterprise.Created_By;
                    enterprise.CreatedDate = modifiedEnterprise.Created_Date;
                    enterprise.ModifiedBy = modifiedEnterprise.Modified_By;
                    enterprise.ModifiedDate = DateTime.Now;
                    enterprise.Status = modifiedEnterprise.Status;
                    enterprise.Address = modifiedEnterprise.Address;
                    enterprise.Phone = modifiedEnterprise.Phone;

                    await context.SaveChangesAsync();

                    response.Success = true;
                    return response;
                }

                response.Success = true;
                return response;
            }
            catch
            {
                response.Success = true;
                return response;
            }
        }

        public async static Task<ApiEnterprises> getEnterpriseByIdAsync(IConfiguration configuration, int id)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var enterprises = await context.Enterprises
                                .AsNoTracking()
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

            return enterprises.ToApiEnterprise();
        }
    }
}
