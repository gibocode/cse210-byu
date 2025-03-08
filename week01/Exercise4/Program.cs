using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int number;

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
        Console.WriteLine($"The smallest positive number is: {numbers.Where(i => i > 0).Min()}");

        Console.WriteLine("The sorted list is:");

        foreach (int sortedNumber in numbers.Order())
        {
            Console.WriteLine(sortedNumber);
        }
    }
}
