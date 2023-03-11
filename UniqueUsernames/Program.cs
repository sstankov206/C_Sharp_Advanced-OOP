/* Write a program that reads from the console a sequence of 'N' usernames and keeps a collection
 * only of the unique ones. On the first line you will be given an integer 'N'
 * on the next 'N' lines you will receive ONE username per line.
 * Print the collection on the console in order of insertion.
 * 
 * Example
 * 
 * INPUT:       6
 *              Ivan
 *              Ivan
 *              Ivan
 *              Pesho
 *              Ivan
 *              NiceGuy1234
 *              
 * OUTPUT:      Ivan
 *              Pesho
 *              NiceGuy1234
 *              
 * Solution by me, sstankov.
 */

using System;
class Program
{
    static void Main(string[] args)
    { 
        //read input:
      int n = int.Parse(Console.ReadLine());
      HashSet<string> usernames = new HashSet<string>(); //hashset to store usernames

        for (int i = 0; i < n; i++)
        {
            usernames.Add(Console.ReadLine()); //adding usernames to the hashset in order of entry
        }

        Console.WriteLine(string.Join(Environment.NewLine, usernames)); //printing output
    }
}
