using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LearnToCode.Collections
{
    public class MyList<T> : IEnumerable
    {
        T[] _customList, _tempList;
        int _position;
        public MyList()
        {
            Count = 0;
            _position = -1;
            _customList = new T[1];
        }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                return _customList[index];
            }
            set
            {
                try
                {
                    _customList[index] = value;
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Add(T item)
        {

            if (Count == 0)
            {
                Count++;
                _position++;
            }
            else
                {
                _tempList = _customList;
                Count++;
                _customList = new T[Count];
                for (; _position < _tempList.Length; _position++)
                {
                    _customList[0] = _tempList[_position];
                } 
            }
            _customList[_position] = item;
        }

        public void Clear()
        {
            Count = 0;
            _position = -1;
            _customList = new T[1]; 
        }

        public int IndexOf(T item)
        {
            bool firstOccurrence = true;
            _position = -1;
            while (firstOccurrence)
            {
                _position++;
                if (item.Equals(_customList[_position]))
                {
                    firstOccurrence = false;
                }
            }
            return _position;
        }

       public void InsertAt(int index, T item)
        {
        throw new NotSupportedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return _customList.GetEnumerator();
        }       
    }

}
