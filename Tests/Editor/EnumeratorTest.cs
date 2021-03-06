//----------------------------------------
// MIT License
// Copyright(c) 2021 Jonas Boetel
//----------------------------------------
using System;
using System.Linq;
using NUnit.Framework;

namespace Lumpn.Collections.Indexing.Tests
{
    [TestFixture]
    public sealed class EnumeratorTest
    {
        [Test]
        public void TestDeconstructTuple()
        {
            var tuple = Tuple.Create("test", 5);
            var (text, index) = tuple;

            Assert.AreEqual("test", text);
            Assert.AreEqual(5, index);
        }

        [Test]
        public void TestIndex()
        {
            var items = Enumerable.Range(0, 10);
            var itemsEnumerator = items.GetEnumerator();
            var indexedEnumerator = new Enumerator<int>(itemsEnumerator);

            while (indexedEnumerator.MoveNext())
            {
                var (item, index) = indexedEnumerator.Current;
                Assert.AreEqual(item, index);
            }
        }

        [Test]
        public void TestReset()
        {
            var items = Enumerable.Range(0, 10).ToList();
            var itemsEnumerator = items.GetEnumerator();
            var indexedEnumerator = new Enumerator<int>(itemsEnumerator);

            indexedEnumerator.MoveNext();
            indexedEnumerator.MoveNext();
            indexedEnumerator.MoveNext();

            Assert.AreEqual((2, 2), indexedEnumerator.Current);

            indexedEnumerator.Reset();
            indexedEnumerator.MoveNext();
            Assert.AreEqual((0, 0), indexedEnumerator.Current);
        }
    }
}
