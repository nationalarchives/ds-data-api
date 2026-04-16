using ia_data_api.Models;
using TNA.DataDefinitionObjects;

namespace ia_data_api
{
    public static class Mapping
    {
        public static XRef ToXRef(this XReferenceModel src)
        {
            if (src == null) return null;

            return new XRef
            {
                XRefId = src.XReferenceId,
                XRefC = src.XReferenceCode,
                XRefN = src.XReferenceName,
                XRefT = src.XReferenceType,
                XRefURL = src.XReferenceURL,
                XRefD = src.XReferenceDescription,
                XRefSrt = src.XReferenceSortWord
            };
        }

        public static XReferenceModel ToXReferenceModel(this XRef src)
        {
            if (src == null) return null;

            return new XReferenceModel
            {
                XReferenceId = src.XRefId,
                XReferenceCode = src.XRefC,
                XReferenceName = src.XRefN,
                XReferenceType = src.XRefT,
                XReferenceURL = src.XRefURL,
                XReferenceDescription = src.XRefD,
                XReferenceSortWord = src.XRefSrt
            };
        }

        public static EntRef ToEntRef(this EntityReferenceModel src)
        {
            if (src == null) return null;

            return new EntRef
            {
                XRefId = src.XReferenceId,
                XRefC = src.XReferenceCode,
                XRefN = src.XReferenceName,
                XRefT = src.XReferenceType,
                XRefURL = src.XReferenceURL,
                XRefD = src.XReferenceDescription,
                XRefSrt = src.XReferenceSortWord,
                Desc = src.Description,
                PreTtl = src.PreTitle,
                PTtl = src.Title,
                FN = src.FirstName,
                SN = src.Surname,
                SDate = src.StartDate,
                EDate = src.EndDate
            };
        }

        public static EntityReferenceModel ToEntityReferenceModel(this EntRef src)
        {
            if (src == null) return null;

            return new EntityReferenceModel
            {
                XReferenceId = src.XRefId,
                XReferenceCode = src.XRefC,
                XReferenceName = src.XRefN,
                XReferenceType = src.XRefT,
                XReferenceURL = src.XRefURL,
                XReferenceDescription = src.XRefD,
                XReferenceSortWord = src.XRefSrt,
                Description = src.Desc,
                PreTitle = src.PreTtl,
                Title = src.PTtl,
                FirstName = src.FN,
                Surname = src.SN,
                StartDate = src.SDate,
                EndDate = src.EDate
            };
        }

        public static Prsn ToPrsn(this PersonModel src)
        {
            if (src == null) return null;

            return new Prsn
            {
                PreTtl = src.PreTitle,
                PTtl = src.Title,
                SrtTtl = src.SortTitle,
                FN = src.Forenames,
                SN = src.Surname,
                SrtName = src.SortName,
                Epithet = src.Epithet,
                DoB = src.DateOfBirth,
                DoD = src.DateOfDeath,
                Occ = src.Occupation
            };
        }

        public static PersonModel ToPersonModel(this Prsn src)
        {
            if (src == null) return null;

            return new PersonModel
            {
                PreTitle = src.PreTtl,
                Title = src.PTtl,
                SortTitle = src.SrtTtl,
                Forenames = src.FN,
                Surname = src.SN,
                SortName = src.SrtName,
                Epithet = src.Epithet,
                DateOfBirth = src.DoB,
                DateOfDeath = src.DoD,
                Occupation = src.Occ
            };
        }

        public static Place ToPlace(this PlaceModel src)
        {
            if (src == null) return null;

            return new Place
            {
                Desc = src.Description,
                DispName = src.DisplayName,
                PlN = src.PlaceName,
                Par = src.Parish,
                TwnID = src.TownID,
                Twn = src.Town,
                Cnty = src.County,
                CntyID = src.CountyID,
                OldCnty = src.OldCounty,
                OldCntyID = src.OldCountyID,
                NewCnty = src.NewCounty,
                NewCntyID = src.NewCountyID,
                CtryID = src.CountryID,
                Ctry = src.Country,
                Reg = src.Region,
                RegID = src.RegionID,
                StDt = src.StartDate,
                EndDt = src.EndDate,
                Grid = src.Grid,
                Val = src.Validation,
                LocType = src.LocationType
            };
        }

