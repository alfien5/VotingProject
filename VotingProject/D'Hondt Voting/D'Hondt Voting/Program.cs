using System;
using System.IO;
using System.Collections.Generic;

public class Get_Votes
{
    public static void Main()
    {
        string fileName = @"C:\Users\newto\Desktop\VotingProject\Votes.txt"; //assigns the text file to a string

        using (StreamReader reader = new StreamReader(fileName)) // Opens an instance of the file
        {
            string line;
            int counter = 0;
            List<string> parties = new List<string>();
            List<int> party_votes = new List<int>(); // Variables for the lines of the text file, a counter and a couple lists

            while ((line = reader.ReadLine()) != null) // Do while the line of the text file is not empty
            {
                if (counter == 1) // check for the line in the text file with the total seats on it
                {
                    int total_seats = System.Convert.ToInt32(line); // Assigns a integer version of the text file's line to a variable
                    Console.WriteLine(total_seats); // Just to check it has the correct info
                }

                if (counter == 2) // check for the line in the text file with the total votes on it
                {
                    int total_votes = System.Convert.ToInt32(line);
                    Console.WriteLine(total_votes);
                }

                if (counter > 2) // The rest of the text file's lines are parties and their votes
                {
                    parties.Add(line.Substring(0, line.IndexOf(","))); // Gets the name of the party and adds it to the 'parties' list
                    Console.WriteLine(line.Substring(0, line.IndexOf(","))); // Displays the party name
                    line = line.Substring(line.IndexOf(",")+ 1); // Cuts the name of the party off the string
                    party_votes.Add(System.Convert.ToInt32(line.Substring(0, line.IndexOf(",")))); // Retrieves the partie's votes and adds them to a list
                    Console.WriteLine(System.Convert.ToInt32(line.Substring(0, line.IndexOf(",")))); // Displays the partie's votes

                }

                counter += 1; // Makes sure the next line of the file is read
            }

        }
    }
}
