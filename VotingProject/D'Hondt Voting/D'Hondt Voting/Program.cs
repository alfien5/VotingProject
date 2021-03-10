using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Get_Votes
{
    public static List<string> parties = new List<string>();
    public static List<int> party_votes = new List<int>(); // Variables for the lines of the text file, a counter and a couple lists

    public static int BrexitPartyWins = 0;
    public static int LibDemWins = 0;
    public static int LabourWins = 0;
    public static int ConWins = 0;
    public static int GreenWins = 0;
    public static int UKIPWins = 0;
    public static int ChangeUKWins = 0;
    public static int IndNetWins = 0;
    public static int IndWins = 0;
    public static void ReadFiles()
    {
        string fileName = @"Votes.txt"; //assigns the text file to a string

        using (StreamReader reader = new StreamReader(fileName)) // Opens an instance of the file
        {
            string line;
            int counter = 0;

            while ((line = reader.ReadLine()) != null) // Do while the line of the text file is not empty
            {
                if (counter == 1) // check for the line in the text file with the total seats on it
                {
                    int total_seats = System.Convert.ToInt32(line); // Assigns a integer version of the text file's line to a variable
                }

                if (counter == 2) // check for the line in the text file with the total votes on it
                {
                    int total_votes = System.Convert.ToInt32(line);
                }

                if (counter > 2) // The rest of the text file's lines are parties and their votes
                {
                    parties.Add(line.Substring(0, line.IndexOf(","))); // Gets the name of the party and adds it to the 'parties' list
                    line = line.Substring(line.IndexOf(",") + 1); // Cuts the name of the party off the string
                    party_votes.Add(System.Convert.ToInt32(line.Substring(0, line.IndexOf(",")))); // Retrieves the partie's votes and adds them to a list

                }

                counter += 1; // Makes sure the next line of the file is read
            }

        }
    }

    public static int BPseats = 0;
    public static int LDseats = 0;
    public static int LAseats = 0;
    public static int COseats = 0;
    public static int GRseats = 0;
    public static int UKseats = 0;
    public static int CUseats = 0;
    public static int INseats = 0;
    public static int IDseats = 0;

    public static void Readresults()
    {
        string results = @"testresults.txt";
        using (StreamReader reader = new StreamReader(results)) 
        {
            string lin;
            int counte = 0;

            while ((lin = reader.ReadLine()) != null) 
            { 
                if (counte == 1)
                {
                    foreach(char ch in lin)
                    {
                        if (ch == ',')
                        {
                            BPseats += 1;
                        }
                    }                        
                }
                if (counte == 2)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            LDseats += 1;
                        }
                    }
                }
                if (counte == 3)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            LAseats += 1;
                        }
                    }
                }
                if (counte == 4)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            COseats += 1;
                        }
                    }
                }
                if (counte == 5)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            GRseats += 1;
                        }
                    }
                }
                if (counte == 6)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            UKseats += 1;
                        }
                    }
                }
                if (counte == 7)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            CUseats += 1;
                        }
                    }
                }
                if (counte == 8)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            INseats += 1;
                        }
                    }
                }
                if (counte == 9)
                {
                    foreach (char ch in lin)
                    {
                        if (ch == ',')
                        {
                            IDseats += 1;
                        }
                    }
                }

                //If the results given by the D'Hondt program match the results of the text file, everything is correct.
                if (BPseats == BrexitPartyWins && LDseats == LibDemWins && LAseats == LabourWins && COseats == ConWins && GRseats == GreenWins && UKseats == UKIPWins && CUseats == ChangeUKWins && INseats == IndNetWins && IDseats == IndWins)
                {
                    Console.WriteLine("All results are correct");
                }
                else
                {
                    Console.WriteLine("One or more of the results is incorrect");
                }
                counte += 1;
            }
        }   
    }
    public class Party
    {
        //fields
        public string name;
        public int numVotes;
        public int numVotesMath;
        public int numWins;
        public List<string> seatsleft = new List<string>();

        //constructor
        public Party(string partyName, int partyNumVotes, int partyNumSeats)
        {
            name = partyName;
            numVotes = partyNumVotes;
            numVotesMath = partyNumVotes;
            for (int i = 1; i != partyNumSeats + 1; i++)
            {
                seatsleft.Add("SEAT" + i);
            }
            numWins = 0;
        }

        //methods
        public void SeatWon()
        {
            numWins++;
            seatsleft.RemoveAt(0);
        }

        //!!! FOR TESTING

        public void Check()
        {
            Console.WriteLine("Party's name = " + name);
            Console.WriteLine("Total Votes = " + numVotes);
            Console.WriteLine(" ");
        }

        public Party[] partyObjects;

        public static void Main(string[] args)
        {
            Get_Votes.ReadFiles();

            //Creating dictionary for party objects
            Dictionary<int, Party> partyObjects = new Dictionary<int, Party>();

            //Creating the individual party objects
            for (int i = 0; i < parties.Count - 1; i++)
            {
                partyObjects.Add(i, new Party(parties[i], party_votes[i], 5));
            }
            //Creation exception for Independent which only has 1 seat
            partyObjects.Add(8, new Party(parties[8], party_votes[8], 1));

            //Testing each party object's contents
            for (int i = 0; i < parties.Count; i++)
            {
                partyObjects[i].Check();
            }
            Console.WriteLine("////////////////////////////////////////////");
            Console.WriteLine(" ");




            int roundCount = 1;
            
            

            while (roundCount < 6)
            {

                // Create new empty list

                List<int> votes = new List<int>();

                // Calculate current votes and add them to list
                foreach (var party in partyObjects.Values)
                {
                    party.numVotesMath = party.numVotes / (1 + party.numWins);
                    votes.Add(party.numVotesMath);
                }

                //Find largest vote
                int largestVote = votes.Max();

                //Party which corresponds to the largest vote has their wins increase by 1

                foreach (var party in partyObjects.Values)
                {
                    if (party.numVotesMath == largestVote)
                    {
                        party.numWins = party.numWins + 1;
                        Console.WriteLine("Seat Winner: " + party.name);

                        if (party.name == "Brexit Party")
                        {
                            BrexitPartyWins += 1;
                        }

                        if (party.name == "Liberal Democrats")
                        {
                            LibDemWins += 1;
                        }

                        if (party.name == "Labour")
                        {
                            LabourWins += 1;
                        }

                        if (party.name == "Conservative")
                        {
                            ConWins += 1;
                        }

                        if (party.name == "Green")
                        {
                            GreenWins += 1;
                        }

                        if (party.name == "UKIP")
                        {
                            UKIPWins += 1;
                        }

                        if (party.name == "Change UK")
                        {
                            ChangeUKWins += 1;
                        }

                        if (party.name == "Independent Network")
                        {
                            IndNetWins += 1;
                        }

                        if (party.name == "Independent")
                        {
                            IndWins += 1;
                        }
                    }
                }

                Console.WriteLine("Seat Number: " + roundCount);
                Console.WriteLine("Winning Vote Numbers: " + largestVote);
                Console.WriteLine(" ");
                roundCount = roundCount + 1;
            }

            Console.WriteLine("Brexit Party Wins: " + BrexitPartyWins);
            Console.WriteLine("Liberal Democrat Party Wins: " + LibDemWins);
            Console.WriteLine("Labour Party Wins: " + LabourWins);
            Console.WriteLine("Conservative Party Wins: " + ConWins);
            Console.WriteLine("Green Party Wins: " + GreenWins);
            Console.WriteLine("UKIP Party Wins: " + UKIPWins);
            Console.WriteLine("Change UK Party Wins: " + ChangeUKWins);
            Console.WriteLine("Independent Network Party Wins: " + IndNetWins);
            Console.WriteLine("Independent Party Wins: " + IndWins);

            Readresults();
        }
    }
}
