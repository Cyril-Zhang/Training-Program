namespace ConsoleApp1
{
    public class MyStack<T>
    {
        private List<T> myList;

        public MyStack() { 
            myList = new List<T>();
        }

        public int Count()
        {
            return myList.Count;
        }

        public T Pop()
        {
            if(myList.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = myList[myList.Count-1];
            myList.RemoveAt(myList.Count-1);
            return item;
        }

        public void Push(T item) {
            myList.Add(item);
        }

    }
}
