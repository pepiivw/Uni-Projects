using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footballgame
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class FootballPlayer : Person
    {
        public int Number { get; set; }
        public double Height { get; set; }
    }

    public class Goalkeeper : FootballPlayer
    {
    }

    public class Defender : FootballPlayer
    {
    }

    public class Midfielder : FootballPlayer
    {
    }

    public class Striker : FootballPlayer
    {
    }

    public class Coach : Person
    {
    }

    public class Referee : Person
    {
    }

    public class Team
    {
        public Coach Coach { get; set; }
        public List<FootballPlayer> Players { get; set; }
        public double AveragePlayerAge
        {
            get { return Players.Average(player => player.Age); }
        }
    }

    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public Referee Referee { get; set; }
        public List<AssistantReferee> AssistantReferees { get; set; }
        public List<Goal> Goals { get; set; }
        public string Result { get; set; }
        public Team Winner { get; set; }
    }

    public class AssistantReferee : Person
    {
    }

    public class Goal
    {
        public int Minute { get; set; }
        public FootballPlayer Player { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create players
            Striker player1 = new Striker { Name = "Player 1", Number = 9, Age = 25, Height = 1.85 };
            Striker player2 = new Striker { Name = "Player 2", Number = 10, Age = 28, Height = 1.80 };
            Midfielder player3 = new Midfielder { Name = "Player 3", Number = 7, Age = 26, Height = 1.78 };
            Defender player4 = new Defender { Name = "Player 4", Number = 8, Age = 24, Height = 1.80 };
            Goalkeeper player5 = new Goalkeeper { Name = "Player 5", Number = 11, Age = 23, Height = 1.82 };
            Midfielder player6 = new Midfielder { Name = "Player 6", Number = 2, Age = 26, Height = 1.67 };
            Defender player7 = new Defender { Name = "Player 7", Number = 3, Age = 24, Height = 1.88 };
            Defender player8 = new Defender { Name = "Player 8", Number = 6, Age = 28, Height = 1.90 };
            Striker player9 = new Striker { Name = "Player 9", Number = 1, Age = 24, Height = 1.70 };
            Striker player10 = new Striker { Name = "Player 10", Number = 5, Age = 23, Height = 1.81 };
            Midfielder player11 = new Midfielder { Name = "Player 11", Number = 4, Age = 27, Height = 1.85 };           

            // Create teams
            Team team1 = new Team { Coach = new Coach { Name = "Coach 1", Age = 37 }, Players = new List<FootballPlayer> { player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11 } };
            Team team2 = new Team { Coach = new Coach { Name = "Coach 2", Age = 41 }, Players = new List<FootballPlayer> { player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11 } };
            

            // Create game
            Game game = new Game { Team1 = team1, Team2 = team2, Referee = new Referee { Name = "Referee 1", Age = 36 }, AssistantReferees = new List<AssistantReferee>(), Goals = new List<Goal>() };

            // Simulate the match
            Random random = new Random();
            for (int i = 0; i < 90; i += 15)
            {
                // Simulate goals
                if (random.Next(0, 3) > 1)
                {
                    Team scoringTeam = random.Next(0, 2) == 0 ? game.Team1 : game.Team2;
                    FootballPlayer scoringPlayer = scoringTeam.Players[random.Next(0, scoringTeam.Players.Count)];
                    Goal goal = new Goal { Minute = i, Player = scoringPlayer };
                    game.Goals.Add(goal);
                }
            }

            // Determine the winner
            game.Result = $"{game.Team1.Players.Count} - {game.Team2.Players.Count}"; // Assuming goals scored by players are counted

            if (game.Team1.Players.Count > game.Team2.Players.Count)
            {
                game.Winner = game.Team1;
            }
            else if (game.Team1.Players.Count < game.Team2.Players.Count)
            {
                game.Winner = game.Team2;
            }


            // Print match details
            Console.WriteLine($"Team 1: {game.Team1.Coach.Name}'s Team");
            Console.WriteLine($"Players:");
            foreach (FootballPlayer player in game.Team1.Players)
            {
                Console.WriteLine($"- {player.Name} (#{player.Number})");
            }
            Console.WriteLine();

            Console.WriteLine($"Team 2: {game.Team2.Coach.Name}'s Team");
            Console.WriteLine($"Players:");
            foreach (FootballPlayer player in game.Team2.Players)
            {
                Console.WriteLine($"- {player.Name} (#{player.Number})");
            }
            Console.WriteLine();

            Console.WriteLine($"Referee: {game.Referee.Name}");
            Console.WriteLine($"Assistant Referees: {game.AssistantReferees.Count}");
            Console.WriteLine();

            Console.WriteLine($"Goals:");
            foreach (Goal goal in game.Goals)
            {
                Console.WriteLine($"- {goal.Minute}' - {goal.Player.Name}");
            }
            Console.WriteLine();

            Console.WriteLine($"Result: {game.Result}");
            if (game.Winner != null)
            {
                Console.WriteLine($"Winner: {game.Winner.Coach.Name}'s Team");
            }
            Console.ReadLine();
        }
    }
}
    


