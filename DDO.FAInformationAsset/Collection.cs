namespace TNA.DataDefinitionObjects
{
    public class Collection
    {
        /// <summary>
        /// Related To IA
        /// </summary>
        public string RelToIA { get; set; }

        /// <summary>
        /// Repository IAID
        /// </summary>
        public string RepIA { get; set; }

        #region ShouldSerialize... Methods

        public bool ShouldSerializeRelToIA()
        {
            return !string.IsNullOrEmpty(RelToIA);
        }

        public bool ShouldSerializeRepIA()
        {
            return !string.IsNullOrEmpty(RepIA);
        }

        #endregion ShouldSerialize... Methods
    }
}
