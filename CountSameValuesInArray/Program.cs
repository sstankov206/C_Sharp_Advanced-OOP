/* Read a list of real numbers and print them along with their number of occurences
 * 
 * Examples:
 * 
 * INPUT:       8 2.5 2.5 8 2.5
 * OUTPUT:      8 - 2 times
 *              2.5 - 3 times
 *              
 *Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        //readin input, split by space and store in array:
        double[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        //creating a Dictionary for tracking the counter of each number's occurences:
        Dictionary<double, int> counter = new Dictionary<double, int>();

        //iterating through the array:
        foreach (var number in input)
        {
            if (counter.ContainsKey(number)) //if the dictionary contains this key:
            {
                counter[number] += 1;   //increase the occurence of this number by 1
            }
            else
            {
                counter[number] = 1; //else if NOT previously found, set the occurence of the number to equal '1'
            }
        }

        //printing output:

        foreach (var item in counter)
        {
            Console.WriteLine($"{item.Key} - {item.Value} times");
        }
    }
}
