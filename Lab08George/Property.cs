using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08George
{
    public class Property<T> : IEnumerable<T>
    {
        T[] manhattan = new T[20];
        int counter = 0;

        public void Add(T item)
        {
            if (counter == manhattan.Length)
            {
                Array.Resize(ref manhattan, manhattan.Length * 2);
            }
            manhattan[counter++] = item;
        }

        public void Remove(T item)
        {
            Console.WriteLine($"Deleting {item}");
            int removeAt = Array.IndexOf(manhattan, item);
            bool remove = false;
            T[] newArray = new T[manhattan.Length];

            for (int i = 0; i < counter; i++)
            {
                if (i == removeAt)
                {
                    remove = true;
                }
                else if (remove)
                {
                    newArray[i - 1] = manhattan[i];
                }
                else
                {
                    newArray[i] = manhattan[i];
                }
            }
            manhattan = newArray;
            counter--;
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
            {
                yield return manhattan[i];
            }
        }

        // calls the generic enumerator if the non-generic one is called
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

