﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workshop
{
    /// <summary>
    /// Integer List
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Default size of internal array
        /// </summary>
        private const int defaultSize = 2;
        /// <summary>
        /// Internal array
        /// </summary>
        private int[] innerArr;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Create custom integer list with default size
        /// </summary>
        public CustomList()
        {
            innerArr = new int[defaultSize];
        }
        /// <summary>
        /// Create custom integer list with default size
        /// </summary>
        /// <param name="initialSize">Initial size</param>
        public CustomList(int initialSize)
        {
            innerArr = new int[initialSize];
        }

        public int this [int index]
        {
            get
            {
                CheckIndexRange (index);
                return innerArr[index];
            }
            set
            {
                CheckIndexRange(index);
                innerArr[index] = value;
            }
        }

        

        public void Add(int element)
        {
            if (innerArr.Length==Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public void AddRange(int [] list)
        {
            if (list.Length + Count>=innerArr.Length)
            {
                if (list.Length + Count > innerArr.Length*2)
                {
                    Grow(list.Length + Count);
                }
                else
                {
                    Grow();
                }
            }

            for (int i = 0; i < list.Length; i++)
            {
                innerArr[Count] = list[i];
                Count++;
            }
        }
        /// <summary>
        /// Removes element at position
        /// </summary>
        /// <param name="index">position</param>
        /// <exception cref="IndexOutOfRangeException">
        /// The position is out of range</exception>
        public void RemoveAt(int index)
        {
            CheckIndexRange(index);
            ShiftLeft(index);
            Count--;
            Shrink();
        }

        public  void InsertAt(int index, int element)
        {
            CheckIndexRange(index);
            ShiftRight(index);
            innerArr[index] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            bool result = false;

            foreach (var item in innerArr)
            {
                if (item==element)
                {
                    result=true;
                    break;
                }
            }

          return  result;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexRange(firstIndex);
            CheckIndexRange(secondIndex);

            int tempElement = innerArr[firstIndex];
            innerArr[firstIndex] = innerArr[secondIndex];
            innerArr[secondIndex] = tempElement;

        }

        public void Shrink()
        {
            if (innerArr.Length / 4 > Count)
            {
                int[] tempArr = new int[innerArr.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    tempArr[i] = innerArr[i];
                }

                innerArr = tempArr;
            }
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(innerArr[i]);
            }
        }

        #region private

        private void Grow()
        {
            Grow(innerArr.Length * 2);
        }

        private void Grow(int newSize)
        {
            int [] tempArr = new int[newSize];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void ShiftLeft(int position)
        {
            if (position < Count-1)
            {
                for (int i = position; i < Count-1; i++)
                {
                    innerArr[i] = innerArr[i + 1];
                }
            }
            else if(position == Count-1)
            {
                innerArr[position] = default(int);
            }

        }

        private void ShiftRight(int position)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            for (int i = Count; i >= position; i--)
            {
                innerArr[i + 1] = innerArr[i];
            }

            innerArr[position] = default(int);
        }
        private void CheckIndexRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
        #endregion
    }
}
