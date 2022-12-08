// chunk

var max = Extensions
    .LoadFile("day_1_input.txt")
    .Chunk(string.IsNullOrEmpty)
    .Select(a => a.Sum(int.Parse)).Max();

Console.WriteLine(max);


public static class Extensions
{
    public static IEnumerable<string> LoadFile(string name)
    {
        return File.ReadLines(Path.Combine(Environment.CurrentDirectory, "files", name));
    }

    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, Func<T, bool> chunkOn,
        bool discardChunkMarker = true)
    {
        var list = new List<T>();

        foreach (var sourceItem in source)
        {
            var chunkMark = chunkOn(sourceItem);
            if (!chunkMark)
            {
                list.Add(sourceItem);
            }
            else
            {
                yield return list;

                list = new List<T>();

                if (!discardChunkMarker)
                {
                    list.Add(sourceItem);
                }
            }
        }

        yield return list;
    }
}