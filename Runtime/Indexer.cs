//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public struct Indexer<T> : IEnumerable<ValueTuple<T, int>>
    {
        private readonly IEnumerable<T> source;

        public Indexer(IEnumerable<T> source)
        {
            this.source = source;
        }

        public Enumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(source.GetEnumerator());
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
