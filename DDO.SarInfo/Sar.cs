using System.Collections.Generic;
using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [ConnectionName("SarConnection")]
    [CollectionName("SarInfo")]
    public class Sar : Entity
    {
        public string RelatedToIA { get; set; }
        public List<ClosureCriterion> ClosureCriterions { get; set; }
        public string SignedDate { get; set; }
        public string ReviewDate { get; set; }
        public string ReconsiderDueInDate { get; set; }
        public string Explanation { get; set; }
        public string ProcatTitle { get; set; }
        public bool ShouldSerializeSignedDate() { return !string.IsNullOrWhiteSpace(SignedDate); }
        public bool ShouldSerializeReviewDate() { return !string.IsNullOrWhiteSpace(ReviewDate); }
        public bool ShouldSerializeReconsiderDueInDate() { return !string.IsNullOrWhiteSpace(ReconsiderDueInDate); }
        public bool ShouldSerializeExplanation() { return !string.IsNullOrWhiteSpace(Explanation); }
        public bool ShouldSerializeProcatTitle() { return !string.IsNullOrWhiteSpace(ProcatTitle); }
        public bool ShouldSerializeClosureCriterions() { return SerializeClosureCriterions(ClosureCriterions); }

        private bool SerializeClosureCriterions(List<ClosureCriterion> closureCriterions)
        {
            if (closureCriterions?.Count > 0)
            {
                return closureCriterions.TrueForAll(e => e.ShouldSerializeExemptionCodeId());
            }
            return false;
        }
    }
}
