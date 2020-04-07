using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LearnToCode.Collections
{
    public class MyList<T>:IEnumerable
    {
        T[] _customList = new T[1], _tempList;
        int _startPosition = -1;
        int _position = -1;
        
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
            Array.Resize(ref _customList, Count);
            _position++;
            _customList[_position] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
            _position = -1;
            _customList = new T[1]; 
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < _customList.Length; i++)
            {
                if (item.Equals(_customList[i]))
                    return i;
            }
            return -1;
        }

        public void InsertAt(int index, T item)
        {
            
        }

        public void Remove(T item)
        {
            _tempList = _customList;
            for(int i = 0; i < _tempList.Length; i++)
            {
                if (item.Equals(_tempList[i]))
                    {
                        Count--;
                        break;
                    }                
       
             }

            if (Count.Equals(_tempList.Length))
            {
                Console.WriteLine("Error! Item missing.");
            }
            else
            {
                _customList = new T[Count];

                for (int i = 0; i < _tempList.Length; )
                    for(int j = 0; j < _customList.Length; j++)
                {
                    if (item.Equals(_tempList[i]))
                    {
                            j--;
                            i++;
                        continue;
                    }
                    _customList[j] = _tempList[i];
                        i++;
                }
            }

           
            
        }

        public IEnumerator GetEnumerator()
        {
            return _customList.GetEnumerator();
        }       
    }
}
