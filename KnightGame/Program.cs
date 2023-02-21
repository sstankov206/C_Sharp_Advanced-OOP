/* The Knight game is played on a board with dimensions N x N and a lot of chess
 * knights O <= K <= N^2.
 * 
 * You will receive a board with K for knights and 'O' for empty cells. Your task
 * is to remove a minimum of the knights, so there will be no knights left that
 * can attack another knight.
 * 
 * INPUT - On the first line, you will receive N size of the board
 * - On the next N lines, you will receive strings with Ks and Os.
 * 
 * OUTPUT - Print a single integer with the minimum number of knights that need
 * to be removed.
 * 
 * Constraints - Size of the board wil lbe O < N < 30; Time limit: 0.3sec. Memory
 * limit: 16MB.
 * 
 * Example:
 * 
 * INPUT:       2
 *              KK
 *              KK
 *              
 * OUTPUT:      0             
 * 
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); //get size of board
        char[,] matrix = new char[n, n];


        //iterate through the matrx, receive strings of K's and O's:
        for (int row = 0; row < n; row++)
        {
            char[] rowValues = Console.ReadLine().ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = rowValues[col];
            }
        }

        int counter = 0;

        while (true) //iterating through the matrix and removing all Knights
        {
            int maxtAttackedKnights = 0; //counter for maximum Knights to be removed
            int maxAttackedKnightsRow = -1;
            int maxAttackedKnightsCol = -1;

            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    char ch = matrix[row, col];

                    if (ch == 'K') //check for Knights
                    {
                        int currentAttackedKnights = GetCountAttackedKnights(matrix, row, col);

                        if (currentAttackedKnights > maxtAttackedKnights)
                        {
                            maxtAttackedKnights = currentAttackedKnights;
                            maxAttackedKnightsRow = row;
                            maxAttackedKnightsCol = col;
                        }
                    }
                }
            }

            if (maxtAttackedKnights == 0)
            {
                break;
            }

            matrix[maxAttackedKnightsRow, maxAttackedKnightsCol] = '0';
            counter++;

            Console.WriteLine(counter);
        }
    }

    static int GetCountAttackedKnights(char[,] matrix, int row, int col)
    {
        int counter = 0;
        int n = matrix.GetLength(0);

        //up:

        if (row - 2 >= 0 && col - 1 >= 0 && matrix[row - 2, col - 1] == 'K')
        {
            counter++;
        }

        if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1] == 'K')
        {
            counter++;
        }

        if (row - 1 >= 0 && col - 2 >= 0 && matrix[row - 1, col - 2] == 'K')
        {
            counter++;
        }

        if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
        {
            counter++;
        }

        //down:
        if (row + 1 < n && col - 2 >= 0 && matrix[row + 1, col - 2] == 'K')
        {
            counter++;
        }

        if (row + 1 < n && col + 2 >= 0 && matrix[row + 1, col + 2] == 'K')
        {
            counter++;
        }

        if (row + 2 < n && col - 1 >= 0 && matrix[row + 2, col - 1] == 'K')
        {
            counter++;
        }

        if (row + 2 < n && col + 1 >= 0 && matrix[row + 2, col + 1] == 'K')
        {
            counter++;
        }

        return counter;

    }
}
