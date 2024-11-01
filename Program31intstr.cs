using System;
using System.Collections.Generic;

public class Program
{
    public delegate bool MatchDelegate<T>(T item, T searchValue);

    public static void Main()
    {
        List<string> stringList = new List<string> { "pink", "cat", "cherry", "cat", "tail" };
        string searchString = "cat";

        Console.WriteLine($"results for\"{searchString}\":");
        FindAndDisplayMatches(stringList, searchString, IsMatch);

        List<int> intList = new List<int> { -8, 2, 3, 2, 4, 5, 2 };
        int searchInt = 2;

        Console.WriteLine($"\nresults for {searchInt}:");
        FindAndDisplayMatches(intList, searchInt, IsMatch);
    }
    public static void FindAndDisplayMatches<T>(List<T> list, T searchValue, MatchDelegate<T> matchDelegate)
    {
        for (int index = 0; index < list.Count; index++)
        {
            if (matchDelegate(list[index], searchValue))
            {
                Console.WriteLine($"{index}");
            }
        }
    }

    public static bool IsMatch<T>(T item, T searchValue)
    {
        return EqualityComparer<T>.Default.Equals(item, searchValue);
    }
}
