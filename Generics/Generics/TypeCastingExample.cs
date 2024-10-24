using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics;

public class TypeCastingExample
{
    public static void Run()
    {
        IObject obj = new SimpleObject();
        CastUsingIsOperator(obj);

        var customer = new Customer();
        var employee = new Employee();

        DisplayWithCast(employee);
        try
        {
            DisplayWithCast(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        DisplayWithAsOperator(employee);
        DisplayWithAsOperator(customer);

        ArrayList collection = new ArrayList { 1, "2", 3, 4 };

        // var numbers = new List<int>() { 1, "2", 3, 4 }; // არ დაკომპილირდება
        var numbers = new List<int>() { 1, 3, 4 };
        Sum(numbers);

        var sum = Sum(collection);
    }

    private static void CastUsingIsOperator(IObject obj)
    {
        if (obj is SimpleObject casted)
        {
            Console.WriteLine(casted.Id);
        }
    }

    public static void DisplayWithCast(Person person)
    {
        Console.WriteLine(person.PersonalNumber);

        var employee = (Employee)person; //  Type casting (Down cast)
        Console.WriteLine(employee.Salary);
    }

    public static void DisplayWithAsOperator(Person person)
    {
        Console.WriteLine(person.PersonalNumber);

        var employee = person as Employee; //  Type casting (Down cast)
        Console.WriteLine($"Employee salary: {employee?.Salary}");
    }

    public static void DisplayWithIsOperator(Person person)
    {
        Console.WriteLine(person.PersonalNumber);

        //  Type casting (Down cast)
        if (person is Employee employee)
        {
            Console.WriteLine($"Employee salary: {employee.Salary}");
        }
    }

    private static int Sum(List<int> numbers)
    {
        int sum = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            var number = numbers[i];
            sum += number;
        }

        return sum;
    }

    private static int Sum(ArrayList numbers)
    {
        int sum = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] is int number)
            {
                sum += number;
            }
        }

        return sum;
    }
}