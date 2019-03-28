using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Hash.Program;

namespace Hash.Tests
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void HashTest3()
        {
            HashTable hash = new HashTable(3);

            var element1 = 8;
            var element2 = new[] { 1, 2, 3, 4 };
            var element3 = "8";

            hash.PutPair(0, element1);
            hash.PutPair(30, element2);
            hash.PutPair("arr", element3);
           

            Assert.AreEqual(element1, hash.GetValueByKey(0));
            Assert.AreEqual(element2, hash.GetValueByKey(30));
            Assert.AreEqual(element3, hash.GetValueByKey("arr"));
        }

        [TestMethod]
        public void HashTest2()
        {
            HashTable hash = new HashTable(2);

            var key = 15;
            var element1 = 3;
            var element2 = 9;

            hash.PutPair(key, element1);
            hash.PutPair(key, element2);

            Assert.AreEqual(element2, hash.GetValueByKey(key));
        }

        [TestMethod]
        public void HashTest10000n1()
        {
            int findKey = 0, flag, findElement = 0;
            var size = 10000;
            var rnd = new Random();
            flag = rnd.Next(size);
            var hash = new HashTable(size);
            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                var key = rnd.Next();
                hash.PutPair(key, element);
                if (i == flag)
                {
                    findElement = element;
                    findKey = key;
                }
            }
            Assert.AreEqual(findElement, hash.GetValueByKey(findKey));

        }

        [TestMethod]
        public void HashTest10000n1000()
        {
            int flag;
            var size = 10000;
            var rnd = new Random();
            flag = rnd.Next(size);
            var hash = new HashTable(size);
            for (var i = 0; i < size; i++)
            {
                var element = rnd.Next();
                hash.PutPair(i, element);
            }
            for (var i = 0; i < 1000; i++)
                Assert.AreEqual(null, hash.GetValueByKey(rnd.Next(1000) + 10000));

        }
    }
}

