namespace meta_data_api.Models;

public class ReplicaModel
{
    public List<DigitalFileModel> Files { get; set; }

    /// <summary>
    /// MongoDB _id field value
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Replica ID
    /// </summary>
    public string ReplicaId { get; set; }

    /// <summary>
    /// Origination of the digital files
    /// </summary>
    public string Origination { get; set; }

    /// <summary>
    /// A sum of all files sizes within this Replica
    /// </summary>
    public int TotalSize { get; set; }
}