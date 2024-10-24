namespace Generics;

public static class TryCatchExample
{
    public static void Run()
    {
        TryCatchLogic();
    }

    private static void TryCatchLogic()
    {
        while (true)
        {
            try
            {
                DivideNumbers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Executed anyway!");
            }
        }

        Console.ReadLine();
    }

    private static void DivideNumbers()
    {
        Console.Write("Enter number: ");
        var number1 = decimal.Parse(Console.ReadLine());

        Console.Write("Enter number: ");
        var number2 = decimal.Parse(Console.ReadLine());

        var result = Calculate(number1, number2);
        Console.WriteLine($"{number1} / {number2} = {result}");
    }

    private static decimal Calculate(decimal number1, decimal number2)
    {
        if (number2 == 0)
        {
            throw new DivideByZeroException();
        }

        return number1 / number2;
    }
}