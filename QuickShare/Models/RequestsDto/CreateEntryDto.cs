namespace QuickShare.Models.RequestsDto;

public class CreateEntryDto
{
    public int spaceId { get; set; }
    public string text { get; set; } = null!;

}