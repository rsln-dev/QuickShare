namespace QuickShare.Services.Interfaces;

public interface IEntryService
{
    Task<bool> CreateEntry(int id, string? text);
    Task<bool> DeleteEntry(int id);
    Task<bool> UpdateTextEntry(int id, string newText);
}