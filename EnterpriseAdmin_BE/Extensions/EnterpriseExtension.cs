using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseAdmin_BE.Extensions
{
    public static class EnterpriseExtension
    {
        public static IEnumerable<ApiEnterprises> ToApiEnterprises(this IEnumerable<Enterprise> enterprises) =>
            enterprises?.Select(x => x.ToApiEnterprise()).ToArray() ?? Enumerable.Empty<ApiEnterprises>();

        public static ApiEnterprises ToApiEnterprise(this Enterprise enterprise)
        {
            if (enterprise == null) return null;

            return new()
            {
                id = enterprise.Id,
                Created_By = enterprise.CreatedBy,
                Created_Date = enterprise.CreatedDate,
                Modified_By = enterprise.ModifiedBy,
                Modified_Date = enterprise.ModifiedDate,
                Status = enterprise.Status,
                Address = enterprise.Address,
                Name = enterprise.Name,
                Phone = enterprise.Phone
            };
        }

        public static IEnumerable<Enterprise> ToEnterprises(this IEnumerable<ApiEnterprises> enterprises) =>
            enterprises?.Select(x => x.ToEnterprise()).ToArray() ?? Enumerable.Empty<Enterprise>();

        public static Enterprise ToEnterprise(this ApiEnterprises enterprise)
        {
            if (enterprise == null) return null;

            return new()
            {
                Id = enterprise.id,
                CreatedBy = enterprise.Created_By,
                CreatedDate = enterprise.Created_Date,
                ModifiedBy = enterprise.Modified_By,
                ModifiedDate = enterprise.Modified_Date,
                Status = enterprise.Status,
                Address = enterprise.Address,
                Name = enterprise.Name,
                Phone = enterprise.Phone
            };
        }
    }
}
