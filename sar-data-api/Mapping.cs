using sar_data_api.Models;
using TNA.DataDefinitionObjects;

namespace sar_data_api;

public static class Mapping
{
    public static Sar ToSar(this SarInfoModel src)
    {
        if (src == null) return null;

        return new Sar
        {
            RelatedToIA = src.Iaid,
            SignedDate = src.SignedDate,
            ReviewDate = src.ReviewDate,
            ReconsiderDueInDate = src.ReconsiderDueInDate,
            Explanation = src.Explanation,
            ProcatTitle = src.ProcatTitle,
            ClosureCriterions = src.ClosureCriterions.Select(x => new ClosureCriterion { ExemptionCodeId = x.ExemptionCodeId }).ToList()
        };
    }

    public static SarInfoDisplayModel ToSarInfoDisplayModel(this Sar src, List<ClosureCriterions> closureCriterions)
    {
        if (src == null) return null;

        var model = new SarInfoDisplayModel
        {
            Iaid = src.RelatedToIA,
            SignedDate = src.SignedDate,
            ReviewDate = src.ReviewDate,
            ReconsiderDueInDate = src.ReconsiderDueInDate,
            Explanation = src.Explanation,
            ProcatTitle = src.ProcatTitle,
            ClosureCriterions = src.ClosureCriterions.Select(x => new ClosureCriterionDisplayModel { ExemptionCodeId = x.ExemptionCodeId }).ToList()
        };
        foreach (var item in model.ClosureCriterions)
        {
            item.ExemptionCodeDescription = closureCriterions?.FirstOrDefault(y => y.Code == item.ExemptionCodeId)?.Description;
        }
        return model;
    }
}