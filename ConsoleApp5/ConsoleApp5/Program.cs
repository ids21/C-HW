using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SingleNode<T>
{
    public T Value;//{ get; set; }
    public SingleNode<T> Next = null;// { get; set; }
    public SingleNode(T item)
    {
        Value = item;

    }
}
    
    public class SinglyLinkedList<T>
    {
        SingleNode<T> Head;
        int size = 0;
        public SinglyLinkedList()
        {
            Head = null;
        }
        public void Addfirst(T addvalue)
        {
            if (Head == null)
            {
                Head = new SingleNode<T>(addvalue);

            }
            else
            {
                SingleNode<T> temp = new SingleNode<T>(addvalue);
                temp.Next = Head;
                Head = temp;
            }
            size++;
        }


        public void Addlast(T addvalue)
        {
            if (Head == null)
            {
                Addfirst(addvalue);
            }
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;

                }
                current.Next = new SingleNode<T>(addvalue);

            }
            size++;
        }
        public void Remove(T addvalue)
        {
            var current = Head;

            if (Head.Value.Equals(addvalue))
            {
                Head = Head.Next;

            }
            else
            {
                while (!addvalue.Equals(current.Next.Value))
                {
                    current = current.Next;

                }
                if (current.Next.Next != null)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current.Next = null;
                }

            }
            size--;
        }
        public void insert(int index, T addvalue)
        {
            var current = Head;
            int currentindex = 1;

            if (index == 0)
            {
                Addfirst(addvalue);
            }

            else
            {
                while (currentindex != index)
                {

                    current = current.Next;
                    currentindex++;
                }
                if (current.Next != null)
                {
                    SingleNode<T> temp = new SingleNode<T>(addvalue);
                    temp.Next = current.Next;
                    current.Next = temp;
                }

            }


        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current.Next != null)
            {
                yield return current.Value;
            }
        }

        public void RemoveIndex(int index)
        {
            var current = Head;
            int currentindex = 1;
            if (index == 0)
            {
                Head = Head.Next;

            }
            else
            {
                while (currentindex != index)
                {
                    current = current.Next;
                    currentindex++;
                }
                if (current.Next.Next != null)
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current.Next = null;
                }

            }
        }

        static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Addfirst(7);
            list.Addfirst(6);
            list.Addfirst(5);
            list.Addfirst(4);
            list.Addfirst(3);
            list.Addfirst(2);
            list.Addfirst(1);
            list.RemoveIndex(4);

            foreach (int currentNumber in list)
            {
                Console.WriteLine(currentNumber);
            }



        }
    }
}