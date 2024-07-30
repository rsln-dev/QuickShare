namespace QuickShare.Services.Interfaces;

public interface IEntryService
{
    Task<bool> CreateEntry(int spaceId, string? text);
    Task<bool> DeleteEntry(int id);
    Task<bool> UpdateTextEntry(int id, string newText);
}