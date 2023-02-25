/* Write a program to read student names + grades
 *  Print the grades + average grade for each student
 *  
 *  Examples:
 *  
 *  INPUT:          6
 *                  Ivan 5.20
 *                  Maria 5.50
 *                  Maria 2.50
 *                  Steve 2.00
 *                  Maria 3.46
 *                  Steve 3.00
 *                  
 * OUTPUT:          Ivan -> 5.20 (avg: 5.20)
 *                  Maria -> 5.50 2.50 3.46 (avg: 3.82)
 *                  Steve -> 2.00 3.00 (avg: 2.50)
 *                  
 *   Solution by me, sstaknov.
 */

using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int numberOfRecords = int.Parse(Console.ReadLine()); //get input of number of records of grades
        //create a dictionary to store the records:
        Dictionary<string, List<double>> gradebook  = new Dictionary<string,List<double>>();

        //iterate through the records:
        for (int i = 0; i < numberOfRecords; i++)
        {
            //array to store the names of students and their grades, taken from the input:
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (gradebook.ContainsKey(tokens[0])) //if key (name) already exists in dictionary, add the grade:
            {
                gradebook[tokens[0]].Add(double.Parse(tokens[1])); 
            }
            else //else, create a new list under that key (name) and add their first grade:
            {
                gradebook.Add(tokens[0], new List<double>() {double.Parse(tokens[1])});
            }
        }

        //printing output:
        foreach (var item in gradebook)
        {
            Console.WriteLine($"{item.Key} -> {string.Join(' ', item.Value)} (avg: {item.Value.Average():f2})");
        }
    }
}
