namespace meta_data_api.Models;

public class FileEditSetModel
{
    public int Initial { get; set; }
    public int Current { get; set; }
    public string Name { get; set; }
    public string OriginalName { get; set; }
    public int Size { get; set; }
    public string Format { get; set; }
    public int Action { get; set; }
}