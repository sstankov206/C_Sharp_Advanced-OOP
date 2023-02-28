/*Write a program that stores information about food shops
 * If you receive a shop's name you already have received, add the product
 * Your output must be ordered by shop name
 * When you receive "Revision", print the output
 * 
 * Example:
 * 
 * INPUT:       Lidl, juice, 2.30
 *              Kaufland, banana, 1.10
 *              Lidl, grape, 2.20
 *              Revision
 *              
 * OUTPUT:      Kaufland ->
 *              Product: banana, Price: 1.1
 *              Lidl ->
 *              Product: juice, Price: 2.3
 *              Product: grape, Price: 2.2
 *              
 * Solution by me, sstankov.
 */

using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       //creating sorted dictionary to store the shop names and their products:
        SortedDictionary<string, Dictionary<string, decimal>> shops = new SortedDictionary<string, Dictionary<string, decimal>>();
        string input = Console.ReadLine(); //read input


        //filling the dictionary with input:
        while (input != "Revision") //as long as input ISN'T equal to "Revision:
        {
            //create array to store split input, separated by comma & space:
            string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            if (!shops.ContainsKey(tokens[0])) //if the store name (key) ISN'T contained in the dictionary:
            {
                shops[tokens[0]] = new Dictionary<string, decimal>(); //add the shop as a new key
            }

            shops[tokens[0]].Add(tokens[1], decimal.Parse(tokens[2])); //add the product & its price
            
            input = Console.ReadLine();
        }

        //printing output:

        foreach (var shop in shops)
        {
            Console.WriteLine($"{shop.Key}->");
            foreach (var product in shop.Value)
            {
                Console.WriteLine($"Product: {product.Key}, Price: {(double)product.Value}");
            }
        }

    }
}