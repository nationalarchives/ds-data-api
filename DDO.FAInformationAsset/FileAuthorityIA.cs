using System.Collections.Generic;
using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [ConnectionName("FAConnection")]
    [CollectionName("FAInformationAsset")]
    public class FileAuthorityIA : Entity
    {
        /// <summary>
        /// FA ID
        /// </summary>
        public string FAID { get; set; }

        /// <summary>
        /// FA Type
        /// </summary>
        public string FAType { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// SubjectType
        /// </summary>
        public string SubjType { get; set; }

        /// <summary>
        /// Places
        /// </summary>
        public List<Place> Places { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// PreTitle
        /// </summary>
        public string PreTtl { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Ttl { get; set; }

        /// <summary>
        /// Forenames
        /// </summary>
        public string Fnames { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Epithet
        /// </summary>
        public string Eptht { get; set; }

        /// <summary>
        /// Sort Title
        /// </summary>
        public string SrtTtl { get; set; }

        /// <summary>
        /// Sort Name
        /// </summary>
        public string SrtN { get; set; }

        /// <summary>
        /// Authority Name
        /// </summary>
        public string AuthN { get; set; }

        /// <summary>
        /// First Date
        /// </summary>
        public int FrstDate { get; set; }

        /// <summary>
        /// Last Date
        /// </summary>
        public int LstDate { get; set; }

        /// <summary>
        /// Dates
        /// </summary>
        public string Dates { get; set; }

        /// <summary>
        /// Is Authority Record
        /// </summary>
        public bool IsAuthRec { get; set; }

        /// <summary>
        /// Collections
        /// </summary>
        public List<Collection> Collections { get; set; }

        /// <summary>
        /// Corporate Number
        /// </summary>
        public string CorpNum { get; set; }

        /// <summary>
        /// Subject Title
        /// </summary>
        public string SubjTtl { get; set; }

        /// <summary>
        /// ISAAR Reference
        /// </summary>
        public string ISAARRef { get; set; }

        /// <summary>
        /// Former ISAAR Reference
        /// </summary>
        public string FISAARRef { get; set; }

        /// <summary>
        /// Legal Status
        /// </summary>
        public string LglStts { get; set; }

        /// <summary>
        /// Sources Of Authority
        /// </summary>
        public string SrsOfAuth { get; set; }

        /// <summary>
        /// History
        /// </summary>
        public string Hist { get; set; }

        /// <summary>
        /// Genealogy
        /// </summary>
        public string Gnlgy { get; set; }

        /// <summary>
        /// Historical Context
        /// </summary>
        public string HistCtxt { get; set; }

        /// <summary>
        /// Sources
        /// </summary>
        public string Srcs { get; set; }

        /// <summary>
        /// Functions Occupations Or Activities
        /// </summary>
        public string FncsOccsOrActs { get; set; }

        /// <summary>
        /// Name Form
        /// </summary>
        public string NFrm { get; set; }

        /// <summary>
        /// Biography History Links
        /// </summary>
        public List<Res> BiogHistLnks { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public List<Rls> Rlss { get; set; }

        /// <summary>
        /// Related Resources
        /// </summary>
        public List<Res> RelRess { get; set; }

        /// <summary>
        /// Corporate body Remit And Function
        /// </summary>
        public string RemAndFunc { get; set; }

        /// <summary>
        /// Corporate body validation text
        /// </summary>
        public string ValTxt { get; set; }

        /// <summary>
        /// Corporate body Variant text
        /// </summary>
        public string VarTxt { get; set; }

        /// <summary>
        /// Corporate body Jurisdiction text
        /// </summary>
        public string JurisdTxt { get; set; }

        /// <summary>
        /// Corporate body Is place of deposit
        /// </summary>
        public bool IsPlOfDep { get; set; }

        /// <summary>
        /// Corporate body National Place of Deposit Code
        /// </summary>
        public string NatPlOfDepCode { get; set; }

        /// <summary>
        /// Biography History
        /// </summary>
        public string BiogHist { get; set; }

        /// <summary>
        /// Browse Character
        /// </summary>
        public string BrwsC { get; set; }

        /// <summary>
        ///HMC Is Public
        /// </summary>
        public bool IsPblc { get; set; }

        #region ShouldSerialize... Methods

        /// <summary>
        /// FA ID
        /// </summary>
        public bool ShouldSerializeFAID() { return !string.IsNullOrWhiteSpace(FAID); }

        /// <summary>
        /// FA Type
        /// </summary>
        public bool ShouldSerializeFAType() { return !string.IsNullOrWhiteSpace(FAType); }

        /// <summary>
        /// Gender
        /// </summary>
        public bool ShouldSerializeGender() { return !string.IsNullOrWhiteSpace(Gender); }

        /// <summary>
        /// Places
        /// </summary>
        public bool ShouldSerializePlaces() { return Places != null && Places.Count > 0; }

        /// <summary>
        /// Categories
        /// </summary>
        public bool ShouldSerializeCategories() { return Categories != null && Categories.Count > 0; }

        /// <summary>
        /// PreTitle
        /// </summary>
        public bool ShouldSerializePreTtl() { return !string.IsNullOrWhiteSpace(PreTtl); }

        /// <summary>
        /// Title
        /// </summary>
        public bool ShouldSerializeTtl() { return !string.IsNullOrWhiteSpace(Ttl); }

        /// <summary>
        /// Forenames
        /// </summary>
        public bool ShouldSerializeFnames() { return !string.IsNullOrWhiteSpace(Fnames); }

        /// <summary>
        /// Name
        /// </summary>
        public bool ShouldSerializeName() { return !string.IsNullOrWhiteSpace(Name); }

        /// <summary>
        /// Epithet
        /// </summary>
        public bool ShouldSerializeEptht() { return !string.IsNullOrWhiteSpace(Eptht); }

        /// <summary>
        /// Sort Title
        /// </summary>
        public bool ShouldSerializeSrtTtl() { return !string.IsNullOrWhiteSpace(SrtTtl); }

        /// <summary>
        /// Sort Name
        /// </summary>
        public bool ShouldSerializeSrtN() { return !string.IsNullOrWhiteSpace(SrtN); }

        /// <summary>
        /// Authority Name
        /// </summary>
        public bool ShouldSerializeAuthN() { return !string.IsNullOrWhiteSpace(AuthN); }

        /// <summary>
        /// First Date
        /// </summary>
        public bool ShouldSerializeFrstDate() { return FrstDate != default(int); }

        /// <summary>
        /// Last Date
        /// </summary>
        public bool ShouldSerializeLstDate() { return LstDate != default(int); }

        /// <summary>
        /// Dates
        /// </summary>
        public bool ShouldSerializeDates() { return !string.IsNullOrWhiteSpace(Dates); }

        /// <summary>
        /// Is Authority Record
        /// </summary>
        public bool ShouldSerializeIsAuthRec() { return IsAuthRec != default(bool); }

        /// <summary>
        /// Collections
        /// </summary>
        public bool ShouldSerializeCollections() { return Collections != null && Collections.Count > 0; }

        /// <summary>
        /// Corporate Number
        /// </summary>
        public bool ShouldSerializeCorpNum() { return !string.IsNullOrWhiteSpace(CorpNum); }

        /// <summary>
        /// Subject Title
        /// </summary>
        public bool ShouldSerializeSubjTtl() { return !string.IsNullOrWhiteSpace(SubjTtl); }

        /// <summary>
        /// ISAAR Reference
        /// </summary>
        public bool ShouldSerializeISAARRef() { return !string.IsNullOrWhiteSpace(ISAARRef); }

        /// <summary>
        /// Former ISAAR Reference
        /// </summary>
        public bool ShouldSerializeFISAARRef() { return !string.IsNullOrWhiteSpace(FISAARRef); }

        /// <summary>
        /// Legal Status
        /// </summary>
        public bool ShouldSerializeLglStts() { return !string.IsNullOrWhiteSpace(LglStts); }

        /// <summary>
        /// Sources Of Authority
        /// </summary>
        public bool ShouldSerializeSrsOfAuth() { return !string.IsNullOrWhiteSpace(SrsOfAuth); }

        /// <summary>
        /// History
        /// </summary>
        public bool ShouldSerializeHist() { return !string.IsNullOrWhiteSpace(Hist); }

        /// <summary>
        /// Genealogy
        /// </summary>
        public bool ShouldSerializeGnlgy() { return !string.IsNullOrWhiteSpace(Gnlgy); }

        /// <summary>
        /// Historical Context
        /// </summary>
        public bool ShouldSerializeHistCtxt() { return !string.IsNullOrWhiteSpace(HistCtxt); }

        /// <summary>
        /// Sources
        /// </summary>
        public bool ShouldSerializeSrcs() { return !string.IsNullOrWhiteSpace(Srcs); }

        /// <summary>
        /// Functions Occupations Or Activities
        /// </summary>
        public bool ShouldSerializeFncsOccsOrActs() { return !string.IsNullOrWhiteSpace(FncsOccsOrActs); }

        /// <summary>
        /// Name Form
        /// </summary>
        public bool ShouldSerializeNFrm() { return !string.IsNullOrWhiteSpace(NFrm); }

        /// <summary>
        /// Biography History Links
        /// </summary>
        public bool ShouldSerializeBiogHistLnks() { return BiogHistLnks != null && BiogHistLnks.Count > 0; }

        /// <summary>
        /// Relationships
        /// </summary>
        public bool ShouldSerializeRlss() { return Rlss != null && Rlss.Count > 0; }

        /// <summary>
        /// Related Resources
        /// </summary>
        public bool ShouldSerializeRelRess() { return RelRess != null && RelRess.Count > 0; }

        /// <summary>
        /// Corporate body Remit And Function
        /// </summary>
        public bool ShouldSerializeRemAndFunc() { return !string.IsNullOrWhiteSpace(RemAndFunc); }

        /// <summary>
        /// Corporate body validation txt
        /// </summary>
        public bool ShouldSerializeValTxt() { return !string.IsNullOrWhiteSpace(ValTxt); }

        /// <summary>
        /// Corporate body Variant text
        /// </summary>
        public bool ShouldSerializeVarTxt() { return !string.IsNullOrWhiteSpace(VarTxt); }

        /// <summary>
        /// Corporate body Jurisdiction text
        /// </summary>
        public bool ShouldSerializeJurisdTxt() { return !string.IsNullOrWhiteSpace(JurisdTxt); }

        /// <summary>
        /// Corporate body Is place of deposit
        /// </summary>
        public bool ShouldSerializeIsPlOfDep() { return IsPlOfDep != default(bool); }

        /// <summary>
        /// Corporate body National Place of Deposit Code
        /// </summary>
        public bool ShouldSerializeNatPlOfDepCode() { return !string.IsNullOrWhiteSpace(NatPlOfDepCode); }

        /// <summary>
        /// Biography History
        /// </summary>
        public bool ShouldSerializeBiogHist() { return !string.IsNullOrWhiteSpace(BiogHist); }

        /// <summary>
        /// Browse Character
        /// </summary>
        public bool ShouldSerializeBrwsC() { return !string.IsNullOrWhiteSpace(BrwsC); }

        #endregion ShouldSerialize... Methods
    }
}
