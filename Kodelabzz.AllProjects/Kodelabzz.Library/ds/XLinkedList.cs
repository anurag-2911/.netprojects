using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodelabzz.Library.ds
{
    internal class XLinkedList
    {
        XNode? head =null;

        public void Add(XNode node)
        {
            if(head == null)
            {
                head = new XNode();
                head.next = node;
                node.next = null;
            }
            else
            {
                XNode temp = head;
                while (temp.next!=null)
                {
                    temp = temp.next;
                }
                temp.next = node;
            }
        }

        public bool Delete(int data)
        {
            bool isDeleted= false;
            if(head!=null)
            {
                XNode node = head;
                
                if(node!=null)
                {
                    while (node.next != null)
                    {
                        XNode current = node;
                        node = node.next;
                        if (node.data == data)
                        {
                            isDeleted = true;
                            current.next = node.next;
                            break;
                        }
                      
                    }
                }
            }
            return isDeleted;
        }
        public bool Search(int data)
        {
            if (head != null)
            {
                XNode temp = head.next;

                if (temp != null)
                {
                    while (temp!= null)
                    {
                        if (temp.data == data)
                        {
                            return true;

                        }
                        temp = temp.next;
                    }
                }
            }
            return false;
        }
        public void Display()
        {
            if(head == null)
            {
                Console.WriteLine("empty linked list");
                return;
            }

            XNode temp = head;
            while (temp.next!=null)
            {
                temp = temp.next;
                Console.Write(temp.data); Console.Write(" ");

            }
            Console.WriteLine();
        }
    }
    internal class XNode
    {
        public XNode? next;
        public int data;

        public override string ToString()
        {
            return data.ToString();
        }

    }
   
}
