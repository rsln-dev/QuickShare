namespace QuickShare.Data.Entities;

public class FileEntity
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public int EntryId { get; set; }
    public EntryEntity Entry { get; set; }
}