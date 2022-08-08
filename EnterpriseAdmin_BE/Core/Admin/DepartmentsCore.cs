﻿using EnterpriseAdmin_BE.Data;
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
            var departments = from dp in context.Departments
                              join en in context.Enterprises on dp.IdEnterprise equals en.Id
                              select new ApiDepartments
                              {
                                  Id = dp.Id,
                                  Created_Date = dp.CreatedDate,
                                  Created_By = dp.CreatedBy,
                                  Modified_By = dp.ModifiedBy,
                                  Modified_Date = dp.ModifiedDate,
                                  Status = dp.Status,
                                  Description = dp.Description,
                                  Name = dp.Name,
                                  Phone = dp.Phone,
                                  IdEnterprise = en.Id,
                                  EnterpriseName = en.Name
                              };

            return departments;
        }

        public async static Task<ApiResponse> createDepartmentAsync(IConfiguration configuration, ApiDepartments newDepartment)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                newDepartment.Created_Date = DateTime.Now;
                newDepartment.Modified_Date = DateTime.Now;
                context.Departments.Add(newDepartment.ToDepartment());
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

        public async static Task<ApiResponse> updateDepartmentAsync(IConfiguration configuration, ApiDepartments modifiedDepartment)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                MySqlDbContext context = new MySqlDbContext(configuration);
                var department = context.Departments.Where(x => x.Id == modifiedDepartment.Id).FirstOrDefault();
                if (department != null)
                {
                    department.CreatedBy = modifiedDepartment.Created_By;
                    department.CreatedDate = modifiedDepartment.Created_Date;
                    department.ModifiedBy = modifiedDepartment.Modified_By;
                    department.ModifiedDate = DateTime.Now;
                    department.Status = modifiedDepartment.Status;
                    department.Description = modifiedDepartment.Description;
                    department.Name = modifiedDepartment.Name;
                    department.Phone = modifiedDepartment.Phone;
                    department.IdEnterprise = modifiedDepartment.IdEnterprise;

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

        public async static Task<ApiDepartments> getDepartmentByIdAsync(IConfiguration configuration, int id)
        {
            MySqlDbContext context = new MySqlDbContext(configuration);
            var department = await context.Departments
                                .AsNoTracking()
                                .Include(x => x.DepartmentsEmployees)
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();

            return department.ToApiDepartment();
        }
    }
}
