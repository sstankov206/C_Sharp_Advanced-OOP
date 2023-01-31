/* Cars are queuing up at a traffic light
 * Every green light N cars pass the crossroads
 * After the 'end' command, print how many cars have passed
 * 
 * Example:
 * 
 * INPUT:       3
 *              Enzo's car
 *              Jade's car
 *              Mercedes CLS
 *              Audi
 *              green
 *              BMW X5
 *              green
 *              end
 *              
 * OUTPUT:      Enzo's car passed
 *              Jade's car passed
 *              Mercedes CLS passed!
 *              Audi passed!
 *              BMW X5 passed!
 *              5 cars passed the crossroads.
 *              
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //number of light cycles:
        int count = int.Parse(Console.ReadLine());

        //read input:
        string token = Console.ReadLine();

        //creating queue to store the cars:
        Queue<string> cars = new Queue<string>();
        //create counter to keep track of number of cars that cross:
        int counter = 0;

        //while the input ISN'T = "end":
        while (token.ToLower() != "end")
        {
            //while input ISN'T = "green":
            if (token.ToLower() != "green")
            {
                cars.Enqueue(token); //add to queue
            }
            else //else, if input = "green":
            {
                for (int i = 0; i < count; i++)
                {
                    string car;

                    if (cars.TryDequeue(out car))
                    {
                        Console.WriteLine($"{car} passed!");
                        counter++;
                    }
                }
            }
            token = Console.ReadLine();
        }

        //printing output:
        Console.WriteLine($"{counter} cars passed the crossroads.");
    }
}

