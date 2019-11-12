using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {


        class MyQueue
        {
            class Node
            {
                public int value; //value generic realizeable...
                public Node next = null;
                public Node(int value)
                {
                    this.value = value;
                }
            }

            private Node first = null;
            private Node last = null;

            void enqueue(Node node)
            {
                if (last == null)
                {
                    first = last = node;
                }
                else
                {
                    last.next = node;
                    last = node;
                }


            }

            void dequeue()
            {
                first = first.next;
                if (first == null) last = null;
            }


            void print()
            {
                Node node = first;
                while (node != null)
                {
                    Console.Write(node.value + " ");
                    node = node.next;
                }

                Console.WriteLine();
            }


            int getMin()
            {

                if (last == null) return -9999; //ERROR HANDLING SHALL BE DONE HERE

                int min_val = first.value;
                Node tmp = first.next;

                while (tmp != null)
                {
                    if (tmp.value < min_val)
                    {
                        min_val = tmp.value;
                        //Save node for dequeue min
                    }

                    tmp = tmp.next;
                }


                return min_val;
            }


            Node getMinNode()
            {


                if (last == null) return null;

                int min_val = first.value;
                Node tmp = first.next;
                Node min_node = first;

                while (tmp != null)
                {
                    if (tmp.value < min_val)
                    {
                        min_node = tmp;
                        min_val = tmp.value;
                        //Save node for dequeue min
                    }

                    tmp = tmp.next;
                }


                return min_node;
            }


            //Overload to get predecessor
            Node getMinNode(out Node predecessor)
            {
                Node min_node = getMinNode();


                predecessor = null;

                //Search predecessor
                Node tmp = first;
                while(min_node.value != tmp.value)
                {
                    predecessor = tmp;
                    tmp = tmp.next;

                }
                return min_node;
            }


            Node extract_min() //yay, seems to work
            {
                Node pre; //Vorgänger
                Node del = getMinNode(out pre);
                Node res = del;
                //Deleting min
                //Check if min is first aka list head
                if (del == first)
                    first = last = null;
                else //Bypass...
                {


                    Console.WriteLine("Debug:");
                    Console.WriteLine("Del Val:{0}", del.value);
                    Console.WriteLine("Pre Val:{0}", pre.value);
                    Console.WriteLine("Debug end:");

                    pre.next = del.next;
                    del.next = null;

                }

                return res;
            }


            static void Main(string[] args)
            {
                MyQueue q = new MyQueue();
                q.enqueue(new Node(32));
                q.enqueue(new Node(15));
                q.enqueue(new Node(19));
                q.enqueue(new Node(78));

                q.print();
                Console.WriteLine("Min Value:{0}", q.getMin());


                Node min = q.getMinNode();
                Console.WriteLine("Min Value via node:{0}", min.value);


                Console.WriteLine("Now extracting the min value and printing the Queue...");
                Node other_min = q.extract_min();
                q.print();
            }

        }//End MyQueue
    }
}
