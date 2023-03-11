/* Write a program that print a number from a collection, which appears an even number of times in it.
 * On the first line, you will be given N - the count of integers you will receive. On the next N lines,
 * you will be receiving the numbers. It is guaranteed that only one of them appears an even number of times.
 * Your task is to find that number and print it in th end.
 * 
 * Examples:
 * 
 * INPUT:           3
 *                  2
 *                 -1
 *                  2
 *                  
 * OUTPUT:          2
 * 
 * Solution by me, sstankov
 */

using System;
class Program
{
    static void Main(string[] args)
    {
        //reading input:
        int n = int.Parse(Console.ReadLine());
        Dictionary<int, int> numbers = new Dictionary<int, int>(); //dictionary to store the integers

        //iterating through the dictionary:
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine()); //read integer from input

            if (!numbers.ContainsKey(number)) //If the integer (key) is NOT present in the dictionary:
            {
                numbers.Add(number, 0); //add the integer with a counter of 0
            }
            numbers[number]++;
        }

        //printing output:
       KeyValuePair<int, int> kvp =  numbers.First(x => x.Value % 2 == 0);
        Console.WriteLine(kvp.Key);
    }

}
