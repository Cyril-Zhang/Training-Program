using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class MyList<T>
    {
        private List<T> itemList;

        public MyList(){
            this.itemList = new List<T>();
        }

        public void Add(T item) { 
            itemList.Add(item);
        }

        public T Remove(int index) { 
            if(index < 0 && index >= this.itemList.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            T item = this.itemList[index];
            this.itemList.RemoveAt(index);
            return item;
        }

        public bool Contains(T item)
        {
            return itemList.Contains(item);
         }


        public void Clear() { 
            this.itemList = new List<T>();
        }

        public void Insert(int index, T item) {
            if (index < 0 || index > this.itemList.Count)
            {
                throw new ArgumentOutOfRangeException( "Index is out of range");
            }

            this.itemList.Insert(index, item);
        }
        public void DeleteAt(int index) {
            if (index < 0 || index >= this.itemList.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            this.itemList.RemoveAt(index);
        }

        public T Find(int index)
        {
            if (index < 0 || index >= this.itemList.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            return this.itemList[index];
        }
    }
}
