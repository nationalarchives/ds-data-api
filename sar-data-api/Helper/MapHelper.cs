using sar_data_api.Models;

namespace sar_data_api.Helper
{
    public static class MapHelper
    {
        public static SarInfoDisplayModel MapClosureCriterionDescription(this SarInfoDisplayModel model, List<ClosureCriterionDisplayModel> closureCriterions)
        {
            foreach (var item in model.ClosureCriterions)
            {
                item.ExemptionCodeDescription = closureCriterions?.FirstOrDefault(y => y.ExemptionCodeId == item.ExemptionCodeId)?.ExemptionCodeDescription;
            }
            return model;
        }
    }
}
