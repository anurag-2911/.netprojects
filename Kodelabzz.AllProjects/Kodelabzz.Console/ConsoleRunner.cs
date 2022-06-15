using Kodelabzz.Library;
using Kodelabzz.Library.net;
using Kodelabzz.Library.programming;

Console.WriteLine("Hello, World!");


CallMethods();

void CallMethods()
{
    //CallDisposeTestMethods();

    //CallFinalizersMethods();

    //CallArraySort();

    //CallFindUnique();

    //BoxUnBox.Run();

    //StringConcat.Run();
}

void CallDisposeTestMethods()
{
    Dispose_Test.Run();
}

void CallFinalizersMethods()
{
    CreateObjects();

    static void CreateObjects()
    {
        int count = 0;
        while (!Console.KeyAvailable)
        {
            _ = new Finalizers(count++);
        }
    }

    Console.WriteLine("terminating process");
}

void CallArraySort()
{
    ArraySort.Sort();
}

void CallFindUnique()
{
    CommonProgs.FindIfAllCharsAreUnique();
}