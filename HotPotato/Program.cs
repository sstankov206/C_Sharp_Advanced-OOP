/* Children form a circle and pass a hot potato clockwise
 * Every Nth toss a child is removed until only one remains
 * Upon removal the potato is passed along
 * Print the child that remains last
 * 
 * Example:
 * 
 * INPUT:       Alva James William
 *                      2
 *                      
 * OUTPUT:      Removed James
 *              Removed Alva
 *              Last is William
 *              
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //reading input:
        string input = Console.ReadLine();

        //get number of tosses via input:
        int tosses = int.Parse(Console.ReadLine());

        //creating a queue to store children's names:
        Queue<string> kids = new Queue<string>(input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries));

        //toss WHILE number of kids left is > 1:
        while (kids.Count > 1)
        {
            for (int i = 1; i < tosses; i++) //starting at 1, since 0 is 1
            {
                string kid = kids.Dequeue(); //removing from back of line
                kids.Enqueue(kid); //adding to front of line
            }

            Console.WriteLine($"Removed {kids.Dequeue()}"); //removing a child from the queue
        }

        //printing output:
        Console.WriteLine($"Last is {kids.Dequeue()}"); //prints the last remaining kid

    }
}

