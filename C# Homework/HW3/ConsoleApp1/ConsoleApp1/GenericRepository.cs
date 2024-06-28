using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private static List<T> storageList;
        private List<T> addedItems = new List<T>();
        private List<T> removedItems = new List<T>();

        public void Add(T item)
        {
            addedItems.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return storageList;
        }

        public T GetById(int id)
        {
            for (int i = 0; i < storageList.Count; i++)
            {
                if (storageList[i].Id == id)
                {
                    return storageList[i];
                }
            }
            return null;
        }

        public void Remove(T item)
        {
            removedItems.Add(item);
        }

        public void Save()
        {
            foreach (T item in addedItems)
            {
                storageList.Add(item);
            }
            foreach (T item in removedItems)
            {
                for (int i = 0; i < storageList.Count; i++) {
                    if (storageList[i].Id == item.Id)
                    {
                        storageList.RemoveAt(i);
                    }
                }
        }
    }
}
