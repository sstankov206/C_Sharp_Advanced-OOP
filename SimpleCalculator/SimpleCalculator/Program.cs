/* Implement a simple calculator that can evaluate simple expressions
(only addition and subtraction), using a Stack.

Example:

INPUT:      2 + 5 + 10 - 2 - 1
OUTPUT:     14

Solution by me, sstankov.
*/

using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //read input:
        string input = Console.ReadLine();

        //create a Stack of strings to store the input
        //split the input by space & reverse it:
        Stack<string> stack = new Stack<string>(input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Reverse());

        //since the last element left will be the result/output,
        //we can use stack.Count > 1
        while (stack.Count > 1)
        {
            int operand1 = int.Parse(stack.Pop()); //Ex: 2
            string operatr = stack.Pop(); //operator (Ex: "+")
            int operand2 = int.Parse(stack.Pop()); //Ex: 1

            switch (operatr)
            {
                case "+":
                    stack.Push((operand1 + operand2).ToString());
                    break;
                case "-":
                    stack.Push((operand1 - operand2).ToString());
                    break;
                default:
                    throw new ArgumentException("Unknown operator");
            }
        }

        //priting output:
        Console.WriteLine(stack.Pop());


    }
}
