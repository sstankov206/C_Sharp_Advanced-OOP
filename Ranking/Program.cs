/* Write a program that RANKS candidate-interns, depending on the points from the interview tasks and their exam
 * rsults in SoftUni. You will receive some lines of input in the format
 * "{contest}:{password for contest}"
 * until you receive "end of contests". Save that data because you will need it later. After that you will receive
 * other type of inputs in format "{contest}=>{password}=>{username}=>{points}" until you receive "end of submissions".
 * Here is what you need to do:
 * - Check if the contest is valid (if you received it in the first type of input)
 * - Check if the password is correct for the given contest
 * - Save the user with the contest they take part in (a user ca take part in many contests) and the points the user 
 * has in the given contest. If you receive the same contest and the same user, update hte points only if the new
 * ones are more than the older ones.
 * 
 * At the end you have to print the info for the user with the most points in the format:
 * 
 * "Best candidate is {user} with total {total points}.". After that print all students ordered by their names.
 * For each user, print each contest with the points in descending order in the following format:
 * 
 * "{user1 name}
 * # {contest1} -> {points}
 * # {contest2} -> {points}
 * 
 * {user2 name}
 * ..."
 * 
 */

using System;
class Program
{
    static void Main(string[] args)
    { 
    string contestInput = Console.ReadLine(); //reading input
        Dictionary<string, string> contests = new Dictionary<string, string>(); //dictionary to store contests

        while (contestInput != "end of contests")
        {
            string[] tokens = contestInput.Split(":");
            contests.Add(tokens[0], tokens[1]);

            Console.WriteLine(contestInput);    
        }

        string submissionInput = Console.ReadLine(); //reading input
        Dictionary<string, Dictionary<string, int>> submissionResults = new Dictionary<string, Dictionary<string, int>>(); //dictionary to store contests' results

        while (submissionInput != "end of submissions")
        {
            string[] tokens = submissionInput.Split("=>");
            string contest = tokens[0];
            string pass = tokens[1];
            string username = tokens[2];
            int points = int.Parse(tokens[3]);

            //validation for password:
            if (!contests.ContainsKey(contest) || contests[contest] != pass)
            {
                submissionInput = Console.ReadLine();
                continue;
            }

            if (!submissionResults.ContainsKey(username)) //check if user is already added:
            {
                submissionResults.Add(username, new Dictionary<string, int>()); //if not found, add them
                submissionResults[username].Add(contest, points); //add the user's contests and points
            }
            else
            { 
                Dictionary<string, int> temp = submissionResults[username];
                if (!submissionResults[username].ContainsKey(contest))
                {
                    submissionResults[username].Add(contest, points);
                }
                else
                { int tempPoint = submissionResults[username][contest];

                    if (submissionResults[username][contest] < points)
                    {
                        submissionResults[username][contest] = points;
                    }
                }
            }

            submissionInput = Console.ReadLine();
        }
        //printing output:

       KeyValuePair<string, Dictionary<string, int>> bestCandidate = submissionResults
            .OrderByDescending(kvp => kvp.Value.Values.Sum())
            .First();
        Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidate.Value.Values.Sum()} points ");

    }
}