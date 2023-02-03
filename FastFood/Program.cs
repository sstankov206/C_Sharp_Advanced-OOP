/* Print the quantity of biggest order
 * Print "Orders complete" if the orders are complete
 * If there are orders left, print them in them in the correct format
 * Contraints: the input will always be valid
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //set total amount of food available to cook:
        int totalQuantity = int.Parse(Console.ReadLine());
        //read input of orders,split input and store orders in array:
        int[] ordersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //use a queue to read the orders:
        Queue<int> orders = new Queue<int>(ordersArr);
        //using int variable to store the biggest order:
        int biggestOrder = 0;

        while (orders.Any())
        {
            int currentOrder = orders.Peek(); //check requirements for next order in queue

            if (currentOrder > biggestOrder)
            {
                currentOrder = biggestOrder; //set the value of the biggest order
            }

            if (totalQuantity <= currentOrder) //if we have less food than the order requires, break.
            {
                break;
            }

            orders.Dequeue(); //removes the order from the queue
            totalQuantity -= currentOrder; //removes the current order from total amount of food available.

            Console.WriteLine(biggestOrder); //prints the biggest order

        }

        if (orders.Any()) //if any orders are left in the queue:
        {
            //print the remaining orders left:
            Console.WriteLine($"Orders left: {string.Join(separator: " ", orders)}");
        }
        else
        { //else, if no remaining orders, print:
            Console.WriteLine("Orders complete");
        }
    }
}

