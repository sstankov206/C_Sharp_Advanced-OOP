/* Suppose there is a circle. There are N pentrol pumps on that circle, numbered
 * 0 to (N-1) (both inclusive). You have 2 pieces of information corresponding to
 * each of the petrol pump:
 * (1) the amount of petrol that patricular pump will give
 * (2) the distance from that petrol pump to the next petrol pump
 * 
 * Initially, you have a tank of infinite capacity carrying no petrol. You can start
 * the tour at ANY of the petrol pumps. Calculate the FIRST POINT from where the truck
 * will be able to complete the circle. Consider that the truck will stop at EACH
 * of the petrol pumps. The truck will move one kilometer for each liter of petrol.
 * 
 * INPUT:
 * - The first line will contain the value of N
 * - The next N lines will contain a pair of integers each, i.e. the amount of petrol
 * that petrol pumps will give and the distance between that petrol pump and the next
 * petrol pump
 * 
 * OUTPUT:
 * - An integer which will be the smallest index of the petrol pump from which we
 * can start the tour
 * 
 * Examples:
- INPUT:        3
                1  5
                10 3
                3  4

- OUTPUT:       1

Solution by me, sstankov.
*/

using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //read value of N via input:
        int n = int.Parse(Console.ReadLine());

        //creating a queue to store petrol pumps info:
        Queue<string> pumps = new Queue<string>();

        for (int i = 0; i < n; i++)
        {
            pumps.Enqueue(Console.ReadLine()); //add info about pumps from input
        }

        //int value to store the index (smallest index of the petrol pump from which we
        //can start the tour), which is our goal & output at the end:
        int index = 0;

        int length = pumps.Count;

        for (int i = 0; i < length; i++)
        {
            //int value to store the total amount of petrol:
            int totalAmount = 0;
            bool isCompleted = true; //this will keep track of when the amount of cycles = amount of pumps


            for (int j = 0; j < length; j++)
            {
                string currentPump = pumps.Dequeue();
                int[] currentPumpsValues = currentPump.Split().Select(int.Parse).ToArray();
                int currentAmount = currentPumpsValues[0];
                int distance = currentPumpsValues[1];

                totalAmount += currentAmount;

                if (totalAmount >= distance)
                {
                    totalAmount -= distance;
                }
                else
                {
                    isCompleted = false;
                }

                pumps.Enqueue(currentPump);

                if (isCompleted)
                {
                    index = i;
                    break;
                }
            }
            pumps.Enqueue(pumps.Dequeue()); //reordering of pumps - 1st one goes to back of line/queue

        }
        //print output:
        Console.WriteLine(index); //prints the smallest index
    }
}



