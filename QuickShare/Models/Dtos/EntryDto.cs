namespace QuickShare.Models.Dtos;

public class EntryDto
{
    public int Id { get; set; }
    public int SpaceId { get; set; }
    public string Type { get; set; } = null!;
    public string Text { get; set; } = null!;
    public int FileId { get; set; }
    public FileDto File { get; set; } = null!;
}