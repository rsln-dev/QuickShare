namespace QuickShare.Models.Dtos;

public class FileDto
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public int EntryId { get; set; }
}