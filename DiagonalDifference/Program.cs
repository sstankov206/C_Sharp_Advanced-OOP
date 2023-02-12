/* Write a program that find the difference between the sums of the 
 * square matrix diagonals (absolute value)
 *
 * Example:
 *
 * Matrix :    11  2  4
 *             4   5  6
 *            10   8 -12
 *              
 *        
 * Primary diagonal: sum = 11 + 5 - 12 = 4    
 * 
 * Secondary diagonal: sum = 4 + 5 + 10 = 19
 * 
 * Difference: |4 - 19 | = 15
 * 
 * INPUT:  - On the first line, you are given the integer 'N' - the size of the square matrix
 *      - The next N lines holds the values for every row - N numbers separated by a space
 *      
 * OUTPUT:  - Print the absolute difference between the sums of the primary and the secondary
 * diagonal 
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //reading input:
        int n = int.Parse(Console.ReadLine());

        //creating 2-dimensional array from 'n' :
        int[,] matrix = new int[n, n];

        //iterating through the array:
        for (int row = 0; row < n; row++)
        {
            int[] rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = rowValues[col];
            }
        }

        int sumFirstDiagonal = 0; //store the sum of the 1st diagonal
        int sumSecondDiagonal = 0; //store the sum of the 2nd diagonal
        int counter = n - 1;

        for (int row = 0; row < n; row++)
        {
            sumFirstDiagonal += matrix[row, row]; //increase the sum of the 1st diagonal
            sumSecondDiagonal += matrix[row, counter--]; //increase the sum of the 2nd diagonal
        }

        //printing output:
        Console.WriteLine(Math.Abs(sumFirstDiagonal - sumSecondDiagonal));
        //returns the absolute value of the sum of the 2 diagonals
    }
}
