using System.Collections.Generic;

namespace TNA.DataDefinitionObjects
{
    public class SCont
    {
        /// <summary>
        /// People
        /// </summary>
        public List<EntRef> Pple { get; set; }

        /// <summary>
        /// Places
        /// </summary>
        public List<EntRef> Plcs { get; set; }

        /// <summary>
        /// Referred to date
        /// </summary>
        public string RefdToDate { get; set; }

        /// <summary>
        /// Organizations
        /// </summary>
        public List<EntRef> Orgs { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Ephemera
        /// </summary>
        public string Eph { get; set; }

        /// <summary>
        /// Schema (DOL)
        /// </summary>
        public string Schema { get; set; }

        #region ShouldSerialize...

        /// <summary>
        /// People
        /// </summary>
        public bool ShouldSerializePple() { return Pple?.Count > 0; }

        /// <summary>
        /// Places
        /// </summary>
        public bool ShouldSerializePlcs() { return Plcs?.Count > 0; }

        /// <summary>
        /// Referred to date
        /// </summary>
        public bool ShouldSerializeRefdToDate() { return !string.IsNullOrWhiteSpace(RefdToDate); }

        /// <summary>
        /// Organizations
        /// </summary>
        public bool ShouldSerializeOrgs() { return Orgs?.Count > 0; }

        /// <summary>
        /// Description
        /// </summary>
        public bool ShouldSerializeDesc() { return !string.IsNullOrWhiteSpace(Desc); }

        /// <summary>
        /// Ephemera
        /// </summary>
        public bool ShouldSerializeEph() { return !string.IsNullOrWhiteSpace(Eph); }

        /// <summary>
        /// Schema (DOL)
        /// </summary>
        public bool ShouldSerializeSchema() { return !string.IsNullOrWhiteSpace(Schema); }

        #endregion ShouldSerialize...
    }
}