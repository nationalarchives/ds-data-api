namespace TNA.DataDefinitionObjects
{
    public class Rls
    {
        /// <summary>
        /// FAID
        /// </summary>
        public int FAID { get; set; }

        /// <summary>
        /// AuthorityName
        /// </summary>
        public string AuthN { get; set; }

        /// <summary>
        /// Relationship Category
        /// </summary>
        public string RlsCat { get; set; }

        /// <summary>
        /// Relationship Description
        /// </summary>
        public string RlsDesc { get; set; }

        /// <summary>
        /// Relationship Dates
        /// </summary>
        public string RlsDates { get; set; }

        #region ShouldSerialize... Methods

        public bool ShouldSerializeFAID()
        {
            return FAID != default(int);
        }

        public bool ShouldSerializeAuthN()
        {
            return !string.IsNullOrEmpty(AuthN);
        }

        public bool ShouldSerializeRlsCat()
        {
            return !string.IsNullOrEmpty(RlsCat);
        }

        public bool ShouldSerializeRlsDesc()
        {
            return !string.IsNullOrEmpty(RlsDesc);
        }

        public bool ShouldSerializeRlsDates()
        {
            return !string.IsNullOrEmpty(RlsDates);
        }

        #endregion ShouldSerialize... Methods
    }
}
