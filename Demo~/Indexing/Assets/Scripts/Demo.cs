//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
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

            RunLoops(items, "Enumerable");
            RunLoops(array, "Array");
            RunLoops(list, "List");
            RunLoops(set, "HashSet");
        }

        void Update()
        {
            Debug.Break();
        }

        private int RunLoops(IEnumerable<int> items, string typeName)
        {
            var sum = 0;

            Profiler.BeginSample($"{typeName} JIT");
            foreach (var (index, item) in items.Indexed())
            {
                sum += index;
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample($"{typeName} foreach");
            foreach (var item in items)
            {
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample($"{typeName} foreach Indexed");
            foreach (var (index, item) in items.Indexed())
            {
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample($"{typeName} foreach Select");
            foreach (var (index, item) in items.Select(System.ValueTuple.Create<int, int>))
            {
                sum += item;
            }
            Profiler.EndSample();

            Profiler.BeginSample($"{typeName} foreach Wrap");
            foreach (var (index, item) in Wrap(items))
            {
                sum += item;
            }
            Profiler.EndSample();

            return sum;
        }

        private static IEnumerable<System.ValueTuple<int, T>> Wrap<T>(IEnumerable<T> source)
        {
            int index = 0;
            foreach (var item in source)
            {
                yield return System.ValueTuple.Create(index++, item);
            }
        }
    }
}
