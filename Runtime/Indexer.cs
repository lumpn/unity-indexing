//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections;
using System.Collections.Generic;
using System;

namespace Lumpn.Collections.Indexing
{
    public struct Indexer<T> : IEnumerable<ValueTuple<int, T>>
    {
        private readonly IEnumerable<T> items;

        public Indexer(IEnumerable<T> items)
        {
            this.items = items;
        }

        public Enumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
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
