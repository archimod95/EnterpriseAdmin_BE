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
    }
}
