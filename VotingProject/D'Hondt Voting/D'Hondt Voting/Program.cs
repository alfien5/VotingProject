using System;
using System.IO;
using System.Collections.Generic;

public class Get_Votes
{
    public static List<string> parties = new List<string>();
    public static List<int> party_votes = new List<int>();
    public static List<string> seats = new List<string>();// Variables for the lines of the text file, a counter and a couple lists

    public static void ReadFiles()
    {
        string fileName = @"C:\Users\newto\Desktop\VotingProject\Votes.txt"; //assigns the text file to a string

        using (StreamReader reader = new StreamReader(fileName)) // Opens an instance of the file
        {
            string line;
            int counter = 0;          

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

    public class Party
    {
        //fields
        public string name;
        public int numVotes;
        public int numWins;

        //constructor
        public Party(string partyName, int partyNumVotes, int partyNumSeats)
        {
            name = partyName;
            numVotes = partyNumVotes;
            for (int i = 1; i != partyNumSeats + 1; i++)
            {
                seats.Add("SEAT" + i);
            }
            numWins = 0;
        }

        //methods
        public void SeatWon()
        {
            numWins++;
            seats.RemoveAt(0);
        }

        //!!! FOR TESTING
        public void Check()
        {
            Console.WriteLine("Party's name = " + name + " | Votes = " + numVotes);
            for (int i = 0; i < seats.Count; i++)
                Console.WriteLine(seats[i]);
        }
        public static void Main(string[] args)
        {
            //!!! FOR TESTING
            Party party = new Party("BB", 69, 5);
            party.SeatWon();
            party.Check();

            Get_Votes.ReadFiles();

            //!!! Use TEAM LEADER's lists to create the parties here
            // Testing for list access - struggling
            for (int i = 0; i < parties.Count; i++)
                Console.WriteLine(parties[i]);
            for (int i = 0; i < party_votes.Count; i++)
                Console.WriteLine(party_votes[i]);

        }
    }
}
