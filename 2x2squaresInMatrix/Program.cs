/* Find the court of a 2x2 squares of equal chars in a matrix
 * 
 * INPUT:
 * - On the first line, you are given the integers 'rows' and 'cols' - the matrix's
 * dimensions
 * - Matrix characters come at the next 'rows' lines (space separated)
 * 
 * OUTPUT:
 * - Print the number of all the squares matrixes you have found
 * 
 * EXAMPLES:
 * 
 * INPUT:   3  4
 *         A B B D
 *         E B B B
 *         I J B B
 *         
 * OUTPUT:   2
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //read input
        int rows = dimensions[0]; //set number of rows
        int cols = dimensions[1]; //set number of columns

        char[,] matrix = new char[rows, cols]; //create matrix from rows and cols from split input


        //iterate through the matrix:
        for (int row = 0; row < rows; row++)
        {
            char[] rowValues = Console.ReadLine().Split().Select(char.Parse).ToArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowValues[col];
            }
        }

        int counter = 0; //counter for the total number of squares found in the matrix

        for (int row = 0; row < rows - 1; row++)
        {

            for (int col = 0; col < cols - 1; col++)
            {
                char ch = matrix[row, col];

                //check if elements are equal to each other, indicating a square:
                if (ch == matrix[row, col + 1] && ch == matrix[row + 1, col] &&
                    ch == matrix[row + 1, col + 1])
                {
                    counter++; //increase the counter of total squares
                }
            }
        }

        Console.WriteLine(counter);
    }
}
