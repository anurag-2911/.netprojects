using Kodelabzz.Library;
using Kodelabzz.Library.net;
using Kodelabzz.Library.programming;

Console.WriteLine("Hello, World!");

CreateObjects();

static void CreateObjects()
{
    int count = 0;
    while(!Console.KeyAvailable)
    { 
        new Finalizers(count++);
    }
}

Console.WriteLine("terminating process");

//ArraySort.Sort();
//CommonProgs.FindIfAllCharsAreUnique();
