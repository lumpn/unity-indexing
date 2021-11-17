//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Collections;
using System.Collections.Generic;
using System;

namespace Lumpn.Collections.Indexing
{
    public struct Enumerator<T> : IEnumerator<ValueTuple<int, T>>
    {
        private int index;
        private IEnumerator<T> enumerator;

        public Enumerator(IEnumerator<T> enumerator)
        {
            this.index = 0;
            this.enumerator = enumerator;
        }

        public ValueTuple<int, T> Current
        {
            get { return ValueTuple.Create(index, enumerator.Current); }
        }

        object IEnumerator.Current { get { return Current; } }

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
            index = 0;
            enumerator.Reset();
        }
    }
}
