//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public struct Indexer<T> : IEnumerable<ValueTuple<int, T>>
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

        IEnumerator<ValueTuple<int, T>> IEnumerable<ValueTuple<int, T>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
