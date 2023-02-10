//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public struct IndexedEnumerator<T> : IEnumerator<ValueTuple<T, int>>
    {
        private readonly IEnumerator<T> enumerator;
        private int index;

        public IndexedEnumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
            this.index = -1;
        }

        public ValueTuple<T, int> Current
        {
            get { return ValueTuple.Create(enumerator.Current, index); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            enumerator.Dispose();
        }

        public bool MoveNext()
        {
            index++;
            return enumerator.MoveNext();
        }

        public void Reset()
        {
            enumerator.Reset();
            index = -1;
        }
    }
}
