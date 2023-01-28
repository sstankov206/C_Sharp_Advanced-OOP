/* We are given an arithmetic expression with brackets. Scan through 
 * the string and extract each sub-expression.
 * Print the result back at the terminal.
 * 
 * Examples:
 * INPUT:       (3 + 4) - (1 + 2)
 * OUTPUT:      (3 + 4)
 *              (1 + 2)
 *
 *Solution by me, sstankov.
 */

using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //read input:
        string input = Console.ReadLine();

        //create an int Stack, to store indexes of the array:
        Stack<int> stack = new Stack<int>();

        //iterate through the input:
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(') //if index contains "(" symbol:
            {
                stack.Push(i); //add it to the Stack
            }
            else if (input[i] == ')') //if index contains ")" symbol:
            {
                int start = stack.Pop();//remove it from the stack
                //print output: 
                Console.WriteLine(input.Substring(start, i - start + 1));
            }
        }
    }
}


