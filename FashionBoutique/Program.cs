/* INPUT:
 * -  On the first line you will be given a sequence of integers, representing the
 * clothes in the box, separated by a single space
 * - On the second line, you will be given an integr, representing the capacity
 * of a rack
 * 
 * OUTPUT:
 * - Print the number of racks, needed to hang all of the clothes from the box
 * 
 * CONSTRAINTS:
 * - The values of the clothes will be integers in the range [0,20]
 * - There will never be more than 50 clothes in a box
 * - The capacity will be an integer in the range [0,20]
 * - None of the integers from the box will be greater than the value of the capacity
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //read input and split by space, store in array:
        int[] clothesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //create stack to store the input of boxes:
        Stack<int> boxes = new Stack<int>(clothesArr);

        //read capacity of rack, given via console input:
        int rackCapacity = int.Parse(Console.ReadLine());
        //int variable to store the amount of racks:
        int racksCount = 1;
        int currentRackCapacity = rackCapacity;

        while (boxes.Count > 0) //while we have clothes on the rack:
        {
            int currentClothes = boxes.Peek();

            if (currentRackCapacity >= currentClothes) //if we have sufficient rack capacity for the clothes:
            {
                currentRackCapacity -= currentRackCapacity; //decrease the current rack capacity
                boxes.Pop(); //remove clothes from rack
            }
            else
            {
                racksCount++; //increase the amount of racks
                currentRackCapacity = rackCapacity; //resets rack's capacity
            }
        }
        //print output:
        Console.WriteLine(racksCount);
    }
}
