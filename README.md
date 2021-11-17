# Indexing
Indexed foreach loops

# Performance

| Collection | Method | GC Alloc B | Time ms |
|------------|--------|----------|---------|
| List | `for` | 0 | 0.79 |
| List | `foreach` (optimized) | 0 | 1.42 |
| List | `foreach` | 40 | 1.42 |
| List | Indexed | 40 | 3.44 |
| List | Wrap coroutine | 104 | 3.47 |
| List | Select ValueTuple | 232 | 4.88 |
| List | Select Tuple | 2.3 M | 16.48 |
| List | Select anonymous | 2.3 M | 16.99 |

| Collection | Method | GC Alloc B | Time ms |
|------------|--------|----------|---------|
| Array | `for` | 0 | 0.23 |
| Array | `foreach` (optimized) | 0 | 0.27 |
| Array | `foreach` | 32 | 2.21 |
| Array | Indexed | 32 | 3.99 |
| Array | Wrap coroutine | 96 | 4.42 |
| Array | Select ValueTuple | 224 | 5.87 |
| Array | Select Tuple | 2.3 M | 18.42 |
| Array | Select anonymous | 2.3 M | 17.28 |
