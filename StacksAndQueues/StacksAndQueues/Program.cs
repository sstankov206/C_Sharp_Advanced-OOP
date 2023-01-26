/* Create a program that:
 *  - Reads an input string
 *  - Reverses it using a Stack
 *  
 *  Examples:
 *  INPUT:      I Love C#
 *  OUTPUT:     #C evoL I
 *  
 *  solution by me, sstankov
 */


using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine(); //reading string of input

        //creating Stack of chars to store the string which is to be reversed:
        Stack<char> stack = new Stack<char>();

        //iterate through the string:
        for (int i = 0; i < input.Length; i++)
        {
            stack.Push(input[i]); //add corresponding elements to the stack
        }

        while (stack.Count > 0) //remove elements from the stack until count = 0:
        {
            Console.Write(stack.Pop()); //print the output
        }
    }
}