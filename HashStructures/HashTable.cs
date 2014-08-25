namespace HashStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialSize = 16;
        private int maxTakenCellsCount;
        private int takenCells;
        private int capacity;

        private LinkedList<KeyValuePair<K, T>>[] elements;
        private int elementsCount;

        public HashTable() : this(InitialSize)
        { }

        public HashTable(int size)
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[size];
            this.elementsCount = 0;
            this.takenCells = 0;
            this.capacity = size;
            this.maxTakenCellsCount = CalculateSizeChangeValue();
        }

        public int Count
        {
            get { return this.elementsCount; }
        }

        public T this[K key]
        {
            get
            {
                T value = this.Find(key);
                return value;
            }
        
            set
            {
                int index = this.GetArrayPosition(key);
                bool isFound = false;
                if (this.elements[index].Count > 0)
                {
                    foreach (var pair in this.elements[index])
                    {
                        if (pair.Key.Equals(key))
                        {
                            this.elements[index].Remove(pair);
                            this.elements[index].AddLast(new KeyValuePair<K,T>(key, value));
                        }
                    }

                    if (!isFound)
	                {
		                this.Add(key, value);
	                }
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public void Add(K key, T value)
        {
            if (this.takenCells >= this.maxTakenCellsCount)
            {
                this.Enlarge();
            }

            var pair = new KeyValuePair<K, T>(key, value);
            int index = this.GetArrayPosition(key);

            if (this.elements[index] != null)
            {
                foreach (var storedPair in this.elements[index])
                {
                    if (storedPair.Key.Equals(key))
                    {
                        throw new ArgumentException("Duplicate Key!");
                    }
                }
                this.elements[index].AddLast(pair);
            }
            else
            {
                this.elements[index] = new LinkedList<KeyValuePair<K, T>>();
                this.elements[index].AddLast(pair);
                this.takenCells++;
            }

            this.elementsCount++;
        }

        public T Find(K key)
        {
            int index = this.GetArrayPosition(key);
            if (this.elements[index] != null)
            {
                foreach (var pair in this.elements[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            throw new KeyNotFoundException("Element not found!");
        }

        public void Delete(K key)
        {
            int index = this.GetArrayPosition(key);
            bool isDeleted = false;
            if (this.elements[index].Count > 0)
            {
                foreach (var pair in this.elements[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        elements[index].Remove(pair);
                        isDeleted = true;
                        this.elementsCount--;
                        break;
                    }
                }
            }

            if (!isDeleted)
            {
                throw new ArgumentException("Element not found!");
            }
        }

        public K[] Keys()
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i] != null)
                {
                    foreach (var pair in this.elements[i])
                    {
                        keys.Add(pair.Key);
                    }
                }
            }

            return keys.ToArray();
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[this.elements.Length];
            this.elementsCount = 0;
            this.takenCells = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                var currentCell = this.elements[i];
                if (this.elements[i] != null)
                {
                    foreach (var pair in this.elements[i])
                    {
                        yield return pair;
                    }
                }
            }
        }

        private int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % this.capacity;
            return Math.Abs(position);
        }

        private void Enlarge()
        {
            var newElements = new LinkedList<KeyValuePair<K, T>>[this.elements.Length * 2];
            this.capacity = newElements.Length;
            this.maxTakenCellsCount = CalculateSizeChangeValue();

            // Copy all the elements with new position because of the defining of the index
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i] != null)
                {
                    foreach (var pair in this.elements[i])
                    {
                        int index = this.GetArrayPosition(pair.Key);
                        if (newElements[index] != null)
                        {
                            newElements[index].AddLast(pair);
                        }
                        else
                        {
                            newElements[index] =
                                new LinkedList<KeyValuePair<K, T>>();
                            newElements[index].AddLast(pair);
                        }
                    }
                }
            }

            this.elements = newElements;
        }

        private int CalculateSizeChangeValue()
        {
            double maxCount = ((double)this.capacity / 100) * 75;
            return (int)maxCount;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
