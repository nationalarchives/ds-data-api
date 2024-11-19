namespace ia_data_api.Models;

public class EntityReferenceModel : XReferenceModel
{
    public string Description { get; set; }
    public string PreTitle { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public int StartDate { get; set; }
    public int EndDate { get; set; }
}
