using System.Collections.Generic;

public static class EnumerableExtensions
{

    public static Indexer<T> Indexed<T>(IEnumerable<T> items)
    {
        var list = new List<T>();
        var enumerator = list.GetEnumerator();
        return new Indexer<T>(items);
    }

}

