using System.Collections.Generic;
using System.Xml.Serialization;

namespace TNA.DataDefinitionObjects
{
    /// <summary>
    /// Person
    /// </summary>
    public class Prsn
    {
        /// <summary>
        /// PreTitle
        /// </summary>
        public string PreTtl { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string PTtl { get; set; }
        /// <summary>
        /// Sort Title
        /// </summary>
        public string SrtTtl { get; set; }
        /// <summary>
        /// Forenames
        /// </summary>
        public List<string> FN { get; set; }
        /// <summary>
        /// Surname
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// Sort name
        /// </summary>
        public string SrtName { get; set; }
        /// <summary>
        /// Epithet
        /// </summary>
        public string Epithet { get; set; }
        /// <summary>
        /// Birth date
        /// </summary>
        public int DoB { get; set; }
        /// <summary>
        /// Death date
        /// </summary>
        public int DoD { get; set; }
        /// <summary>
        /// Occupation
        /// </summary>
        public List<string> Occ { get; set; }

        #region ShouldSerialize... methods
        /// <summary>
        /// PreTitle
        /// </summary>
        public bool ShouldSerializePreTtl() { return !string.IsNullOrWhiteSpace(PreTtl); }
        /// <summary>
        /// Title
        /// </summary>
        public bool ShouldSerializePTtl() { return !string.IsNullOrWhiteSpace(PTtl); }
        /// <summary>
        /// Sort Title
        /// </summary>
        public bool ShouldSerializeSrtTtl() { return !string.IsNullOrWhiteSpace(SrtTtl); }
        /// <summary>
        /// Forenames
        /// </summary>
        public bool ShouldSerializeFN() { return FN != null && FN.Count > 0; }
        /// <summary>
        /// Surname
        /// </summary>
        public bool ShouldSerializeSN() { return !string.IsNullOrWhiteSpace(SN); }
        /// <summary>
        /// Sort name
        /// </summary>
        public bool ShouldSerializeSrtName() { return !string.IsNullOrWhiteSpace(SrtName); }
        /// <summary>
        /// Epithet
        /// </summary>
        public bool ShouldSerializeEpithet() { return !string.IsNullOrWhiteSpace(Epithet); }
        /// <summary>
        /// Birth date
        /// </summary>
        public bool ShouldSerializeDoB() { return DoB != default(int); }
        /// <summary>
        /// Death date
        /// </summary>
        public bool ShouldSerializeDoD() { return DoD != default(int); }
        /// <summary>
        /// Occupation
        /// </summary>
        public bool ShouldSerializeOcc() { return Occ != null && Occ.Count > 0; }
        #endregion
    }
}
