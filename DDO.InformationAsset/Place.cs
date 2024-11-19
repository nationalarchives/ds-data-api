using System;

namespace TNA.DataDefinitionObjects
{
    public class Place
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        public string DispName { get; set; }

        /// <summary>
        /// Place Name
        /// </summary>
        public string PlN { get; set; }

        /// <summary>
        /// Parish SN
        /// </summary>
        public string Par { get; set; }

        /// <summary>
        /// Town ID
        /// </summary>
        public int TwnID { get; set; }

        /// <summary>
        /// Town name
        /// </summary>
        public string Twn { get; set; }

        /// <summary>
        /// County name
        /// </summary>
        public string Cnty { get; set; }

        /// <summary>
        /// County ID
        /// </summary>
        public int CntyID { get; set; }

        /// <summary>
        /// Old County ID
        /// </summary>
        public int OldCntyID { get; set; }

        /// <summary>
        /// Old County name
        /// </summary>
        public string OldCnty { get; set; }

        /// <summary>
        /// New County ID
        /// </summary>
        public int NewCntyID { get; set; }

        /// <summary>
        /// New County name
        /// </summary>
        public string NewCnty { get; set; }

        /// <summary>
        /// Country ID
        /// </summary>
        public int CtryID { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string Ctry { get; set; }

        /// <summary>
        /// Region name
        /// </summary>
        public string Reg { get; set; }

        /// <summary>
        /// Region ID
        /// </summary>
        public int RegID { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public int StDt { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public int EndDt { get; set; }

        /// <summary>
        /// Grid reference
        /// </summary>
        public string Grid { get; set; }

        /// <summary>
        /// Validation
        /// </summary>
        public string Val { get; set; }

        /// <summary>
        /// Location type
        /// </summary>
        public string LocType { get; set; }

        #region ShouldSerialize... methods

        /// <summary>
        /// Description
        /// </summary>
        public bool ShouldSerializeDesc() { return !String.IsNullOrWhiteSpace(Desc); }

        /// <summary>
        /// Display Name
        /// </summary>
        public bool ShouldSerializeDispName() { return !String.IsNullOrWhiteSpace(DispName); }

        /// <summary>
        /// Place Name
        /// </summary>
        public bool ShouldSerializePlN() { return !String.IsNullOrWhiteSpace(PlN); }

        /// <summary>
        /// Parish SN
        /// </summary>
        public bool ShouldSerializePar() { return !String.IsNullOrWhiteSpace(Par); }

        /// <summary>
        /// Town ID
        /// </summary>
        public bool ShouldSerializeTwnID() { return TwnID != default(int); }

        /// <summary>
        /// Town name
        /// </summary>
        public bool ShouldSerializeTwn() { return !String.IsNullOrWhiteSpace(Twn); }

        /// <summary>
        /// County name
        /// </summary>
        public bool ShouldSerializeCnty() { return !String.IsNullOrWhiteSpace(Cnty); }

        /// <summary>
        /// County ID
        /// </summary>
        public bool ShouldSerializeCntyID() { return CntyID != default(int); }

        /// <summary>
        /// Old County name
        /// </summary>
        public bool ShouldSerializeOldCnty() { return !String.IsNullOrWhiteSpace(OldCnty); }

        /// <summary>
        /// Old County ID
        /// </summary>
        public bool ShouldSerializeOldCntyID() { return OldCntyID != default(int); }

        /// <summary>
        /// New County name
        /// </summary>
        public bool ShouldSerializeNewCnty() { return !String.IsNullOrWhiteSpace(NewCnty); }

        /// <summary>
        /// New County ID
        /// </summary>
        public bool ShouldSerializeNewCntyID() { return NewCntyID != default(int); }

        /// <summary>
        /// Country name
        /// </summary>
        public bool ShouldSerializeCtry() { return !String.IsNullOrWhiteSpace(Ctry); }

        /// <summary>
        /// Country ID
        /// </summary>
        public bool ShouldSerializeCtryID() { return CtryID != default(int); }

        /// <summary>
        /// Region name
        /// </summary>
        public bool ShouldSerializeReg() { return !String.IsNullOrWhiteSpace(Reg); }

        /// <summary>
        /// Region ID
        /// </summary>
        public bool ShouldSerializeRegID() { return RegID != default(int); }

        /// <summary>
        /// Start date
        /// </summary>
        public bool ShouldSerializeStDt() { return StDt != default(int); }

        /// <summary>
        /// End date
        /// </summary>
        public bool ShouldSerializeEndDt() { return EndDt != default(int); }

        /// <summary>
        /// Grid reference
        /// </summary>
        public bool ShouldSerializeGrid() { return !String.IsNullOrWhiteSpace(Grid); }

        /// <summary>
        /// Validation
        /// </summary>
        public bool ShouldSerializeVal() { return !String.IsNullOrWhiteSpace(Val); }

        /// <summary>
        /// Location type
        /// </summary>
        public bool ShouldSerializeLocType() { return !String.IsNullOrWhiteSpace(LocType); }

        #endregion ShouldSerialize... methods
    }
}