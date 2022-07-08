using Kodelabzz.Library.coursera;
using Kodelabzz.Library.ds;

namespace Kodelabzz.Library
{
    public class LibRunner
    {
        public static void Run()
        {
           BracketChecker.Main(null);
        }

        private static void LinkedListOperations()
        {
            XLinkedList linkedList = new();
            XNode node = new()
            {
                data = 123
            };
            linkedList.Add(node);
            XNode node1 = new()
            {
                data = 2
            };
            linkedList.Add(node1);
            XNode node2 = new()
            {
                data = 45
            };
            linkedList.Add(node2);
            XNode node3 = new()
            {
                data = 9
            };
            linkedList.Add(node3);

            linkedList.Display();

            bool search = linkedList.Search(9);


            Console.WriteLine("item present ? " + search);

            bool isDeleted = linkedList.Delete(91);

            linkedList.Display();
        }
    }

  
}
