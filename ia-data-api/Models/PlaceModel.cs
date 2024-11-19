namespace ia_data_api.Models;

public class PlaceModel
{
    public string Description { get; set; }
    public string PlaceName { get; set; }
    public string Parish { get; set; }
    public int TownID { get; set; }
    public string Town { get; set; }
    public int CountyID { get; set; }
    public string County { get; set; }
    public int CountryID { get; set; }
    public string Country { get; set; }
    public int StartDate { get; set; }
    public int EndDate { get; set; }
    public string Grid { get; set; }
    public string Validation { get; set; }
    public string LocationType { get; set; }
    public int RegionID { get; set; }
    public string Region { get; set; }
    public int OldCountyID { get; set; }
    public string OldCounty { get; set; }
    public int NewCountyID { get; set; }
    public string NewCounty { get; set; }
    public string DisplayName { get; set; }
}
