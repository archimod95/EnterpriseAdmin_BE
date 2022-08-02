//using EnterpriseAdmin_BE.Data;
using EnterpriseAdmin_BE.Models;

namespace EnterpriseAdmin_BE.Extensions
{
    //public class EnterpriseExtension
    //{
    //    public static IEnumerable<ApiEnterprises> ToApiEnterprises(this IEnumerable<Enterprise> htafeeStructures) =>
    //        htafeeStructures?.Select(x => x.ToApiEnterprise()).ToArray() ?? Enumerable.Empty<ApiEnterprises>();

    //    public static ApiEnterprises ToApiEnterprise(this Enterprise enterprise)
    //    {
    //        if (enterprise == null) return null;

    //        return new()
    //        {
    //            id = enterprise.Id,
    //            Created_By = enterprise.createdBY
    //            Created_Date = enterprise.CreatedDate,
                
    //            Modified_By = enterprise.ModifiedBy,
    //            Modified_Date = enterprise.ModifiedDate,
    //            Status = enterprise.Status,
    //            Address = enterprise.Address,
    //            Name = enterprise.Name,
    //            Phone = enterprise.Phone
    //        };
    //    }

    //    public static IEnumerable<HtafeeStructure> ToHtaFeeStructures(this IEnumerable<DataHtaFeeStructure> htafeeStructures) =>
    //        htafeeStructures?.Select(x => x.ToHtaFeeStructure()).ToArray() ?? Enumerable.Empty<HtafeeStructure>();

    //    public static HtafeeStructure ToHtaFeeStructure(this DataHtaFeeStructure htafeeStructure)
    //    {
    //        if (htafeeStructure == null) return null;

    //        return new()
    //        {
    //            HtafeeStructureId = (Guid)htafeeStructure.HtafeeStructureId,
    //            HtafeeStructureName = htafeeStructure.HtafeeStructureName,
    //            HtafeeStructureTypeId = (Guid)htafeeStructure.HtafeeStructureTypeId,
    //            Days0to180 = htafeeStructure.Days0to180,
    //            Days181to270 = htafeeStructure.Days181to270,
    //            Days271to365 = htafeeStructure.Days271to365,
    //            Days366to545 = htafeeStructure.Days366to545,
    //            IsActive = htafeeStructure.IsActive
    //        };
    //    }
    //}
}
