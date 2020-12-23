namespace DataStructure
{
    public class DynamicArray
    {
        private string[] _data;

        public DynamicArray(int capacity)
        {
            _data = new string[capacity];
        }
        
        public string get(int index)
        {
            return _data[index];
        }

        public void set(int index, string value)
        {
            _data[index] = value;
        }

        public void insert(int index, string value)
        {
            
        }

        public void delete(int index)
        {
            
        }
        
    }
}