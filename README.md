# Indexing
Indexed `foreach` loops with minimal overhead.

# Usage

```csharp
foreach (var (index, item) in items.Indexed())
{
    Process(item, $"Item {index}");
}
```

# Performance

| Collection | Method | GC Alloc B | Time ms |
|------------|--------|----------|---------|
| List | `for` | 0 | 0.79 |
| List | `foreach` (optimized) | 0 | 1.42 |
| List | `foreach` | 40 | 1.42 |
| List | Indexed | 40 | 3.44 |
| List | Wrap coroutine | 104 | 3.47 |
| List | Select ValueTuple | 120 | 4.81 |
| List | Select KeyValuePair | 120 | 5.55 |
| List | Select anonymous | 2.3 M | 16.06 |
| List | Select Tuple | 2.3 M | 17.07 |

| Collection | Method | GC Alloc B | Time ms |
|------------|--------|----------|---------|
| Array | `for` | 0 | 0.23 |
| Array | `foreach` (optimized) | 0 | 0.27 |
| Array | `foreach` | 32 | 2.21 |
| Array | Indexed | 32 | 3.99 |
| Array | Wrap coroutine | 96 | 4.42 |
| Array | Select ValueTuple | 112 | 5.87 |
| Array | Select KeyValuePair | 112 | 6.43 |
| Array | Select anonymous | 2.3 M | 16.85 |
| Array | Select Tuple | 2.3 M | 18.14 |

| Collection | Method | GC Alloc B | Time ms |
|------------|--------|----------|---------|
| Enumerable.Range | `foreach` | 36 | 1.34 |
| Enumerable.Range | Indexed | 36 | 3.36 |
| Enumerable.Range | Wrap coroutine | 100 | 3.44 |
| Enumerable.Range | Select ValueTuple | 116 | 4.77 |
| Enumerable.Range | Select KeyValuePair | 116 | 5.57 |
| Enumerable.Range | Select anonymous | 2.3 M | 15.99 |
| Enumerable.Range | Select Tuple | 2.3 M | 17.04 |

# Notes

- Do not use anonymous types.
- Use `ValueTuple` instead of `Tuple`.
- `KeyValuePair` is also good but does not provide automatic deconstruction.
- In `Select` prefer lambda over generic function.
- Prefer coroutine over `Select`.
