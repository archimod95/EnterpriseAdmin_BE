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

        public async static Task<bool> createEnterpriseAsync(IConfiguration configuration, ApiEnterprises newEnterprise)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                context.Enterprises.Add(newEnterprise.ToEnterprise());
                await context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static Task<bool> updateEnterpriseAsync(IConfiguration configuration, ApiEnterprises modifiedEnterprise)
        {
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var enterprise = context.Enterprises.Where(x => x.Id == modifiedEnterprise.id).FirstOrDefault();
                if (enterprise != null)
                {
                    enterprise.CreatedBy = modifiedEnterprise.Created_By;
                    enterprise.CreatedDate = modifiedEnterprise.Created_Date;
                    enterprise.ModifiedBy = modifiedEnterprise.Modified_By;
                    enterprise.ModifiedDate = modifiedEnterprise.Modified_Date;
                    enterprise.Status = modifiedEnterprise.Status;
                    enterprise.Address = modifiedEnterprise.Address;
                    enterprise.Phone = modifiedEnterprise.Phone;

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
