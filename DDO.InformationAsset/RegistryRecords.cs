using System;
using System.Collections.Generic;

namespace TNA.DataDefinitionObjects
{
    /// <summary>
    /// Registry Records
    /// </summary>
    public class RegRecs
    {
        /// <summary>
        /// NRAID
        /// </summary>
        public int NRAID { get; set; }
        /// <summary>
        /// Registry record title
        /// </summary>
        public string RRTtl { get; set; }
        /// <summary>
        /// RO Collection Reference
        /// </summary>
        public string ROColRef { get; set; }
        /// <summary>
        /// RO Accession number
        /// </summary>
        public string ROAccNo { get; set; }
        /// <summary>
        /// NRA Details
        /// </summary>
        public string NRAD { get; set; }
        /// <summary>
        /// Other Reference
        /// </summary>
        public string OthRef { get; set; }
        /// <summary>
        /// ISADG Reference
        /// </summary>
        public string ISADGRef { get; set; }
        /// <summary>
        /// Sort word
        /// </summary>
        public string SrtW { get; set; }
        /// <summary>
        /// Catalogue URL
        /// </summary>
        public string CURL { get; set; }
        /// <summary>
        /// Scanned Lists
        /// </summary>
        public List<XRef> SLists { get; set; }

        #region ShouldSerialize... methods
        /// <summary>
        /// NRAID
        /// </summary>
        public bool ShouldSerializeNRAID() { return NRAID != default(int); }
        /// <summary>
        /// RR title
        /// </summary>
        public bool ShouldSerializeRRTtl() { return !String.IsNullOrWhiteSpace(RRTtl); }
        /// <summary>
        /// ROColRef
        /// </summary>
        public bool ShouldSerializeROColRef() { return !String.IsNullOrWhiteSpace(ROColRef); }
        /// <summary>
        /// RO Accession number
        /// </summary>
        public bool ShouldSerializeROAccNo() { return !String.IsNullOrWhiteSpace(ROAccNo); }
        /// <summary>
        /// NRA Details
        /// </summary>
        public bool ShouldSerializeNRAD() { return !String.IsNullOrWhiteSpace(NRAD); }
        /// <summary>
        /// Other Reference
        /// </summary>
        public bool ShouldSerializeOthRef() { return !String.IsNullOrWhiteSpace(OthRef); }
        /// <summary>
        /// ISADG Reference
        /// </summary>
        public bool ShouldSerializeISADGRef() { return !String.IsNullOrWhiteSpace(ISADGRef); }
        /// <summary>
        /// Sort word
        /// </summary>
        public bool ShouldSerializeSrtW() { return !String.IsNullOrWhiteSpace(SrtW); }
        /// <summary>
        /// Catalogue URL
        /// </summary>
        public bool ShouldSerializeCURL() { return !String.IsNullOrWhiteSpace(CURL); }
        /// <summary>
        /// Scanned Lists
        /// </summary>
        public bool ShouldSerializeSLists() { return SLists != null && SLists.Count > 0; }
        #endregion
    }
}
