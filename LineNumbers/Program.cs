/* Read your "Input.txt" file
 * Insert a number in fron of each line of the file
 * Save it in "Output.txt" file
 */


using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine("data", "input.txt");
        string dest = Path.Combine("data", "output.txt");
        var lines = File.ReadAllLines(path);
        int counter = 1; //beginning to count from 1st line
        string[] output = new string[lines.Length]; //creating string array to store the ouput
        //(output will be the lines of text with numbers preceeding them)

        foreach (var line in lines) //iterating through lines of Input file
        {
           output[counter - 1] = $"{counter}. {line}";
            counter++;
        }

        File.WriteAllLines(dest, output);
    }
}