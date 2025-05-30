﻿namespace sar_data_api.Models
{
    public class SarInfoDisplayModel
    {
        public string? Iaid { get; set; }
        public List<ClosureCriterionDisplayModel> ClosureCriterions { get; set; }
        public string? SignedDate { get; set; }
        public string? ReviewDate { get; set; }
        public string? ReconsiderDueInDate { get; set; }
        public string? Explanation { get; set; }
        public string? ProcatTitle { get; set; }
    }
}
