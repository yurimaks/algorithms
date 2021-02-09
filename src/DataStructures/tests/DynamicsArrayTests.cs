using System;
using Xunit;

namespace DataStructure
{
    public class DynamicsArrayTests
    {
        private readonly DynamicArray _dynamicArray;

        public DynamicsArrayTests()
        {
            _dynamicArray = new DynamicArray();
        }
        
        [Fact]
        public void Add()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            _dynamicArray.Add(3);
            
            Assert.Equal(3, _dynamicArray.Length);
            Assert.Equal(1, _dynamicArray[0]);
            Assert.Equal(2, _dynamicArray[1]);
            Assert.Equal(3, _dynamicArray[2]);
        }
        
        [Fact]
        public void Insert()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            _dynamicArray.Add(4);
            
            _dynamicArray.Insert(2, 3);
            
            Assert.Equal(4, _dynamicArray.Length);
            Assert.Equal(1, _dynamicArray[0]);
            Assert.Equal(2, _dynamicArray[1]);
            Assert.Equal(3, _dynamicArray[2]);
            Assert.Equal(4, _dynamicArray[3]);
        }
        
        [Fact]
        public void Delete()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            _dynamicArray.Add(3);
            _dynamicArray.Add(4);
            
            _dynamicArray.Delete(2);
            
            Assert.Equal(3, _dynamicArray.Length);
            Assert.Equal(1, _dynamicArray[0]);
            Assert.Equal(2, _dynamicArray[1]);
            Assert.Equal(4, _dynamicArray[2]);
        }
        
        [Fact]
        public void Delete2()
        {
            _dynamicArray.Add(1);
            _dynamicArray.Add(2);
            _dynamicArray.Add(3);

            _dynamicArray.Delete(2);
            _dynamicArray.Delete(1);
            _dynamicArray.Delete(0);
            
            Assert.Equal(0, _dynamicArray.Length);
        }
        
    }
}