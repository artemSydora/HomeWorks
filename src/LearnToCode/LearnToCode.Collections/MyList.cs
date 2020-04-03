using System;

namespace LearnToCode.Collections
{
    public class MyList<T>
    {
        public int Count { get; private set; }

        public T this[int index]
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
