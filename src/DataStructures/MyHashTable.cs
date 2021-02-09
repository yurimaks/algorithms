using System;

namespace DataStructure
{
    public class MyHashTable
    {
        private const int INITIAL_SIZE = 16;
        private HashEntity[] data; //LinkedList

        public MyHashTable()
        {
            data = new HashEntity[INITIAL_SIZE];
        }


        public void Put(string key, string value)
        {
            //Get index
            int index = GetIndex(key);
            
            //Create the entry
            var entity = new HashEntity(key,value);

            if (data[index] == null)
            {
                data[index] = entity;
            }
            else //Collisions!!!!
            {
                var hashEntity = data[index];
                
                while (hashEntity.Next != null)
                {
                    hashEntity = hashEntity.Next;
                }
                hashEntity.Next = entity;
            }
        }

        public string Get(string key)
        {
            int index = GetIndex(key);

            var hashEntity = data[index];

            if (hashEntity != null)
            {
                while (hashEntity.Key != key && hashEntity.Next != null)
                {
                    hashEntity = hashEntity.Next;
                }
                
                return hashEntity.Value;
            }

            return null;
        }

        private int GetIndex(string key)
        {
            var hashCode = Math.Abs(key.GetHashCode());
            //it is a simple 1-step binary operation faster
            var hashCode1 = key.GetHashCode() & 0x7fffffff;
            
            int index = hashCode % INITIAL_SIZE;

            if (key == "a" || key == "b")
            {
                index = 4;
            }
            
            return index;
        }
        
        private class HashEntity
        {
            public HashEntity(string key, string value)
            {
                Key = key;
                Value = value;
            }
            
            public string Key { get; }
            public string Value { get; }
            public HashEntity Next { get; set; }
        }
        
    }
}