namespace meta_data_api.Models;

public class PreparedFileItemModel
{
    public string FileName { get; set; }
    public int FromImage { get; set; }
    public int ToImage { get; set; }
    public string ContentType { get; set; }
}