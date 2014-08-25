namespace HashStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashedSet<T>
    {
        // In order to use my HashTable i need a value but i realy do not need it
        // and I will use bool to take less memory
        private HashTable<T, bool> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<T,bool>();
        }

        public int Count
        {
            get { return this.hashTable.Count; }
        }

        public void Add(T element)
        {
            this.hashTable.Add(element, true);
        }

        public void Add(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                this.hashTable.Add(element, true);
            }
        }

        public void Remove(T element)
        {
            this.hashTable.Delete(element);
        }

        public bool Contains(T element)
        {
            try
            {
                var foundElement = this.hashTable.Find(element);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void Union(IEnumerable<T> otherElements)
        {
            foreach (var el in otherElements)
            {
                if (!this.Contains(el))
                {
                    this.Add(el);
                }
            }
        }

        public void Intersect(IEnumerable<T> otherElements)
        {
            List<T> commonElements = new List<T>();

            foreach (var el in otherElements)
            {
                if (this.Contains(el))
                {
                    commonElements.Add(el);
                }
            }

            this.Clear();
            this.Add(commonElements);
        }

        // For easier testing
        public T[] ToArray()
        {
            List<T> elements = new List<T>(this.hashTable.Count);

            foreach (var item in this.hashTable)
            {
                elements.Add(item.Key);
            }

            return elements.ToArray();
        }
    }
}
