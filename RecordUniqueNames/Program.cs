/* Read a sequence of names and print only the unique ones
 * 
 * Example:
 * 
 * INPUT:       Ivan
 *              Peter
 *              Ivan
 *              Steve
 *              Peter
 *              Alice
 *              Phil
 *              Peter
 *              
 * OUTPUT:     Steve
 *             Alice
 *             Phil
 *             Peter
 *             
 * Solution by me, sstankov.
 */

using System;
class Program
{
    static void Main(string[] args)
    { 
    //creating a HashSet to store unique values:
    var names = new HashSet<string>();

        var n = int.Parse(Console.ReadLine()); //reading input
        for (int i = 0; i < n; i++) //iterate through the number of names
        {
            var name = Console.ReadLine(); //iterate through each name (take each name via input)
            names.Add(name); //add name (adds non-existing names only)
        }
        //printing output:
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}
