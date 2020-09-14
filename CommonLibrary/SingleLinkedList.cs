using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class SingleNode
    {
        public SingleNode(int value)
        {
            Value = value;
        }


        public int Value { get; private set; }
        public SingleNode Next;

        public SingleNode Add(int value)
        {
            var node = new SingleNode(value){ Next = this.Next };

            this.Next = node;
            return node;
        }

        
    }

    public class SingleLinkedList : IEnumerable<int>
    {
        public SingleNode Head;


        public SingleNode AddToEnd(int value)
        => AddToEnd(new SingleNode(value));
        public SingleNode AddToEnd(SingleNode node)
        {
           // var node = new SingleNode { Value = value };

            if (Head == null)
            {
                Head = node;
                return node;
            }
                

            var curr = Head;

            while (curr.Next != null)
                curr = curr.Next;

            curr.Next = node;

            return node; 
        }

        public SingleNode AddToStart(int value) 
        => AddToStart(new SingleNode(value));

        public SingleNode AddToStart(SingleNode node){
            node.Next = Head;
            Head = node;
            return node;
        }


        public int Count(){
            var nodeCount = 0;
            var curr = Head;
            while(curr != null){
                nodeCount++;
                curr = curr.Next;
            }
            return nodeCount;
        }
        public List<int> ToList()
        {
            var list = new List<int>();

            var curr = Head;

            while (curr != null)
            {
                list.Add(curr.Value);
                curr = curr.Next;
            }

            return list;

        }

        public void Remove(SingleNode node)
        {
            if (Head == node)
            {
                Head = node.Next;
                return;
            }
            var curr = Head;

            while (curr.Next != node)
                curr = curr.Next;

            curr.Next = node.Next;
        }



        public SingleNode RemoveFromEnd()
        {
            if (Head == null) return null;
                
            if (Head.Next == null)
            {
                Head = null;
                return null;
            }

            var curr = Head;

            while (true)
            {
                if (curr.Next.Next != null)
                {
                    curr = curr.Next;
                }
                else
                {
                    // next is the last 
                    var node = curr.Next;
                    curr.Next = null;
                    return node;
                }
            }
        }

        public bool IsEmpty { get => Head == null; }

        public SingleNode RemoveFromStart()
        {
            var node = Head; 


            if (node != null)
            {
                Head = node.Next;
                node.Next = null;
            }

            return node; 
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new SingleListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SingleListEnumerator(this);
        }
    }

    public class SingleListEnumerator : IEnumerator<int>, IEnumerator
    {

        public SingleListEnumerator(SingleLinkedList list) => this.list = list;
        private SingleNode current;
        private  SingleLinkedList list;

        public int Current => current.Value;

        object IEnumerator.Current => current.Value;

        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            if (current==null){
                current = list.Head;
            }
            else {
                current = current.Next;
            }

            return current != null;
        }

        public void Reset()
        {
            current = null;
        }
    }
}
