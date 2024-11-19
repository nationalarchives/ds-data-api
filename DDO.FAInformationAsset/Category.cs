namespace TNA.DataDefinitionObjects
{
    public class Category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int CatID { get; set; }

        /// <summary>
        /// Category Description
        /// </summary>
        public string CatDesc { get; set; }

        /// <summary>
        /// SubCategory ID
        /// </summary>
        public int SubCatID { get; set; }

        /// <summary>
        /// SubCategory Description
        /// </summary>
        public string SubCatDesc { get; set; }

        #region ShouldSerialize... Methods

        public bool ShouldSerializeCatID()
        {
            return CatID != default(int);
        }

        public bool ShouldSerializeCatDesc()
        {
            return !string.IsNullOrEmpty(CatDesc);
        }

        public bool ShouldSerializeSubCatID()
        {
            return SubCatID != default(int);
        }

        public bool ShouldSerializeSubCatDesc()
        {
            return !string.IsNullOrEmpty(SubCatDesc);
        }

        #endregion ShouldSerialize... Methods
    }
}
