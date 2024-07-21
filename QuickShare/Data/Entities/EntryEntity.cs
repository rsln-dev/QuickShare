namespace QuickShare.Data.Entities;

public class EntryEntity
{
    public int Id { get; set; }
    public SpaceEntity Space { get; set; } = null!;
    public int SpaceId { get; set; }
    public EntryType Type { get; set; } 
    public string Text { get; set; } = null!;
    public int FileId { get; set; } 
    public FileEntity File { get; set; } 
}