//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using UnityEngine;

namespace Lumpn.Collections.Indexing.Samples
{
    public sealed class IndexingUsageSample : MonoBehaviour
    {
        [SerializeField] private string[] items;

        void Start()
        {
            foreach (var (item, index) in items.Indexed())
            {
                Debug.LogFormat(this, "{0}: item '{1}'", index, item);
            }
        }
    }
}
