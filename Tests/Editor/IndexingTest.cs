//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System.Linq;
using NUnit.Framework;

namespace Lumpn.Collections.Indexing.Tests
{
    [TestFixture]
    public sealed class IndexingTest
    {
        [Test]
        public void TestForeach()
        {
            var items = Enumerable.Range(0, 10);
            foreach (var (index, item) in items.Indexed())
            {
                Assert.AreEqual(item, index);
            }
        }
    }
}
