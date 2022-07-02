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
    int[] arr = { 1, 3, 6, 4, 1, 2 };
    int retVal = solution(arr);

}

int solution(int[] A)
{
    int min = 1;

    if (A.Length == 0)
    {
        return min;
    }

    Array.Sort(A);

    if (A[0] > 1)
    {
        return min;
    }
    if (A[A.Length - 1] <= 0)
    {
        return min;
    }

    for (int i = 0; i < A.Length; i++)
    {
        if (A[i] == min)
        {
            min++;
        }
    }

    return min;
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