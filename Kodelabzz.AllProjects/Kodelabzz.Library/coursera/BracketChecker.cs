namespace Kodelabzz.Library.coursera
{
    public class BracketChecker
    {
        public static void Main(string[] args)
        {
            string? input= Console.ReadLine();
            BStack stack = new BStack();
            if(input!=null)
            {
                bool ismatched = true;
                for (int i = 0; i < input.Length; i++)
                {
                    Bracket goingIn;
                    if (input[i] == '[' || input[i] == '{' || input[i]=='(')
                    {
                        goingIn = new Bracket(input[i], i);
                        stack.Push(goingIn);
                    }
                    Bracket comingOut;
                    if(input[i] == ')' || input[i] == ']' || input[i] == '}')
                    {
                        comingOut = stack.Pop();
                        ismatched = comingOut.IsMatched(input[i]);
                        if(!ismatched)
                        {
                            Console.WriteLine();
                            break;
                        }

                    }
                    if(ismatched && stack.IsEmpty())
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {

                    }

                    

                }

                stack.Display();

                for (int i = 0; i < input.Length; i++)
                {
                    Console.WriteLine(stack.Pop());
                    stack.Display();
                }

                try
                {
                    stack.Pop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }

            }

        }
    }
    internal class Bracket
    {
        readonly char type;
        readonly int position;
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
                throw new Exception("Stack is empty");
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
