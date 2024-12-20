using System.Collections.Generic;
using System.Linq;
using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [ConnectionName("IAConnection")]
    [CollectionName("Records")]
    public class IA : Entity
    {
        private List<EntRef> _cpn;
        private List<EntRef> _cpi;
        private List<EntRef> _crn;
        private List<EntRef> _hb;
        private List<EntRef> _isa;
        private List<EntRef> _links;
        private List<EntRef> _locs;
        private List<EntRef> _rm;
        private List<EntRef> _sm;

        ///  <summary>
        ///  Accumulation Dates
        ///  </summary>
        public string AccDates { get; set; }

        /// <summary>
        /// Accruals
        /// </summary>
        public string Accrls { get; set; }

        /// <summary>
        /// Access Conditions
        /// </summary>
        public string AcsConds { get; set; }

        /// <summary>
        /// Administrative Background
        /// </summary>
        public string AdmBgr { get; set; }

        /// <summary>
        /// Appraisal Information
        /// </summary>
        public string ApprInfo { get; set; }

        /// <summary>
        /// Arrangement
        /// </summary>
        public string Arrmnt { get; set; }

        /// <summary>
        /// Batch Id
        /// </summary>
        public string BatchId { get; set; }

        /// <summary>
        /// Catalogue Browse Parent IAID
        /// </summary>
        /// <remarks>ID of a parent IA for browsing in Catalogue reference order</remarks>
        public string BRefIAID { get; set; }

        /// <summary>
        /// Catalogue Id
        /// </summary>
        public int CatId { get; set; }

        /// <summary>
        /// E-Document Id
        /// </summary>
        public string EDocId { get; set; }

        /// <summary>
        /// Charge Type
        /// </summary>
        public int ChgTy { get; set; }

        /// <summary>
        /// Covering From Date
        /// </summary>
        public int CFrmDt { get; set; }

        /// <summary>
        /// Closure data
        /// </summary>
        public Clsr Clsr { get; set; }

        /// <summary>
        /// Corporate Names
        /// </summary>
        public List<EntRef> CorpNs { get { return CleanUpEntities(_cpn); } set { _cpn = value; } }

        /// <summary>
        /// Covering Dates
        /// </summary>
        public string CovDts { get; set; }

        /// <summary>
        /// Copies Information
        /// </summary>
        public List<EntRef> CpsInfo { get { return CleanUpEntities(_cpi); } set { _cpi = value; } }

        /// <summary>
        /// Creator name
        /// </summary>
        public List<EntRef> CrtrNames { get { return CleanUpEntities(_crn); } set { _crn = value; } }

        /// <summary>
        /// Covering To Date
        /// </summary>
        public int CToDt { get; set; }

        /// <summary>
        /// Custodial History
        /// </summary>
        public string CustHist { get; set; }

        /// <summary>
        /// Digitised
        /// </summary>
        public bool Dgtsd { get; set; }

        /// <summary>
        /// Dimensions
        /// </summary>
        public string Dim { get; set; }

        /// <summary>
        /// Former Reference Dep
        /// </summary>
        public string FRefDep { get; set; }

        /// <summary>
        /// Former Reference Pro
        /// </summary>
        public string FRefPro { get; set; }

        /// <summary>
        /// Held By
        /// </summary>
        public List<EntRef> HeldBys { get { return CleanUpEntities(_hb); } set { _hb = value; } }

        /// <summary>
        /// Information Asset ID
        /// </summary>
        public string IAID { get; set; }

        /// <summary>
        /// Immediate Source Of Acquisition
        /// </summary>
        public List<EntRef> ImmSrcOfAcs { get { return CleanUpEntities(_isa); } set { _isa = value; } }

        /// <summary>
        /// Language
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// Legal status
        /// </summary>
        public string LglStts { get; set; }

        /// <summary>
        /// Links to other records
        /// </summary>
        public List<EntRef> Links { get { return CleanUpEntities(_links); } set { _links = value; } }

        /// <summary>
        /// Location Of Originals
        /// </summary>
        public List<EntRef> LocOfOrigs { get { return CleanUpEntities(_locs); } set { _locs = value; } }

        /// <summary>
        /// Source Level Id
        /// </summary>
        public int LvlId { get; set; }

        /// <summary>
        /// Map Designation
        /// </summary>
        public string MapDes { get; set; }

        /// <summary>
        /// Map Scale Number
        /// </summary>
        public int MapScNum { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Personal Names
        /// </summary>
        public List<Prsn> People { get; set; }

        /// <summary>
        /// Physical Condition
        /// </summary>
        public string PhysCond { get; set; }

        /// <summary>
        /// Physical Description Extent
        /// </summary>
        public string PhysDescExtnt { get; set; }

        /// <summary>
        /// Physical Description Form
        /// </summary>
        public string PhysDescFrm { get; set; }

        /// <summary>
        /// Parent IAID
        /// </summary>
        public string PIAID { get; set; }

        /// <summary>
        /// Places
        /// </summary>
        public List<Place> Places { get; set; }

        ///  <summary>
        /// Reference part
        ///  </summary>
        public string PRef { get; set; }

        /// <summary>
        /// Publication Notes
        /// </summary>
        public List<string> PublNotes { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string Ref { get; set; }

        /// moved to References
        ///  <summary>
        ///  Related Material
        ///  </summary>
        public List<EntRef> RelMats { get { return CleanUpEntities(_rm); } set { _rm = value; } }

        /// <summary>
        /// Registry Records
        /// </summary>
        public List<RegRecs> RRec { get; set; }

        /// <summary>
        /// Restriction On Use
        /// </summary>
        public string RstrOnUse { get; set; }

        /// <summary>
        /// Scope Content
        /// </summary>
        public SCont SC { get; set; }

        /// moved to References
        ///  <summary>
        ///  Separated Material
        ///  </summary>
        public List<EntRef> SepMats { get { return CleanUpEntities(_sm); } set { _sm = value; } }

        /// <summary>
        /// Source
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// Sort Key
        /// </summary>
        public string SrtKey { get; set; }

        /// <summary>
        /// Subjects
        /// </summary>
        public List<string> Subjects { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Ttl { get; set; }

        /// <summary>
        /// Unpublished Finding Aids
        /// </summary>
        public List<string> UnpFindAids { get; set; }

        /// <summary>
        /// Replica id
        /// </summary>
        public string RID { get; set; }

        public IA()
        {
            SC = new SCont();
            Clsr = new Clsr();
        }

        private List<EntRef> CleanUpEntities(List<EntRef> ents)
        {
            if (ents?.Count > 0)
            {
                var result = ents.Where(e => e.ShouldSerializeDesc()
                || e.ShouldSerializeEDate()
                || e.ShouldSerializeFN()
                || e.ShouldSerializePreTtl()
                || e.ShouldSerializePTtl()
                || e.ShouldSerializeSDate()
                || e.ShouldSerializeSN()
                || e.ShouldSerializeXRefC()
                || e.ShouldSerializeXRefD()
                || e.ShouldSerializeXRefId()
                || e.ShouldSerializeXRefN()
                || e.ShouldSerializeXRefSrt()
                || e.ShouldSerializeXRefT()
                || e.ShouldSerializeXRefURL());
                return result.ToList();
            }
            return null;
        }

        private bool SerializeEntity(List<EntRef> ents)
        {
            if (ents?.Count > 0)
            {
                return ents.TrueForAll(e => e.ShouldSerializeDesc()
                || e.ShouldSerializeEDate()
                || e.ShouldSerializeFN()
                || e.ShouldSerializePreTtl()
                || e.ShouldSerializePTtl()
                || e.ShouldSerializeSDate()
                || e.ShouldSerializeSN()
                || e.ShouldSerializeXRefC()
                || e.ShouldSerializeXRefD()
                || e.ShouldSerializeXRefId()
                || e.ShouldSerializeXRefN()
                || e.ShouldSerializeXRefSrt()
                || e.ShouldSerializeXRefT()
                || e.ShouldSerializeXRefURL());
            }

            return false;
        }

        /// <summary>
        /// Accumulation Dates
        /// </summary>
        public bool ShouldSerializeAccDates() { return !string.IsNullOrWhiteSpace(AccDates); }

        /// <summary>
        /// Accruals
        /// </summary>
        public bool ShouldSerializeAccrls() { return !string.IsNullOrWhiteSpace(Accrls); }

        /// <summary>
        /// Access Conditions
        /// </summary>
        public bool ShouldSerializeAcsConds() { return !string.IsNullOrWhiteSpace(AcsConds); }

        /// <summary>
        /// Administrative Background
        /// </summary>
        public bool ShouldSerializeAdmBgr() { return !string.IsNullOrWhiteSpace(AdmBgr); }

        /// <summary>
        /// Appraisal Information
        /// </summary>
        public bool ShouldSerializeApprInfo() { return !string.IsNullOrWhiteSpace(ApprInfo); }

        /// <summary>
        /// Arrangement
        /// </summary>
        public bool ShouldSerializeArrmnt() { return !string.IsNullOrWhiteSpace(Arrmnt); }

        /// <summary>
        /// Batch Id
        /// </summary>
        public bool ShouldSerializeBatchId() { return !string.IsNullOrWhiteSpace(BatchId); }

        /// <summary>
        /// Browse Parent IAID
        /// </summary>
        public bool ShouldSerializeBRefIAID() { return !string.IsNullOrWhiteSpace(BRefIAID); }

        /// <summary>
        /// Catalogue Id
        /// </summary>
        public bool ShouldSerializeCatId() { return CatId != default(int); }

        /// <summary>
        /// Catalogue Id
        /// </summary>
        public bool ShouldSerializeChgTy() { return ChgTy != default(int); }

        /// <summary>
        /// Batch Id
        /// </summary>
        public bool ShouldSerializeEDocId() { return !string.IsNullOrWhiteSpace(EDocId); }

        /// <summary>
        /// Covering From Date
        /// </summary>
        public bool ShouldSerializeCFrmDt() { return CFrmDt != default(int); }

        /// <summary>
        /// Closure Data
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeClsr()
        {
            return Clsr != null &&
                (Clsr.ShouldSerializeCC() ||
                 Clsr.ShouldSerializeCT() ||
                 Clsr.ShouldSerializeCS() ||
                 Clsr.ShouldSerializeRecOpenD());
        }

        /// <summary>
        /// Corporate Names
        /// </summary>
        public bool ShouldSerializeCorpNs() { return SerializeEntity(CorpNs); }

        /// <summary>
        /// Covering Dates
        /// </summary>
        public bool ShouldSerializeCovDts() { return !string.IsNullOrWhiteSpace(CovDts); }

        /// <summary>
        /// Copies Information
        /// </summary>
        public bool ShouldSerializeCpsInfo() { return SerializeEntity(CpsInfo); }

        /// <summary>
        /// Creator name
        /// </summary>
        public bool ShouldSerializeCrtrNames() { return SerializeEntity(CrtrNames); }

        /// <summary>
        /// Covering To Date
        /// </summary>
        public bool ShouldSerializeCToDt() { return CToDt != default(int); }

        /// <summary>
        /// Custodial History
        /// </summary>
        public bool ShouldSerializeCustHist() { return !string.IsNullOrWhiteSpace(CustHist); }

        /// <summary>
        /// Digitized
        /// </summary>
        public bool ShouldSerializeDgtsd() { return Dgtsd != default(bool); }

        /// <summary>
        /// Dimensions
        /// </summary>
        public bool ShouldSerializeDim() { return !string.IsNullOrWhiteSpace(Dim); }

        /// <summary>
        /// Former Reference Dep
        /// </summary>
        public bool ShouldSerializeFRefDep() { return !string.IsNullOrWhiteSpace(FRefDep); }

        /// <summary>
        /// Former Reference Pro
        /// </summary>
        public bool ShouldSerializeFRefPro() { return !string.IsNullOrWhiteSpace(FRefPro); }

        /// <summary>
        /// Held By
        /// </summary>
        public bool ShouldSerializeHeldBys() { return HeldBys?.Count > 0; }

        /// <summary>
        /// Immediate Source Of Acquisition
        /// </summary>
        public bool ShouldSerializeImmSrcOfAcs() { return SerializeEntity(ImmSrcOfAcs); }

        /// <summary>
        /// Language
        /// </summary>
        public bool ShouldSerializeLang() { return !string.IsNullOrWhiteSpace(Lang); }

        /// <summary>
        /// Legal status
        /// </summary>
        public bool ShouldSerializeLglStts() { return !string.IsNullOrWhiteSpace(LglStts); }

        /// <summary>
        /// Links to other records
        /// </summary>
        public bool ShouldSerializeLinks() { return Links?.Count > 0; }

        /// <summary>
        /// Location Of Originals
        /// </summary>
        public bool ShouldSerializeLocOfOrigs() { return SerializeEntity(LocOfOrigs); }

        /// <summary>
        /// Source Level Id
        /// </summary>
        public bool ShouldSerializeLvlId() { return LvlId != default(int); }

        /// <summary>
        /// Map Designation
        /// </summary>
        public bool ShouldSerializeMapDes() { return !string.IsNullOrWhiteSpace(MapDes); }

        /// <summary>
        /// Map Scale Number
        /// </summary>
        public bool ShouldSerializeMapScNum() { return MapScNum != default(int); }

        /// <summary>
        /// Note
        /// </summary>
        public bool ShouldSerializeNote() { return !string.IsNullOrWhiteSpace(Note); }

        /// <summary>
        /// Personal Names
        /// </summary>
        public bool ShouldSerializePeople() { return People != null && People.Count > 0; }

        /// <summary>
        /// Physical Condition
        /// </summary>
        public bool ShouldSerializePhysCond() { return !string.IsNullOrWhiteSpace(PhysCond); }

        /// <summary>
        /// Physical Description Extent
        /// </summary>
        public bool ShouldSerializePhysDescExtnt() { return !string.IsNullOrWhiteSpace(PhysDescExtnt); }

        /// <summary>
        /// Physical Description Form
        /// </summary>
        public bool ShouldSerializePhysDescFrm() { return !string.IsNullOrWhiteSpace(PhysDescFrm); }

        /// <summary>
        /// Parent IAID
        /// </summary>
        public bool ShouldSerializePIAID() { return !string.IsNullOrWhiteSpace(PIAID); }

        /// <summary>
        /// Places
        /// </summary>
        public bool ShouldSerializePlaces() { return Places != null && Places.Count > 0; }

        /// <summary>
        /// Catalogue reference
        /// </summary>
        public bool ShouldSerializePRef() { return !string.IsNullOrWhiteSpace(PRef); }

        /// <summary>
        /// Publication Notes
        /// </summary>
        public bool ShouldSerializePublNotes() { return PublNotes?.Count > 0; }

        /// <summary>
        /// Reference
        /// </summary>
        public bool ShouldSerializeRef() { return !string.IsNullOrWhiteSpace(Ref); }

        /// <summary>
        /// Related Material
        /// </summary>
        public bool ShouldSerializeRelMats() { return SerializeEntity(RelMats); }

        /// <summary>
        /// Registry Records
        /// </summary>
        public bool ShouldSerializeRRec() { return RRec?.Count > 0; }

        /// <summary>
        /// Restriction On Use
        /// </summary>
        public bool ShouldSerializeRstrOnUse() { return !string.IsNullOrWhiteSpace(RstrOnUse); }

        /// <summary>
        /// Scope Content
        /// </summary>
        public bool ShouldSerializeSC()
        {
            return SC != null &&
                (SC.ShouldSerializeDesc() ||
                SC.ShouldSerializeEph() ||
                SC.ShouldSerializeOrgs() ||
                SC.ShouldSerializePlcs() ||
                SC.ShouldSerializePple() ||
                SC.ShouldSerializeRefdToDate() ||
                SC.ShouldSerializeSchema());
        }

        /// <summary>
        /// Separated Material
        /// </summary>
        public bool ShouldSerializeSepMats() { return SerializeEntity(SepMats); }

        /// <summary>
        /// Source
        /// </summary>
        public bool ShouldSerializeSrc() { return !string.IsNullOrWhiteSpace(Src); }

        /// <summary>
        /// Sort Key
        /// </summary>
        public bool ShouldSerializeSrtKey() { return !string.IsNullOrWhiteSpace(SrtKey); }

        /// <summary>
        /// Subjects
        /// </summary>
        public bool ShouldSerializeSubjects() { return Subjects?.Count > 0; }

        /// <summary>
        /// Title
        /// </summary>
        public bool ShouldSerializeTtl() { return !string.IsNullOrWhiteSpace(Ttl); }

        /// <summary>
        /// Unpublished Finding Aids
        /// </summary>
        public bool ShouldSerializeUnpFindAids() { return UnpFindAids?.Count > 0; }

        /// <summary>
        /// Replica Id
        /// </summary>
        public bool ShouldSerializeRID() { return !string.IsNullOrWhiteSpace(RID); }
    }
}