        public static PlaceModel ToPlaceModel(this Place src)
        {
            if (src == null) return null;

            return new PlaceModel
            {
                Description = src.Desc,
                DisplayName = src.DispName,
                PlaceName = src.PlN,
                Parish = src.Par,
                TownID = src.TwnID,
                Town = src.Twn,
                County = src.Cnty,
                CountyID = src.CntyID,
                OldCounty = src.OldCnty,
                OldCountyID = src.OldCntyID,
                NewCounty = src.NewCnty,
                NewCountyID = src.NewCntyID,
                CountryID = src.CtryID,
                Country = src.Ctry,
                Region = src.Reg,
                RegionID = src.RegID,
                StartDate = src.StDt,
                EndDate = src.EndDt,
                Grid = src.Grid,
                Validation = src.Val,
                LocationType = src.LocType
            };
        }

        public static SCont ToSCont(this ScopeContentModel src)
        {
            if (src == null) return null;

            return new SCont
            {
                Pple = src.PersonNames?.Select(x => x.ToEntRef()).ToList(),
                Plcs = src.PlaceNames?.Select(x => x.ToEntRef()).ToList(),
                RefdToDate = src.RefferedToDate,
                Orgs = src.Organizations?.Select(x => x.ToEntRef()).ToList(),
                Desc = src.Description,
                Eph = src.Ephemera,
                Schema = src.Schema
            };
        }

        public static ScopeContentModel ToScopeContentModel(this SCont src)
        {
            if (src == null) return null;

            return new ScopeContentModel
            {
                PersonNames = src.Pple?.Select(x => x.ToEntityReferenceModel()).ToList(),
                PlaceNames = src.Plcs?.Select(x => x.ToEntityReferenceModel()).ToList(),
                RefferedToDate = src.RefdToDate,
                Organizations = src.Orgs?.Select(x => x.ToEntityReferenceModel()).ToList(),
                Description = src.Desc,
                Ephemera = src.Eph,
                Schema = src.Schema
            };
        }

        public static RegRecs ToRegRecs(this RegistryRecordsModel src)
        {
            if (src == null) return null;

            return new RegRecs
            {
                NRAID = src.NRAID,
                RRTtl = src.RegistryRecordTitle,
                ROColRef = src.ROCollectionReference,
                ROAccNo = src.ROAccessionNumber,
                NRAD = src.NRADetails,
                OthRef = src.OtherReference,
                ISADGRef = src.ISADGReference,
                SrtW = src.SortWord,
                CURL = src.CatalogueURL,
                SLists = src.ScannedLists?.Select(x => x.ToXRef()).ToList()
            };
        }

        public static RegistryRecordsModel ToRegistryRecordsModel(this RegRecs src)
        {
            if (src == null) return null;

            return new RegistryRecordsModel
            {
                NRAID = src.NRAID,
                RegistryRecordTitle = src.RRTtl,
                ROCollectionReference = src.ROColRef,
                ROAccessionNumber = src.ROAccNo,
                NRADetails = src.NRAD,
                OtherReference = src.OthRef,
                ISADGReference = src.ISADGRef,
                SortWord = src.SrtW,
                CatalogueURL = src.CURL,
                ScannedLists = src.SLists?.Select(x => x.ToXReferenceModel()).ToList()
            };
        }

