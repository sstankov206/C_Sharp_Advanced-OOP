/* On the first line you will get rows
 * - on the next lines you will get elements for each row
 * - Until you receie "END", read commandds:
 *   - Add {row} {col} {value}
 *   - Subtract {row} {col} {value}
 * If the coordinates are invalid print: "Invalid coordinates"
 * When you receive "END" you should print the jagged array
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine()); //get number of rows via input

        int[][] jaggedArr = new int[rows][]; //define the jagged array

        //iterating through the jagged array:
        for (int i = 0; i < rows; i++)
        {
            //filling up the array:
            jaggedArr[i] = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }

        //reading commands:
        string[] tokens = Console.ReadLine()
            .Split(' ');

        while (tokens[0] != "END")
        {
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);
            //check for invalid coordinates:
            if (row < 0 || row >= rows || col < 0 || col >= jaggedArr[row].Length)
            {
                Console.WriteLine("Invalid coordinates");
            }
            else
            {
                switch (tokens[0])
                {
                    case "Add":
                        jaggedArr[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedArr[row][col] -= value;
                        break;
                    default:
                        break;
                }
            }

            tokens = Console.ReadLine()
                .Split(' ');
        }

        //printing output:

        foreach (int[] row in jaggedArr)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }
}

