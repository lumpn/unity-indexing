//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public struct IndexedEnumerable<T> : IEnumerable<ValueTuple<T, int>>
    {
        private readonly IEnumerable<T> source;

        public IndexedEnumerable(IEnumerable<T> source)
        {
            this.source = source;
        }

        public IndexedEnumerator<T> GetEnumerator()
        {
            return new IndexedEnumerator<T>(source.GetEnumerator());
        }

        IEnumerator<ValueTuple<T, int>> IEnumerable<ValueTuple<T, int>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
