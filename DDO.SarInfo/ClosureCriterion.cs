namespace TNA.DataDefinitionObjects
{
    public class ClosureCriterion
    {
        public string ExemptionCodeId { get; set; }
        public bool ShouldSerializeExemptionCodeId() { return !string.IsNullOrWhiteSpace(ExemptionCodeId); }
    }
}
