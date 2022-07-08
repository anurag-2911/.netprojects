using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Kodelabzz.Library.coursera
{
    public class BracketChecker
    {
        public static void Main(string[] args)
        {
            string input= Console.ReadLine();

            BStack stack = new BStack();
            
            if(input!=null)
            {
                int ismatched = 0;
                int i;
                for (i = 0;i < input.Length; i++)
                {
                    Bracket goingIn;
                    if (input[i] == '[' || input[i] == '{' || input[i]=='(')
                    {
                        goingIn = new Bracket(input[i], i+1);
                        stack.Push(goingIn);
                    }
                    Bracket comingOut;
                    if(input[i] == ')' || input[i] == ']' || input[i] == '}')
                    {
                        comingOut = stack.Pop();
                        if (comingOut != null)
                        {
                            bool val = comingOut.IsMatched(input[i]);
                            if (!val)
                            {
                                ismatched = -1;
                                Console.WriteLine(i + 1);
                                break;
                            }
                        }
                        else
                        {
                            ismatched = -2;
                            break;
                        }
                    }            
                }
                if (ismatched != -1)
                {
                    if (ismatched == -2)
                    {
                        Console.WriteLine(i + 1);
                    }
                    if (ismatched == 0 && stack.IsEmpty())
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Bracket bracket = null;
                        while (!stack.IsEmpty())
                        {
                            bracket = stack.Pop();
                        }
                        if (bracket != null)
                        {
                            Console.WriteLine(bracket.position);
                        }
                    }
                }

               

            }

        }
    }
    internal class Bracket
    {
       public readonly char type;
       public readonly int position;
        public Bracket(char type, int position)
        {
            this.type = type;
            this.position = position;
        }
        
        public bool IsMatched(char c)
        {
            if(type=='[' && c==']')
                return true;
            if (type == '{' && c == '}')
                return true;
            if (type == '(' && c == ')')
                return true;

            return false;
        }
    }
    internal class BStack
    {
        Node current = null;
        int counter = 0;

        public Bracket Pop()
        {
            if(counter == 0)
            {
                return null;
            }
            Bracket c= current.next.data;
            current.next = current.next.next;
            counter--;
            return c;
        }
        public void Push(Bracket input)
        {
            if(current==null)
            {
                current = new Node();
                Node node = new Node();
                node.data = input;
                current.next = node;
            }
            else
            {
                Node node = new Node();
                node.data = input;
                node.next = current.next;
                current.next = node;
            }
           
            
            counter++;
        }
        public bool IsEmpty()
        {
            return counter==0;
        }

        public int Counter
        {
            get
            {
                return counter;
            }
        }
        public void Display()
        {
            if(counter==0)
            {
                return;
            }
            Node start = current.next;
            while(start!= null)
            {
                Console.Write(start.data);
                start=start.next;
            }
            Console.WriteLine();
        }
    }
    internal class Node
    {
        public Bracket data;
        public Node next;
    }
}
