/* - Read a matrix from the console
 * - Print the number of rows
 * - Print the number of columns
 * - Print the SUM OF ALL NUMBERS in the matrix

Example:

INPUT:          3, 6
                7, 1, 3, 3, 2, 1
                1, 3, 9, 8, 5, 6
                4, 6, 7, 9, 1, 0

OUTPUT:         3
                6
                76

Solution by me, sstankov.
*/

using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //read input from console, split by comma & space, store in array:
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
                .Split(", ")
                .Select(int.Parse)
                .ToArray(); //add elements at each row

            //iterate through the columns:
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = currentRow[col]; //add elements for each column
            }
        }
        //Printing Output:

        Console.WriteLine(size[0]); //prints the number of rows
        Console.WriteLine(size[1]); //prints the number of columns
        int sum = 0;

        foreach (var item in matrix)
        {
            sum += item; //will store the sum of all elements in the matrix
        }
        Console.WriteLine(sum); //prints the sum of all elements in the matrix
    }
}

