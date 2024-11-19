namespace ia_data_api.Models;

public class PersonModel
{
    public string PreTitle { get; set; }

    public string Title { get; set; }

    public string SortTitle { get; set; }

    public List<string> Forenames { get; set; }

    public string Surname { get; set; }

    public string SortName { get; set; }

    public string Epithet { get; set; }

    public int DateOfBirth { get; set; }

    public int DateOfDeath { get; set; }

    public List<string> Occupation { get; set; }
}
