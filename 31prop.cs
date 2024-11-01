using System;
using System.Collections.Generic;

public class Program
{
    public delegate bool MatchDelegate<T>(T item);

    public static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Anna", Age = 33 },
            new Person { Name = "Daviti", Age = 30 },
            new Person { Name = "Dina", Age = 31 },
            new Person { Name = "Daviti", Age = 30 },
            new Person { Name = "Daviti", Age = 35 },
            new Person { Name = "Daviti", Age = 30 }
        };

        Person foundPerson = FindFirstMatch(people, p => IsMatch(p, "Daviti", 30));
        if (foundPerson != null)
        {
            Console.WriteLine($"Found: {foundPerson.Name},{foundPerson.Age}");
        }
        else
        {
            Console.WriteLine("Object does not exist");
        }

        Console.WriteLine("\nIndexes:");
        FindAndDisplayAllMatches(people, p => IsMatch(p, "Daviti", 30));
    }

    public static T FindFirstMatch<T>(List<T> list, MatchDelegate<T> matchDelegate)
    {
        foreach (var item in list)
        {
            if (matchDelegate(item))
            {
                return item;
            }
        }
        return default;
    }

    public static void FindAndDisplayAllMatches<T>(List<T> list, MatchDelegate<T> matchDelegate)
    {
        List<int> matches = new List<int>();
        for (int index = 0; index < list.Count; index++)
        {
            if (matchDelegate(list[index]))
            {
                Console.WriteLine($"{index}");
                matches.Add(index);
            }
        }
    }

    public static bool IsMatch(Person person, string name, int age)
    {
        return person.Name == name && person.Age == age;
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

