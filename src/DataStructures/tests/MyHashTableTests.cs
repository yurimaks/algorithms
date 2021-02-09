using System;
using Xunit;

namespace DataStructure
{
    public class MyHashTableTests
    {
        private readonly MyHashTable _myHashTable;

        public MyHashTableTests()
        {
            _myHashTable = new MyHashTable();
        }
        
        [Fact]
        public void Test()
        {
            _myHashTable.Put("a", "1");
            _myHashTable.Put("b", "2");
            _myHashTable.Put("c", "3");

            Assert.Equal("2", _myHashTable.Get("b"));
            Assert.Equal("1", _myHashTable.Get("a"));
            Assert.Equal("3", _myHashTable.Get("c"));
        }
    }
}