namespace QuickShare.Models.Dtos;

public class SpaceDto
{
    public int Id { get; set; }
    public string Slug { get; set; } = null!;
    public int TTL { get; set; } // value in seconds
    public List<EntryDto> Entries { get; set; } = new ();
    public DateTime CreatedAt { get; set; }
}