/* Write a program, which prints on the console a Pascal Triangle

Solution by me, sstankov.
*/

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine()); //reading input
        int currentLength = 1;

        int[][] triangle = new int[rows][]; //creating jagged array to store the triangle

        //iterating through the array and filling it:
        for (int i = 0; i < rows; i++)
        {
            triangle[i] = new int[currentLength];
            triangle[i][0] = 1; //setting first elements to always equal '1'
            triangle[i][currentLength - 1] = 1; //setting the last elements to always equal '1'

            //check whether the current row has more than 2 elements:
            if (currentLength > 2)
            {
                for (int j = 1; j < currentLength - 1; j++) //not using the 1st or last element
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j]; //formula

                }

            }

            currentLength++;
        }

        //printing output (in the form of a jagged array) :

        foreach (int[] row in triangle)
        {
            Console.WriteLine(string.Join(' ', row));
        }

    }
}
