/* - Read the content from your "input.txt" file
-   Print the ODD lines on the console
-  Counting starts from 0
- Store output in "output.txt" file

Example:

INPUT:

Two households, both alike in dignity,
In fair Verona, where we lay our scene,
From ancient grudge break to new mutiny,
Where civil blood makes civil hands unclean.

OUTPUT:

In fair Verona, where we lay our scene,
Where civil blood makes civil hands unclean.

*/

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var path = Path.Combine("data", "input.txt");//referencing "input.txt" file
        var dest = Path.Combine("data", "output.txt"); //referencing "output.txt" file

        using (FileStream file = new FileStream(path, FileMode.Open))
        {
            using (TextReader text = new StreamReader(file))
            {
                using (FileStream destFile = new FileStream(dest, FileMode.Create))
                {
                    using (TextWriter writer = new StreamWriter(destFile))
                    {
                        string line = text.ReadLine();
                        int lineNumber = 0;

                        while (line != null)
                        {
                            if (lineNumber % 2 != 0) //looking for odd lines
                            {
                               writer.WriteLine(line); //printing odd lines
                            }
                            lineNumber++;
                            line = text.ReadLine();
                        }
                    }                
                }
               
            }
        }
    }
}