        public static IA ToIA(this InformationAssetModel src)
        {
            if (src == null) return null;

            return new IA
            {
                IAID = src.Iaid,
                RID = src.ReplicaId,
                Ref = src.CitableReference,
                PIAID = src.ParentId,
                AccDates = src.AccumulationDates,
                Accrls = src.Accruals,
                AcsConds = src.AccessConditions,
                AdmBgr = src.AdministrativeBackground,
                ApprInfo = src.AppraisalInformation,
                Arrmnt = src.Arrangement,
                BatchId = src.BatchId,
                BRefIAID = src.RefIaid,
                CatId = src.CatalogueId,
                EDocId = src.EDocumentId,
                ChgType = src.ChargeType,
                CFrmDt = src.CoveringFromDate,
                CorpNs = src.CorporateNames?.Select(x => x.ToEntRef()).ToList(),
                CovDts = src.CoveringDates,
                CpsInfo = src.CopiesInformation?.Select(x => x.ToEntRef()).ToList(),
                CrtrNames = src.CreatorName?.Select(x => x.ToEntRef()).ToList(),
                CToDt = src.CoveringToDate,
                CustHist = src.CustodialHistory,
                Clsr = new Clsr
                {
                    CT = src.ClosureType,
                    CC = src.ClosureCode,
                    CS = src.ClosureStatus,
                    RecOpenD = src.RecordOpeningDate
                },
                Dgtsd = src.Digitised,
                Dim = src.Dimensions,
                FRefDep = src.FormerReferenceDep,
                FRefPro = src.FormerReferencePro,
                HeldBys = src.HeldBy?.Select(x => x.ToEntRef()).ToList(),
                ImmSrcOfAcs = src.ImmediateSourceOfAcquisition?.Select(x => x.ToEntRef()).ToList(),
                Lang = src.Language,
                LglStts = src.LegalStatus,
                Links = src.Links?.Select(x => x.ToEntRef()).ToList(),
                LocOfOrigs = src.LocationOfOriginals?.Select(x => x.ToEntRef()).ToList(),
                LvlId = src.CatalogueLevel,
                MapDes = src.MapDesignation,
                MapScNum = src.MapScaleNumber,
                Note = src.Note,
                People = src.People?.Select(x => x.ToPrsn()).ToList(),
                PhysCond = src.PhysicalCondition,
                PhysDescExtnt = src.PhysicalDescriptionExtent,
                PhysDescFrm = src.PhysicalDescriptionForm,
                Places = src.Places?.Select(x => x.ToPlace()).ToList(),
                PRef = src.ReferencePart,
                PublNotes = src.PublicationNote,
                RelMats = src.RelatedMaterial?.Select(x => x.ToEntRef()).ToList(),
                RRec = src.RegistryRecords?.Select(x => x.ToRegRecs()).ToList(),
                RstrOnUse = src.RestrictionsOnUse,
                SC = src.ScopeContent?.ToSCont(),
                SepMats = src.SeparatedMaterial?.Select(x => x.ToEntRef()).ToList(),
                Src = src.Source,
                SrtKey = src.SortKey,
                Subjects = src.Subjects,
                Ttl = src.Title,
                UnpFindAids = src.UnpublishedFindingAids
            };
        }

        public static InformationAssetModel ToInformationAssetModel(this IA src)
        {
            if (src == null) return null;

            return new InformationAssetModel
            {
                Iaid = src.IAID,
                ReplicaId = src.RID,
                CitableReference = src.Ref,
                ParentId = src.PIAID,
                AccumulationDates = src.AccDates,
                Accruals = src.Accrls,
                AccessConditions = src.AcsConds,
                AdministrativeBackground = src.AdmBgr,
                AppraisalInformation = src.ApprInfo,
                Arrangement = src.Arrmnt,
                BatchId = src.BatchId,
                RefIaid = src.BRefIAID,
                CatalogueId = src.CatId,
                EDocumentId = src.EDocId,
                ChargeType = src.ChgType,
                CoveringFromDate = src.CFrmDt,
                CorporateNames = src.CorpNs?.Select(x => x.ToEntityReferenceModel()).ToList(),
                CoveringDates = src.CovDts,
                CopiesInformation = src.CpsInfo?.Select(x => x.ToEntityReferenceModel()).ToList(),
                CreatorName = src.CrtrNames?.Select(x => x.ToEntityReferenceModel()).ToList(),
                CoveringToDate = src.CToDt,
                CustodialHistory = src.CustHist,
                ClosureType = src.Clsr?.CT,
                ClosureCode = src.Clsr?.CC,
                ClosureStatus = src.Clsr?.CS,
                RecordOpeningDate = src.Clsr?.RecOpenD,
                Digitised = src.Dgtsd,
                Dimensions = src.Dim,
                FormerReferenceDep = src.FRefDep,
                FormerReferencePro = src.FRefPro,
                HeldBy = src.HeldBys?.Select(x => x.ToEntityReferenceModel()).ToList(),
                ImmediateSourceOfAcquisition = src.ImmSrcOfAcs?.Select(x => x.ToEntityReferenceModel()).ToList(),
                Language = src.Lang,
                LegalStatus = src.LglStts,
                Links = src.Links?.Select(x => x.ToEntityReferenceModel()).ToList(),
                LocationOfOriginals = src.LocOfOrigs?.Select(x => x.ToEntityReferenceModel()).ToList(),
                CatalogueLevel = src.LvlId,
                MapDesignation = src.MapDes,
                MapScaleNumber = src.MapScNum,
                Note = src.Note,
                People = src.People?.Select(x => x.ToPersonModel()).ToList(),
                PhysicalCondition = src.PhysCond,
                PhysicalDescriptionExtent = src.PhysDescExtnt,
                PhysicalDescriptionForm = src.PhysDescFrm,
                Places = src.Places?.Select(x => x.ToPlaceModel()).ToList(),
                ReferencePart = src.PRef,
                PublicationNote = src.PublNotes,
                RelatedMaterial = src.RelMats?.Select(x => x.ToEntityReferenceModel()).ToList(),
                RegistryRecords = src.RRec?.Select(x => x.ToRegistryRecordsModel()).ToList(),
                RestrictionsOnUse = src.RstrOnUse,
                ScopeContent = src.SC?.ToScopeContentModel(),
                SeparatedMaterial = src.SepMats?.Select(x => x.ToEntityReferenceModel()).ToList(),
                Source = src.Src,
                SortKey = src.SrtKey,
                Subjects = src.Subjects,
                Title = src.Ttl,
                UnpublishedFindingAids = src.UnpFindAids
            };
        }

