namespace TNA.DataDefinitionObjects
{
    /// <summary>
    /// Closure
    /// </summary>
    public class Clsr
    {
        /// <summary>
        /// Closure Type code
        /// <remarks>Enum value with Closure type corresponding code</remarks>
        /// </summary>
        public string CT { get; set; }

        /// <summary>
        /// Closure Code
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// Closure Status code

        /// </summary>
        public string CS { get; set; }

        /// <summary>
        /// Record Opening Date
        /// </summary>
        public string RecOpenD { get; set; }

        #region ShouldSerialize... methods

        /// <summary>
        /// Closure Type code
        /// </summary>
        public bool ShouldSerializeCT() { return !string.IsNullOrWhiteSpace(CT); }

        /// <summary>
        /// Closure Code
        /// </summary>
        public bool ShouldSerializeCC() { return !string.IsNullOrWhiteSpace(CC); }

        /// <summary>
        /// Closure Status
        /// </summary>
        public bool ShouldSerializeCS() { return !string.IsNullOrWhiteSpace(CS); }

        /// <summary>
        /// Record Opening Date
        /// </summary>
        public bool ShouldSerializeRecOpenD() { return !string.IsNullOrWhiteSpace(RecOpenD); }
        #endregion
    }
}
