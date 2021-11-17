//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Lumpn.Collections.Indexing.Demo
{
    public sealed class Demo : MonoBehaviour
    {
        [SerializeField] private int numItems;

        void Start()
        {
            var list = Enumerable.Range(0, numItems).ToList();
            var items = list.ToArray();

            {
                Profiler.BeginSample("ValueTuple JIT");
                var tuple = System.ValueTuple.Create(0, 0);
                Profiler.EndSample();

                Profiler.BeginSample("ValueTuple deconstruct");
                var (a, b) = tuple;
                Profiler.EndSample();
                Debug.Assert(a == b);

                var listEnumerator = list.GetEnumerator();
                Profiler.BeginSample("Enumerator JIT");
                var enumerator = new Enumerator<int>(listEnumerator);
                Profiler.EndSample();
                Debug.Assert(enumerator.MoveNext());

                Profiler.BeginSample("Indexer JIT");
                var indexer = new Indexer<int>(items);
                Profiler.EndSample();
                Debug.Assert(indexer.GetEnumerator().MoveNext());
            }

            Profiler.BeginSample("for loop (array)");
            var sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum += items[i];
            }
            Profiler.EndSample();

            Profiler.BeginSample("foreach loop (array)");
            foreach (var item in items)
            {
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample("indexed foreach loop (array)");
            foreach (var tuple in items.Indexed())
            {
                sum += tuple.Item2;
            }
            Profiler.EndSample();

            Profiler.BeginSample("indexed foreach loop second time (array)");
            foreach (var tuple in items.Indexed())
            {
                sum += tuple.Item2;
            }
            Profiler.EndSample();

            Profiler.BeginSample("deconstructed foreach loop (array)");
            foreach (var (index, item) in items.Indexed())
            {
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample("deconstructed foreach loop over index (array)");
            foreach (var (index, item) in items.Indexed())
            {
                sum += index;
            }
            Profiler.EndSample();
        }

        void Update()
        {
            Debug.Break();
        }

        private void RunLoops(IEnumerable<int> items, string typeName)
        {

        }
    }
}
