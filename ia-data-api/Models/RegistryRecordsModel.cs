namespace ia_data_api.Models;

public class RegistryRecordsModel
{
    /// <summary>
    /// NRAID
    /// </summary>
    public int NRAID { get; set; }

    /// <summary>
    /// Registry record title
    /// </summary>
    public string RegistryRecordTitle { get; set; }

    /// <summary>
    /// RO Collection Reference
    /// </summary>
    public string ROCollectionReference { get; set; }

    /// <summary>
    /// RO Accession number
    /// </summary>
    public string ROAccessionNumber { get; set; }

    /// <summary>
    /// NRA Details
    /// </summary>
    public string NRADetails { get; set; }

    /// <summary>
    /// Other Reference
    /// </summary>
    public string OtherReference { get; set; }

    /// <summary>
    /// ISADG Reference
    /// </summary>
    public string ISADGReference { get; set; }

    /// <summary>
    /// Sort word
    /// </summary>
    public string SortWord { get; set; }

    /// <summary>
    /// Catalogue URL
    /// </summary>
    public string CatalogueURL { get; set; }

    /// <summary>
    /// Scanned Lists
    /// </summary>
    public List<XReferenceModel> ScannedLists { get; set; }
}