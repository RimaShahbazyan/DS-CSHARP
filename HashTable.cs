using System;
using System.Collections.Generic;
namespace DS_CSHARP
{
    public abstract class HashTable<K, V>:IMyCollection<K,V> where K: IComparable<K>
    {
        private List<E>[] arr;
        public HashTable(int arrSize)
        {
            Size = 0;
            arr = new List<E>[arrSize];
        }
        public int Size { get; private set; }
        public bool IsEmpty { get { return Size == 0; } }
        protected abstract long GetHash(K key);
        protected abstract int Compress(long Hash);
        public void Insert(K key, V value) 
        {
            E entry = new E(key, value);
            arr[Compress(GetHash(key))].Add( entry);
         
        }
        public V Search (K key)
        {
            return searchE(key).Value;
        }

        public bool Remove(K key) {
            return arr[Compress(GetHash(key))].Remove(searchE(key));
        }

        private E searchE(K key)
        {
            return arr[Compress(GetHash(key))].Find(e => e.Key.CompareTo(key) == 0);
        }
        private class E
        {
            public E( K key, V value)
            {
                this.Key = key;
                this.Value = value;
            }
            public K Key { get; private set; }
            public V Value { get; private set; }
        }

    }

}
