namespace TNA.DataDefinitionObjects
{
    /// <summary>
    /// Entity reference
    /// </summary>
    public class EntRef : XRef
    {
        /// <summary>
        /// Reference description
        /// </summary>
        /// <remarks>Could be used as a narrative text before the reference </remarks>
        public string Desc { get; set; }

        /// <summary>
        /// PreTitle
        /// </summary>
        public string PreTtl { get; set; }

        /// <summary>
        /// Title (person)
        /// </summary>
        public string PTtl { get; set; }

        /// <summary>
        /// First name(s)
        /// </summary>
        public string FN { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string SN { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public int SDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public int EDate { get; set; }

        #region ShouldSerialize... methods

        /// <summary>
        /// Reference description
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeDesc()
        {
            return !string.IsNullOrWhiteSpace(Desc);
        }

        /// <summary>
        /// PreTitle
        /// </summary>
        public bool ShouldSerializePreTtl() { return !string.IsNullOrWhiteSpace(PreTtl); }

        /// <summary>
        /// Title
        /// </summary>
        public bool ShouldSerializePTtl() { return !string.IsNullOrWhiteSpace(PTtl); }

        /// <summary>
        /// Forenames
        /// </summary>
        public bool ShouldSerializeFN() { return !string.IsNullOrWhiteSpace(FN); }

        /// <summary>
        /// Surname
        /// </summary>
        public bool ShouldSerializeSN() { return !string.IsNullOrWhiteSpace(SN); }

        /// <summary>
        /// Birth date
        /// </summary>
        public bool ShouldSerializeSDate() { return SDate != default(int); }

        /// <summary>
        /// Death date
        /// </summary>
        public bool ShouldSerializeEDate() { return EDate != default(int); }

        #endregion ShouldSerialize... methods
    }

    /// <summary>
    /// Resources Cross reference
    /// </summary>
    /// <remarks>Used across several fields of the object as a
    /// reference to internal or external resources.</remarks>
    public class XRef
    {
        /// <summary>
        /// ID of referenced resource
        /// </summary>
        public string XRefId { get; set; }

        /// <summary>
        /// Resource code
        /// </summary>
        public string XRefC { get; set; }

        /// <summary>
        /// Resource name
        /// </summary>
        /// <remarks>Reference resource name. Could be used as a hyperlink text</remarks>
        public string XRefN { get; set; }

        /// <summary>
        /// Resource type
        /// </summary>
        public string XRefT { get; set; }

        /// <summary>
        /// Resource URL
        /// </summary>
        public string XRefURL { get; set; }

        /// <summary>
        /// Resource description
        /// </summary>
        /// <remarks>Reference resource textual description</remarks>
        public string XRefD { get; set; }

        /// <summary>
        /// Resource sort order
        /// </summary>
        public string XRefSrt { get; set; }

        #region ShouldSerialize... methods

        /// <summary>
        /// ID of referenced Resource
        /// </summary>
        public bool ShouldSerializeXRefId() { return !string.IsNullOrWhiteSpace(XRefId); }

        /// <summary>
        /// Resource code
        /// </summary>
        public bool ShouldSerializeXRefC() { return !string.IsNullOrWhiteSpace(XRefC); }

        /// <summary>
        /// Resource name
        /// </summary>
        public bool ShouldSerializeXRefN() { return !string.IsNullOrWhiteSpace(XRefN); }

        /// <summary>
        /// Resource type
        /// </summary>
        public bool ShouldSerializeXRefT() { return !string.IsNullOrWhiteSpace(XRefT); }

        /// <summary>
        /// Resource URL
        /// </summary>
        public bool ShouldSerializeXRefURL() { return !string.IsNullOrWhiteSpace(XRefURL); }

        /// <summary>
        /// Resource description
        /// </summary>
        public bool ShouldSerializeXRefD() { return !string.IsNullOrWhiteSpace(XRefD); }

        /// <summary>
        /// Resource sort order
        /// </summary>
        public bool ShouldSerializeXRefSrt() { return !string.IsNullOrWhiteSpace(XRefSrt); }

        #endregion ShouldSerialize... methods
    }
}