        public static Category ToCategory(this CategoryModel src)
        {
            if (src == null) return null;

            return new Category
            {
                CatID = src.CatagoryId,
                CatDesc = src.CatagoryDescription,
                SubCatID = src.SubCatagoryId,
                SubCatDesc = src.SubCatagoryDescription
            };
        }

        public static CategoryModel ToCategoryModel(this Category src)
        {
            if (src == null) return null;

            return new CategoryModel
            {
                CatagoryId = src.CatID,
                CatagoryDescription = src.CatDesc,
                SubCatagoryId = src.SubCatID,
                SubCatagoryDescription = src.SubCatDesc
            };
        }

        public static Collection ToCollection(this CollectionModel src)
        {
            if (src == null) return null;

            return new Collection
            {
                RelToIA = src.RelatedToIa,
                RepIA = src.RepositoryIaId
            };
        }

        public static CollectionModel ToCollectionModel(this Collection src)
        {
            if (src == null) return null;

            return new CollectionModel
            {
                RelatedToIa = src.RelToIA,
                RepositoryIaId = src.RepIA
            };
        }

        public static Res ToRes(this ResourceModel src)
        {
            if (src == null) return null;

            return new Res
            {
                ResTtl = src.ResourceTitle,
                ResTyp = src.ResourceType,
                ResLnk = src.ResourceLink
            };
        }

        public static ResourceModel ToResourceModel(this Res src)
        {
            if (src == null) return null;

            return new ResourceModel
            {
                ResourceTitle = src.ResTtl,
                ResourceType = src.ResTyp,
                ResourceLink = src.ResLnk
            };
        }

        public static Rls ToRls(this RelationshipModel src)
        {
            if (src == null) return null;

            return new Rls
            {
                FAID = src.FaId,
                AuthN = src.AuthorityName,
                RlsCat = src.RelationshipCategory,
                RlsDesc = src.RelationshipDescription,
                RlsDates = src.RelationshipDates
            };
        }

        public static RelationshipModel ToRelationshipModel(this Rls src)
        {
            if (src == null) return null;

            return new RelationshipModel
            {
                FaId = src.FAID,
                AuthorityName = src.AuthN,
                RelationshipCategory = src.RlsCat,
                RelationshipDescription = src.RlsDesc,
                RelationshipDates = src.RlsDates
            };
        }

