using System.Text;
using QuickShare.Services.Interfaces;

namespace QuickShare.Services;

public class SlugService : ISlugService
{
    private static readonly Random Random = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public string Generate(int length)
    {
        StringBuilder sb = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            sb.Append(Chars[Random.Next(Chars.Length)]);
        }

        return sb.ToString();
    } 
}