using System.Reflection;
using hexagonal.Data.Extensions;
using hexagonal.Domain;

namespace hexagonal.Data.DataAccess;

public static class HexagonalMemoryContextFake
{
    private const string JsonPath = "hexagonal.Data.SeedData";
    private static readonly object SyncLock = new();

    /// <summary>
    ///     To reset memory database use -> context.Database.EnsureDeleted().
    /// </summary>
    public static void AddDataFakeContext(HexagonalContext? context)
    {
        var assembly = Assembly.GetAssembly(typeof(JsonUtilities));

        if (context == null || assembly is null) return;
        if (context.Books.Any()) return;

        lock (SyncLock)
        {
            var books = JsonUtilities.GetListFromJson<Book>(
                assembly.GetManifestResourceStream($"{JsonPath}.book.json"));

            books?.ForEach(entity =>
            {
                var isRegistred = context.Books.Any(x => x.Id == entity.Id);
                if (!isRegistred)
                    context.Books.Add(entity);
            });

            context.SaveChanges();
        }
    }
}