        public static FileAuthorityIA ToFileAuthorityIA(this FaInformationAssetModel src)
        {
            if (src == null) return null;

            return new FileAuthorityIA
            {
                FAID = src.FaId,
                FAType = src.FaType,
                Gender = src.Gender,
                SubjType = src.SubjectType,
                Places = src.Places?.Select(x => x.ToPlace()).ToList(),
                Categories = src.Categories?.Select(x => x.ToCategory()).ToList(),
                PreTtl = src.PreTitle,
                Ttl = src.Title,
                Fnames = src.Forenames,
                Name = src.Name,
                Eptht = src.Epithet,
                SrtTtl = src.SortTitle,
                SrtN = src.SortName,
                AuthN = src.AuthorityName,
                FrstDate = src.FirstDate,
                LstDate = src.LastDate,
                Dates = src.Dates,
                IsAuthRec = src.IsAuthorityRecord,
                Collections = src.Collections?.Select(x => x.ToCollection()).ToList(),
                CorpNum = src.CorporateNumber,
                SubjTtl = src.SubjectTitle,
                ISAARRef = src.IsaarReferernce,
                FISAARRef = src.FormerIsaarReference,
                LglStts = src.LegalStatus,
                SrsOfAuth = src.SourcesOfAuthority,
                Hist = src.History,
                Gnlgy = src.Genealogy,
                HistCtxt = src.HistoricalContext,
                Srcs = src.Sources,
                FncsOccsOrActs = src.FunctionsOccupationsActivities,
                NFrm = src.NameForm,
                BiogHistLnks = src.BiographyHistoryLinks?.Select(x => x.ToRes()).ToList(),
                Rlss = src.Relationships?.Select(x => x.ToRls()).ToList(),
                RelRess = src.RelatedResources?.Select(x => x.ToRes()).ToList(),
                RemAndFunc = src.RemitAndFunction,
                ValTxt = src.ValidationText,
                VarTxt = src.VariationText,
                JurisdTxt = src.JurisdictionText,
                IsPlOfDep = src.IsPlaceOfDeposit,
                NatPlOfDepCode = src.NationalPlaceOfDepositCode,
                BiogHist = src.BiographyHistory,
                BrwsC = src.BrowseCharacter,
                IsPblc = src.IsPublic
            };
        }

        public static FaInformationAssetModel ToFaInformationAssetModel(this FileAuthorityIA src)
        {
            if (src == null) return null;

            return new FaInformationAssetModel
            {
                FaId = src.FAID,
                FaType = src.FAType,
                Gender = src.Gender,
                SubjectType = src.SubjType,
                Places = src.Places?.Select(x => x.ToPlaceModel()).ToList(),
                Categories = src.Categories?.Select(x => x.ToCategoryModel()).ToList(),
                PreTitle = src.PreTtl,
                Title = src.Ttl,
                Forenames = src.Fnames,
                Name = src.Name,
                Epithet = src.Eptht,
                SortTitle = src.SrtTtl,
                SortName = src.SrtN,
                AuthorityName = src.AuthN,
                FirstDate = src.FrstDate,
                LastDate = src.LstDate,
                Dates = src.Dates,
                IsAuthorityRecord = src.IsAuthRec,
                Collections = src.Collections?.Select(x => x.ToCollectionModel()).ToList(),
                CorporateNumber = src.CorpNum,
                SubjectTitle = src.SubjTtl,
                IsaarReferernce = src.ISAARRef,
                FormerIsaarReference = src.FISAARRef,
                LegalStatus = src.LglStts,
                SourcesOfAuthority = src.SrsOfAuth,
                History = src.Hist,
                Genealogy = src.Gnlgy,
                HistoricalContext = src.HistCtxt,
                Sources = src.Srcs,
                FunctionsOccupationsActivities = src.FncsOccsOrActs,
                NameForm = src.NFrm,
                BiographyHistoryLinks = src.BiogHistLnks?.Select(x => x.ToResourceModel()).ToList(),
                Relationships = src.Rlss?.Select(x => x.ToRelationshipModel()).ToList(),
                RelatedResources = src.RelRess?.Select(x => x.ToResourceModel()).ToList(),
                RemitAndFunction = src.RemAndFunc,
                ValidationText = src.ValTxt,
                VariationText = src.VarTxt,
                JurisdictionText = src.JurisdTxt,
                IsPlaceOfDeposit = src.IsPlOfDep,
                NationalPlaceOfDepositCode = src.NatPlOfDepCode,
                BiographyHistory = src.BiogHist,
                BrowseCharacter = src.BrwsC,
                IsPublic = src.IsPblc
            };
        }
    }
}
