using System;
using Xunit;

namespace DataStructure
{
    public class LinkedListTest
    {
        private readonly LinkedList _linkedList;
        
        public LinkedListTest()
        {
            _linkedList = new LinkedList();            
        }

        [Fact]
        public void AddFrontTest()
        {
            _linkedList.AddFront(3);
            _linkedList.AddFront(2);
            _linkedList.AddFront(1);

            var current = _linkedList.head;
            Assert.Equal(1, current.val);
            current = current.next;
            Assert.Equal(2, current.val);
            current = current.next;
            Assert.Equal(3, current.val);
            current = current.next;
            Assert.Null(current);
        }
        
        [Fact]
        public void AddBackTest()
        {
            _linkedList.AddBack(3);
            _linkedList.AddBack(2);
            _linkedList.AddBack(1);

            var current = _linkedList.head;
            Assert.Equal(3, current.val);
            current = current.next;
            Assert.Equal(2, current.val);
            current = current.next;
            Assert.Equal(1, current.val);
            current = current.next;
            Assert.Null(current);
        }
        
        [Fact]
        public void SizeTest()
        {
            _linkedList.AddBack(3);
            _linkedList.AddBack(2);
            _linkedList.AddBack(1);
            
            Assert.Equal(3, _linkedList.Size());
        }
        
        [Fact]
        public void DeleteValueTest()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            
            Assert.Equal(3, _linkedList.Size());
            _linkedList.DeleteValue(3);
            Assert.Equal(2, _linkedList.Size());
            _linkedList.DeleteValue(2);
            Assert.Equal(1, _linkedList.Size());
            _linkedList.DeleteValue(1);
            
            Assert.Equal(0, _linkedList.Size());
        }
        
        [Fact]
        public void GetBeforeLastNode()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            
            Assert.Equal(2, _linkedList.GetValueBeforeLast());
            _linkedList.DeleteValue(3);
            Assert.Equal(1, _linkedList.GetValueBeforeLast());
        }
        
        [Fact]
        public void DeleteTailTest()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);

            _linkedList.DeleteTail();
            
            Assert.Equal(2, _linkedList.Size());
            Assert.Equal(2, _linkedList.head.next.val);
        }

        [Fact]
        public void GetTheMiddleNode()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            _linkedList.AddBack(4);
            _linkedList.AddBack(5);
            _linkedList.AddBack(6);
            _linkedList.AddBack(7);
            
            Assert.Equal(4, _linkedList.Middle());
        }
        
        [Fact]
        public void GetTheMiddleNode_Odd()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            _linkedList.AddBack(4);

            Assert.Equal(3, _linkedList.Middle());
        }

        [Fact]
        public void GetFirst()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            _linkedList.AddBack(4);
            
            Assert.Equal(1, _linkedList.GetFirst());
        }
        
        [Fact]
        public void GetLast()
        {
            _linkedList.AddBack(1);
            _linkedList.AddBack(2);
            _linkedList.AddBack(3);
            _linkedList.AddBack(4);
            
            Assert.Equal(4, _linkedList.GetLast());
        }
    }
}