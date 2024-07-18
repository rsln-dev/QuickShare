namespace QuickShare.Data.Entities;

public class EntryEntity
{
    public int Id { get; set; }
    public SpaceEntity Space { get; set; } = null!;
    public int SpaceId { get; set; }
}