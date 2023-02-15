/* Create a program that can shuffle a matrix.
 * 
 * If the command is not valid (doesn't contain the keyword "swap", has fewer or
 * more coordinates entered or the given coordinates do not exist), 
 * print "Invalid input!" and move on to the next command.
 * Your program should finish when the string "END" is entered.
 * 
 * Examples:
 * 
 * INPUT:       2 3
 *              1 2 3
 *              4 5 6
 *              swap 0 0 1 1
 *              swap 10 9 8 7
 *              swap 0 1 1 0
 *              END
 *              
 * OUTPUT:      5 2 3
 *              4 1 6
 *              Invalid input!
 *              5 3 3
 *              2 1 6
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray(); //read input
        int rows = dimensions[0]; //set number of rows
        int cols = dimensions[1]; //set number of columns

        string[,] matrix = new string[rows, cols]; //create matrix from rows and cols from split input


        //iterate through the matrix:
        for (int row = 0; row < rows; row++)
        {
            string[] rowValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowValues[col];
            }
        }

        string commandInput = Console.ReadLine(); //read input

        while (commandInput != "END") //while input IST'T = "END":
        {
            string[] tokens = commandInput.Split(); //split input by space
            //validation check -- check if there are 4 coordinates OR if input contains keyword "swap":
            if (tokens[0] != "swap" || tokens.Length != 5)
            {
                commandInput = Console.ReadLine();
                Console.WriteLine("Invalid input!");
                continue;
            }

            int rowOne = int.Parse(tokens[1]);
            int colOne = int.Parse(tokens[2]);
            int rowTwo = int.Parse(tokens[3]);
            int colTwo = int.Parse(tokens[4]);

            bool isValidFirstCoordinates = ValidateCell(matrix, rowOne, colOne);
            bool isValidSecondCoordinates = ValidateCell(matrix, rowTwo, colTwo);

            if (!isValidFirstCoordinates || !isValidSecondCoordinates)
            {
                commandInput = Console.ReadLine();
                Console.WriteLine("Invalid input!");
                continue;
            }

            //swapping coordiantes:
            string temp = matrix[rowOne, colOne];
            matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
            matrix[rowTwo, colTwo] = temp;

            //print the matrix, after each iteration:
            Print(matrix);



            commandInput = Console.ReadLine(); //keep reading input


        }
    }

    //create a method that will validate the coordinates:
    private static void Print(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.WriteLine(matrix[row, col] + " ");
            }

            Console.WriteLine();
        }
    }

    private static bool ValidateCell(string[,] matrix, int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }


}
