//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public static class EnumerableExtensions
    {
        public static IndexedEnumerable<T> Indexed<T>(this IEnumerable<T> source)
        {
            return new IndexedEnumerable<T>(source);
        }
    }
}
