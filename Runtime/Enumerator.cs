//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lumpn.Collections.Indexing
{
    public struct Enumerator<T> : IEnumerator<ValueTuple<int, T>>
    {
        private readonly IEnumerator<T> enumerator;
        private int index;

        public Enumerator(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
            this.index = -1;
        }

        public ValueTuple<int, T> Current
        {
            get { return ValueTuple.Create(index, enumerator.Current); }
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
