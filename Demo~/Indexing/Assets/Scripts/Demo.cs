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
                sum += item;
            }
            return sum;
        }

        private static int RunSelectAnonymous(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var value in items.Select((item, index) => new { item, index }))
            {
                sum += value.item;
                sum += value.index;
            }
            return sum;
        }

        private static int RunSelectTuple(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (item, index) in items.Select((item, index) => new Tuple<int, int>(item, index)))
            {
                sum += item;
                sum += index;
            }
            return sum;
        }

        private static int RunSelectValueTuple(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (item, index) in items.Select((a, b) => new ValueTuple<int, int>(a, b)))
            {
                sum += item;
                sum += index;
            }
            return sum;
        }

        private static int RunSelectKeyValuePair(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var kvp in items.Select((item, index) => new KeyValuePair<int, int>(item, index)))
            {
                sum += kvp.Key;
                sum += kvp.Value;
            }
            return sum;
        }

        private static int RunIndexed(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (item, index) in items.Indexed())
            {
                sum += item;
                sum += index;
            }
            return sum;
        }

        private static int RunWrap(IEnumerable<int> items)
        {
            int sum = 0;
            foreach (var (item, index) in Wrap(items))
            {
                sum += item;
                sum += index;
            }
            return sum;
        }

        private static IEnumerable<ValueTuple<T, int>> Wrap<T>(IEnumerable<T> source)
        {
            int index = 0;
            foreach (var item in source)
            {
                yield return ValueTuple.Create(item, index++);
            }
        }
    }
}
