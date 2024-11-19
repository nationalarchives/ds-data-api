namespace TNA.DataDefinitionObjects
{
    public class Res
    {
        /// <summary>
        /// Resource Title
        /// </summary>
        public string ResTtl { get; set; }

        /// <summary>
        /// Resource Type
        /// </summary>
        public string ResTyp { get; set; }

        /// <summary>
        /// Resource Link
        /// </summary>
        public string ResLnk { get; set; }

        #region ShouldSerialize... Methods

        public bool ShouldSerializeResTtl()
        {
            return !string.IsNullOrEmpty(ResTtl);
        }

        public bool ShouldSerializeResLnk()
        {
            return !string.IsNullOrEmpty(ResLnk);
        }

        public bool ShouldSerializeResTyp()
        {
            return !string.IsNullOrEmpty(ResTyp);
        }

        #endregion ShouldSerialize... Methods
    }
}
