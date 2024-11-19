namespace ia_data_api.Models;

public class ScopeContentModel
{
    public List<EntityReferenceModel> PersonNames { get; set; }
    public List<EntityReferenceModel> PlaceNames { get; set; }
    public string RefferedToDate { get; set; }
    public List<EntityReferenceModel> Organizations { get; set; }
    public string Description { get; set; }
    public string Ephemera { get; set; }
    public List<string> Occupations { get; set; }
    public string Schema { get; set; }
}