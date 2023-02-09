/* - Read matrix sizes
 * - Read a matrix from the console
 * - Print the sum of all numbers in matrix columns
 * 
 * Example:
 * 
 * INPUT:       3, 6
 *              7 1 3 3 2 1
 *              1 3 9 8 5 6
 *              4 6 7 9 1 0
 *              
 * OUTPUT:      12
 *              10
 *              19
 *              20
 *              8
 *              7
 *                        
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //read input from console, split by space, store in array:
        int[] size = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

        //create multidimensional array with specified size of rows and columns:
        int[,] matrix = new int[size[0], size[1]];

        //iterate through the rows:
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] currentRow = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray(); //add elements at each row

            //iterate through the columns:
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col]; //add elements for each column
            }
        }

        //iterate through the columns:
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int sum = 0; //this will store the sum of the elements at every column
            //resets the sum to zero (0) every turn of the cycle

            //iterate through the rows:
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col]; //increase the sum
            }

            Console.WriteLine(sum); //printing the total sum
        }
    }
}
