using System;
namespace DS_CSHARP
{
    public interface IMyCollection<K,V>
    {
        void Insert(K key, V value);
        bool Remove( K key);
        V Search(K key);
        int Size{ get;  }
        bool IsEmpty{ get; }
    }

}
