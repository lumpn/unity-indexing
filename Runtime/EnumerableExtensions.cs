//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public static class EnumerableExtensions
    {
        public static Indexer<T> Indexed<T>(this IEnumerable<T> source)
        {
            return new Indexer<T>(source);
        }
    }
}
