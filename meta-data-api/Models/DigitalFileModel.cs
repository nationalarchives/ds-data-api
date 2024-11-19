namespace meta_data_api.Models;

public class DigitalFileModel
{
    /// <summary>
    /// Checksum of each individual file calculated at the time of transfer.
    /// </summary>
    public string CheckSum { get; set; }

    /// <summary>
    /// File format: jpg, pdf, etc.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// Presentation file name and path in S3. I.e. "66\KV\2\0000-0000-0000-0000.pdf"
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Original file name. As it is stored at the source.
    /// </summary>
    public string OriginalName { get; set; }

    /// <summary>
    /// File size in KB
    /// </summary>
    public int Size { get; set; }
}