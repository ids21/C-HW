using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    
        public class SingleNode<T>
        {
            public T Value{ get; set; }
            public SingleNode<T> Next  { get; set; }
            public SingleNode(T item)
            {
                Value = item;

            }
        public SingleNode()
        {
        }
    };
    public interface IComparable<T>
    {
        int CompareTo(SingleNode<T> p,SingleNode<T> q);
    }
    public class SinglyLinkedList<T>:IComparable<T>
    {
        public int CompareTo(SingleNode<T> p, SingleNode<T> q)
        {
            if (Convert.ToInt32(p.Value) > Convert.ToInt32(q.Value))
                return 1;
            else if (Convert.ToInt32(p.Value) < Convert.ToInt32(q.Value))
                return 2;
            else return 0;

        }
        SingleNode<T> Head;        public SinglyLinkedList()
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
            
        }
        public SingleNode<T> deleteFirst()
        {
            SingleNode<T> temp = Head;
            Head = Head.Next;
            return temp;
        }
        public void displayList()
        {
            SingleNode<T> current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Value + " "); 
                current = current.Next;
            }
            Console.WriteLine();
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
        public bool Contains(T index)
        {
            SingleNode<T> p;
            p = this.Head;
            while (p.Next != null)
            {

                if (Convert.ToInt32(p.Value) == Convert.ToInt32(index))
                    return true;

                p = p.Next;

            }
            return false;
        }
        public int count()
        {
            SingleNode<T> p;
            p = Head;
            int k=0;
            while (p.Next != null)
            {
                k++;
                p = p.Next;

            }
            p = p.Next;
            if (p == null)
                k=k+1;
            return k;
        }

        public void Add(T value)
        {
            SingleNode<T> first = new SingleNode<T>(value);
            SingleNode<T> penult = new SingleNode<T>();
            SingleNode<T> second = Head;
            while (CompareTo(first, second) == 1 && second.Next != null)
            {
                penult = second;
                second = second.Next;
            }
            if (second.Next != null)
            {
                penult.Next = first;
                first.Next = second;
                return;
                
            }
            else
            {
                if (CompareTo(first, second) == 2)
                {
                    if (penult != null)
                    {
                        penult.Next = first;
                        first.Next = second;
                    }
                    else
                    {
                        first.Next = second;
                        return;
                    }
                }
                else if (CompareTo(first, second) == 1)
                {
                    if (penult != null)
                    {
                        penult.Next = second;
                        second.Next = first;
                    }
                    else
                    {
                        second.Next = first;
                        return;
                    }
                }
                else
                {
                    if (penult != null)
                    {
                        penult.Next = first;
                        first.Next = second;
                    }
                    else
                    {
                        first.Next = second;
                        return;
                    }
                }
            }
        }
    };
   
        class Program
        {
            static void Main(string[] args)
            {
            
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            /*
            list.Addfirst(3);
            list.Addfirst(6);
            list.Addfirst(5);
            list.Addfirst(10);
            //list.RemoveIndex(2);
            */
            list.Addfirst(1);
            list.Add(4);
            list.Add(2);
            list.Add(3);
            list.Add(7);
            list.displayList();
            
            list.displayList();
            Console.Write(list.Contains(5));

            Console.Write(list.count());
            Console.ReadKey();
            }
        }
       
   
}
