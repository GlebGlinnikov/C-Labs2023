using Lab1;
using System;
class Program
{
    static void Main()
    {
        //Part 1
        Console.WriteLine("Part 1");
        Console.WriteLine("Enter array size: ");
        int size = int.Parse(Console.ReadLine());
        Part1 part1 = new Part1(size);
        part1.print();
        Console.WriteLine($"Product of negative: {part1.product_of_neg()}");
        Console.WriteLine($"Sum of positive: {part1.sum_of_pos()}");
        part1.reverse();
        Console.WriteLine("After reverse:");
        part1.print();

        Console.WriteLine();
        Console.WriteLine("Part 2:");

        //Part 2
        Console.WriteLine("Enter matrix size: ");
        int size2 = int.Parse(Console.ReadLine());
        Part2 part2 = new Part2(size2);
        part2.print();
        Console.WriteLine($"Sum in positive rows: {part2.sum_in_pos_rows()}");
        Console.WriteLine($"Minimum sum on diagonals: {part2.min_sum()}");

        Console.ReadLine();
    }
}
