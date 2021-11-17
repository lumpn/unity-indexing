using System.Collections;
using System.Collections.Generic;

public struct Indexer<T> : IEnumerable<System.ValueTuple<int, T>>
{
    private readonly IEnumerable<T> items;

    public struct Enumerator : IEnumerator<System.ValueTuple<int, T>>
    {
        private int index;
        private IEnumerator<T> enumerator;

        public Enumerator(Indexer<T> indexer)
        {
            index = 0;
            enumerator = indexer.items.GetEnumerator();
        }

        public (int, T) Current => System.ValueTuple.Create(index, enumerator.Current);

        object IEnumerator.Current => Current;

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

    public Indexer(IEnumerable<T> items)
    {
        this.items = items;
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<System.ValueTuple<int, T>> IEnumerable<System.ValueTuple<int, T>>.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

