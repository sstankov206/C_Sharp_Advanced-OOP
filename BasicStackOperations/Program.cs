using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //read input from console, split by space & store in array:
        int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int x = data[0]; //variable 'x' is the 1st element
        int s = data[1]; //variable 's' is the 2nd element
        int n = data[2]; //variable 'n' is the 3rd element

        //read input of numbers, split by space & store in array:
        int[] numsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> nums = new Stack<int>(); //creating stack to stack input of numbers

        for (int i = 0; i < n; i++)
        {
            nums.Push(numsArray[i]); //keep adding numbers to stack as long as i<n
        }

        for (int i = 0; i < s; i++) //remove numbers from top of stack as long as i<s
        {
            nums.Pop();
        }

        if (nums.Contains(x))
        {
            Console.WriteLine("true"); //prints 'true' if 'x' is found in stack
        }
        else if (nums.Count == 0)
        {
            Console.WriteLine(0); //prints '0' if there are no numbers left in the stack
        }
        else
        {
            Console.WriteLine(nums.Min());  //prints the smallest number from the stack
        }


    }
}


