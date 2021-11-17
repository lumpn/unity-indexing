//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

namespace Lumpn.Collections.Indexing.Demo
{
    public sealed class Demo : MonoBehaviour
    {
        [SerializeField] private int numItems;

        void Start()
        {
            var items = Enumerable.Range(0, numItems);
            var list = items.ToList();
            var array = items.ToArray();
            var set = new HashSet<int>(items);

            for (int i = 0; i < 10; i++)
            {
                RunLoops(items, "Enumerable");
                RunLoops(array, "Array");
                RunLoops(list, "List");
                RunLoops(set, "HashSet");
            }
        }

        void Update()
        {
            Debug.Break();
        }

        private int RunLoops(IEnumerable<int> items, string typeName)
        {
            Profiler.BeginSample(typeName);
            int sum = RunLoops(items);
            Profiler.EndSample();

            return sum;
        }

        private int RunLoops(IEnumerable<int> items)
        {
            int sum = 0;

            Profiler.BeginSample("foreach");
            sum += RunForeach(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Indexed");
            sum += RunIndexed(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Wrap coroutine");
            sum += RunWrap(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Select anonymous type");
            sum += RunSelectAnonymous(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Select Tuple");
            sum += RunSelectTuple(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Select ValueTuple");
            sum += RunSelectValueTuple(items);
            Profiler.EndSample();

            Profiler.BeginSample("foreach Select KeyValuePair");
            sum += RunSelectKeyValuePair(items);
            Profiler.EndSample();

            return sum;
        }

        private static int RunForeach(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var item in items)
            {
                sum += item;
            }
            return sum;
        }

        private static int RunSelectAnonymous(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var value in items.Select((index, item) => new { index, item }))
            {
                sum += value.item;
            }
            return sum;
        }

        private static int RunSelectTuple(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (index, item) in items.Select((a, b) => new Tuple<int, int>(a, b)))
            {
                sum += index;
                sum += item;
            }
            return sum;
        }

        private static int RunSelectValueTuple(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (index, item) in items.Select((a, b) => new ValueTuple<int, int>(a, b)))
            {
                sum += index;
                sum += item;
            }
            return sum;
        }

        private static int RunSelectKeyValuePair(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var kvp in items.Select((index, item) => new KeyValuePair<int, int>(index, item)))
            {
                sum += kvp.Key;
                sum += kvp.Value;
            }
            return sum;
        }

        private static int RunIndexed(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (index, item) in items.Indexed())
            {
                sum += item;
            }
            return sum;
        }

        private static int RunWrap(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (index, item) in Wrap(items))
            {
                sum += item;
            }
            return sum;
        }

        private static IEnumerable<ValueTuple<int, T>> Wrap<T>(IEnumerable<T> source)
        {
            int index = 0;
            foreach (var item in source)
            {
                yield return ValueTuple.Create(index++, item);
            }
        }
    }
}
