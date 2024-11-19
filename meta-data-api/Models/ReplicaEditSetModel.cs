using System.Runtime.Serialization;

namespace meta_data_api.Models;

[Serializable]
public class ReplicaEditSetModel
{
    public string RID { get; set; }
    public string IAID { get; set; }
    public string User { get; set; }

    [DataMember]
    public DateTime Requested { get; set; }

    [DataMember]
    public DateTime Submitted { get; set; }

    public List<FileEditSetModel> Files { get; set; }
}