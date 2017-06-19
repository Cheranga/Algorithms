using System;

namespace Interesting
{
    public interface ILinkedList<T>
    {
        ILinkedList<T> Add(T item);

        T GetNthElement(int elementAt);

        T this[int index] { get; }
    }

    /// <summary>
    /// A linked list representation of "First in last out" behaviour
    /// </summary>
    /// <typeparam name="T">Any parameter of your choice</typeparam>
    public class FiloSinglyLinkedList<T> : ILinkedList<T>
    {   
        private long _count;
        private ListItem<T> _current;

        public T this[int index]
        {
            get { return GetNthElement(index + 1); }
        }

        public ILinkedList<T> Add(T item)
        {
            var listItem = new ListItem<T>(item);

            if (_current == null)
            {
                _current = listItem;
            }
            else
            {
                listItem.Previous = _current;
                _current = listItem;
            }

            _count++;

            return this;
        }

        public T GetNthElement(int index)
        {
            //
            //  Throw an out of range exception if the following happens,
            //  1. There are no elements
            //  2. The given index is less than or equal to zero
            //  3. The given index is greater than the current count
            //
            if (_count == 0 || index <= 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException("index", @"Item cannot be found for the given index");
            }
            //
            // If it's the first element, return the current
            //
            if (index == 1)
            {
                return _current.Data;
            }

            var currentIndex = 1;
            var item = _current;
            while (currentIndex++ < index)
            {
                item = item.Previous;
            }

            return item.Data;
        }

    }
}