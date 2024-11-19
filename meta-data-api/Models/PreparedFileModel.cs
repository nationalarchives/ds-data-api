namespace meta_data_api.Models;

public class PreparedFileModel
{
    public string IAID { get; set; }
    public int PercentCompleted { get; set; }
    public int Count { get; set; }
    public long LastDownloadTimestamp { get; set; }
    public string LastDownloadTimestampPretty { get; set; }
    public List<PreparedFileItemModel> Parts { get; set; }
}