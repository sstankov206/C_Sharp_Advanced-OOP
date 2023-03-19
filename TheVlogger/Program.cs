/* Create a program that keeps information about vloggers and their followers. The input will come as a sequence of 
 * strings, where each string will represent a valid command. The commands will be presented in the following
 * format:
 * 
 *  - "{vloggername}" joined the V-Logger - keep the vlogger in your records.
 *     - Vloggernames consist of only one word.
 *     - If the given vloggername already exists, ignore that command.
 *     
 *  - "{vloggername}" followed {vloggername}" - The first vlogger followed the second vlogger.
 *     - If ANY of the given vloggernames do NOT exist in your collection, ignore that command
 *     - Vlogger cannot himself
 *     - Vlogger cannot follow someone he is already a follower of
 *     
 *  - "Statistics" - Upon receiving this command, you have to print a statistic about the vlogger   
 * 
 */

using System;
class Program
{ 
    static void Main(string[] args)
    {
        string inputCommand = Console.ReadLine(); //reads input
        Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
        //app[vloggerName] ["followers"] -> SortedSet<vloggers>
        //app[vloggerName] ["following"] -> SortedSet<vloggers>

        //read input until you receive the "Statistics" command:
        while (inputCommand != "Statistics")
        {
            string[] tokens = inputCommand.Split();
            string vloggerName = tokens[0]; //set vlogger's name to 1st element of array

            if (tokens[1] == "joined")
            {
                if (!app.ContainsKey(vloggerName)) //if vlogger's name is NOT found:
                {
                    app.Add(vloggerName, new Dictionary<string, SortedSet<string>>()); //add them
                    app[vloggerName].Add("followers", new SortedSet<string>()); //adds the # of their followers
                    app[vloggerName].Add("following", new SortedSet<string>()); //add the # of vloggers they follow
                }
            }
            else
            {
                string vloggerNameTwo = tokens[2];

                if (vloggerName == vloggerNameTwo || !app.ContainsKey(vloggerName) || !app.ContainsKey(vloggerNameTwo))
                    //if 2nd vlogger's name is NOT found:
                {
                    inputCommand = Console.ReadLine();
                    continue;
                }


                Dictionary<string, SortedSet<string>> temp = app[vloggerName];
                app[vloggerName]["following"].Add(vloggerNameTwo);
                app[vloggerNameTwo]["followers"].Add(vloggerName);
            }
            
            inputCommand = Console.ReadLine();
        }

        //printing output:

        Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs."); //prints total count of vloggers
        int counter = 1;

        app = app.OrderByDescending(kvp => kvp.Value["followers"].Count)
            .ThenBy(kvp => kvp.Value["following"].Count)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach ((string vlogger, Dictionary<string, SortedSet<string>> vloggerProfile)  in app)
        {
            Console.WriteLine($"{counter++}. {vlogger} : {vloggerProfile["followers"].Count} followers, " +
                $"{vloggerProfile["following"].Count} following"); //print the number of followers and # of people the vlogger follows

            if (counter == 2)
            {
                foreach (string f in vloggerProfile["followers"])
                {
                    Console.WriteLine($"*  {f}");
                }
            }
        }






    }
}