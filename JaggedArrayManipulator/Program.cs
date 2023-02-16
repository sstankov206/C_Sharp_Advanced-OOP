/* Create a program that populates, analyzes and manipulates the elements of a matrix
 * with unequal length of its rows.
 * 
 * First you will receive an integer "N" equal to the number of rows in your matrix.
 * 
 * On the next "N" lines, you will receive sequences of integers, separated by a single
 * space. Each sequence is a row in the matrix.
 * 
 * After populating the matrix, start analyzing it. If a row and the one below it have 
 * equal length, multiply each element in both of them by 2, otherwise - divide by 2.
 * 
 * Then, you will receive commands. Ther are 3 possible commands:
 * - "Add {row} {column} {value}" - add {value} to the element at the given indexes, 
 * if they are valid
 * - "Subtract {row} {column} {value}" - subtract {value} from the element at the given
 * indexes, if they are valid
 * - "End" - print the final state of the matrix (all elements separated by a single space)
 * and stop the program
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
       double[][] matrix = new double[rows][];

        for (int row = 0; row < rows; row++)
        {
            double[] rowValues = Console.ReadLine().Split().Select(double.Parse).ToArray();
            matrix[row] = rowValues;
        }

        for (int row = 0; row < rows - 1; row++)
        {
            double[] rowOne = matrix[row];
            double[] rowTwo = matrix[row + 1];

            if (rowOne.Length == rowTwo.Length)
            {
                matrix[row] = rowOne.Select(e => e * 2).ToArray();
                matrix[row +1] = rowTwo.Select(e => e * 2).ToArray();
            }
            else
            {
                matrix[row] = rowOne.Select(e => e / 2).ToArray();
                matrix[row + 1] = rowTwo.Select(e => e / 2).ToArray();
            }
        }

        string commandInput = Console.ReadLine();

        while (commandInput != "End")
        {
            string[] tokens = commandInput.Split();
            string command = tokens[0];
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            int values = int.Parse(tokens[3]);

            if (!isValidCell(matrix, row, col))
            {
                commandInput = Console.ReadLine();
                continue;
            }

            if (command == "Add")
            {
                matrix[row][col] += values;
            }
            else
            {
                matrix[row][col] -= values;

            }

            commandInput = Console.ReadLine();
        }

        for (int row = 0; row < rows; row++)
        {
            Console.WriteLine(string.Join(" ", matrix[row]));
        }
    }

    static bool isValidCell(double[][] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
    }
    
}
