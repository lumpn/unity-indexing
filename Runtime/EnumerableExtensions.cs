//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public static class EnumerableExtensions
    {
        public static Indexer<T> Indexed<T>(IEnumerable<T> items)
        {
            var list = new List<T>();
            var enumerator = list.GetEnumerator();
            return new Indexer<T>(items);
        }

    }
}
