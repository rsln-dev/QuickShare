namespace QuickShare.Data.Entities;

public class SpaceEntity
{
    public int Id { get; set; }
    public string Slug { get; set; } = null!;
    public int TTL { get; set; } // value in seconds
    public List<EntryEntity> Entries { get; set; } = new ();
}