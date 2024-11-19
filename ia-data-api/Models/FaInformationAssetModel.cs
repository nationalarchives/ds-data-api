namespace ia_data_api.Models;

public class FaInformationAssetModel
{
    public string FaId { get; set; }

    public string FaType { get; set; }

    public string Gender { get; set; }

    public string SubjectType { get; set; }

    public List<PlaceModel> Places { get; set; }

    public List<CategoryModel> Categories { get; set; }

    public string PreTitle { get; set; }

    public string Title { get; set; }

    public string Forenames { get; set; }

    public string Name { get; set; }

    public string Epithet { get; set; }

    public string SortTitle { get; set; }

    public string SortName { get; set; }

    public string AuthorityName { get; set; }

    public int FirstDate { get; set; }

    public int LastDate { get; set; }

    public string Dates { get; set; }

    public bool IsAuthorityRecord { get; set; }

    public List<CollectionModel> Collections { get; set; }

    public string CorporateNumber { get; set; }

    public string SubjectTitle { get; set; }

    public string IsaarReferernce { get; set; }

    public string FormerIsaarReference { get; set; }

    public string LegalStatus { get; set; }

    public string SourcesOfAuthority { get; set; }

    public string History { get; set; }

    public string Genealogy { get; set; }

    public string HistoricalContext { get; set; }

    public string Sources { get; set; }

    public string FunctionsOccupationsActivities { get; set; }

    public string NameForm { get; set; }

    public List<ResourceModel> BiographyHistoryLinks { get; set; }

    public List<RelationshipModel> Relationships { get; set; }

    public List<ResourceModel> RelatedResources { get; set; }

    public string RemitAndFunction { get; set; }

    public string ValidationText { get; set; }

    public string VariationText { get; set; }

    public string JurisdictionText { get; set; }

    public bool IsPlaceOfDeposit { get; set; }

    public string NationalPlaceOfDepositCode { get; set; }

    public string BiographyHistory { get; set; }

    public string BrowseCharacter { get; set; }

    public bool IsPublic { get; set; }
}
