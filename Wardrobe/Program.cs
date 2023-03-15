/* Write a program that helps you decide what clothes to waer from your wardrobe. You will receive the clothes,
 * which are currently in your wardrobe, sorted by their color in the following format:
 * 
 * "{color} -> {item1),{item2},{item3}..."
 * 
 * If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records.
 * You can also receive repeating items for certain color and you have to keep their COUNT.
 * 
 * In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated
 * by a space in the following format:
 * 
 * "{color} {clothing}"
 * 
 * Your task is to print all the items and their COUNT for each color in the following format:
 * "{color} clothes:
 *   * {item1} - {count}
 *   * {item2} - {count}
 *   * {item3} - {count}
 *  ...
 *   * {itemN} - {count}"
 * 
 * If you find the item you are looking for, you need print "(found!)" next to it:
 * "* {itemN} - {count} (found!)"
 * 
 * INPUT:       - On the first line, you will receive N - the number of lines of clothes, which you will
 * receive.
 *             - On the next n lines, you will receive the clothes in the format described above.
 *             
 * OUTPUT:      - Print the clothes from your wardrobe in the format described above. 
 * 
 * 
 * Example:
 * 
 * INPUT:       4
 *              Blue -> dress,jeans,hat
 *              Gold -> dress,t-shirt,boxers
 *              White -> briefs,tanktop
 *              Blue -> gloves
 *              Blue dress
 *              
 * OUTPUT:      Blue clothes:
 *              * dress - 1 (found!)
 *              * jeans - 1
 *              * hat - 1
 *              * gloves - 1
 *              Gold clothes:
 *              * dress - 1 
 *              * t-shirt - 1
 *              * boxers - 1
 *              White clothes:
 *              * briefs - 1
 *              * tanktop - 1
 *              
 */

using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // Key -> color, value -> Dictionary<clothes, counter>
        Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().
                Split(new string[] { " -> ", "," }, StringSplitOptions.None);

            string color = tokens[0];

            if (!data.ContainsKey(color)) //if the color is not found in the dictionary:
            {
                data.Add(color, new Dictionary<string, int>()); //add it as a new entry
            }


            Dictionary<string, int> temp = data[color];

            for (int j = 0; j < tokens.Length; j++)
            {
                string currentClothes = tokens[j];

                //checking if there is a color for a particular clothing article:
                if (!data[color].ContainsKey(currentClothes)) //if article of clothing is not found:
                {
                    data[color].Add(currentClothes, 0); //add the clothing article
                }

                data[color][currentClothes]++; //increase the counter, if already present
            }
        }

        string[] searchedData = Console.ReadLine().Split();
        string searchedColor = searchedData[0];
        string searchedClothes = searchedData[1];

        //printing output"

        foreach ((string color, Dictionary<string, int> clothesData) in data)
        {
            Console.WriteLine($"{color} clothes:");

            foreach ((string c, int counter) in clothesData)
            {
                if (searchedColor == color && searchedClothes == c)
                {
                    Console.WriteLine($"* {c} - {counter} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {c} - {counter}");
                }
            }
        }
    }
}
