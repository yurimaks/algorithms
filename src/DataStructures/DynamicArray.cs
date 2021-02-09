using System;

namespace DataStructure
{
    public class DynamicArray
    {
        private int[] _data;
        private int _size;
        private int _capacity = 2;

        public DynamicArray()
        {
            _data = new int[_capacity];
            _size = 0;
        }

        public int this[int i] => _data[i];

        public DynamicArray(int capacity)
        {
            _data = new int[capacity];
            _size = 0;
        }
        
        public int Get(int index)
        {
            return _data[index];
        }

        public void Add(int value)
        {
            if (_size == _capacity)
            {
                Resize();
            }
            
            _data[_size] = value;
            _size++;
        }

        public void Insert(int index, int value)
        {
            if (index >= _size) throw new IndexOutOfRangeException();

            if (_size == _capacity)
            {
                Resize();
            }

            for (int i = _size; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = value;
            _size++;
        }

        public void Delete(int index)
        {
            if (index >= _size) throw new IndexOutOfRangeException();
            
            for (int i = index; i < _size - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            
            _size--;
        }

        public int Length => _size;

        private void Resize()
        {
            _capacity *= 2;
            int[] newData = new int[_capacity];
            for (int i = 0; i < _data.Length; i++)
            {
                newData[i] = _data[i];
            }

            _data = newData;
        }
    }
}