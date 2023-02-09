/* Find 2x2 square with max sum in given matrix
 * - Read matrix from the console
 * - Print the result like a new matrix

Solution by me, sstankov.
*/

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
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

        int maxSum = int.MinValue; //will store the max sum
        int maxSumRow = -1;
        int maxSumCol = -1;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col]; //sum equal current element
                sum += matrix[row, col + 1];
                sum += matrix[row + 1, col];
                sum += matrix[row + 1, col + 1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumCol = col;
                    maxSumRow = row;
                }
            }
        }
        //printing output:

        //printing the square:
        Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
        Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");

        //printing the maximum sum:
        Console.WriteLine(maxSum);
    }
}



