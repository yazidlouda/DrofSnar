using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Drofsnar
{
    class Program
    {
        public static void Main(string[] args)
        {
            int points = 5000;
            int lives = 3;
            int vulnerableBirdHunterCounter = 0;
            bool hasRun = true;

            string[] gameSequence = File.ReadAllText(@"C:\Users\yalou\OneDrive\Bureau\Drofsnar.txt").Split(',');
            Dictionary<string, int> birds = new Dictionary<string, int>()
            {
                { "Bird", 10 },
                { "CrestedIbis", 100 },
                { "GreatKiskudee", 300 },
                { "RedCrossbill", 500 },
                { "Red-neckedPhalarope", 700 },
                { "EveningGrosbeak", 1000 },
                { "GreaterPrairieChicken", 2000 },
                { "IcelandGull", 3000 },
                { "Orange-belliedParrot", 5000 },
                { "VulnerableBirdHunter", 200 },
            };

            while (lives>0)
            {
                foreach (string nextBird in gameSequence)
                {
                    foreach(var bird in birds)
                    {
                        if (nextBird == bird.Key)
                        {
                           
                        
                        
                        
                            if (nextBird == "VulnerableBirdHunter")
                            {
                                int tempPoint = birds["VulnerableBirdHunter"] * (int)Math.Pow(2, vulnerableBirdHunterCounter);
                                points += tempPoint;
                                vulnerableBirdHunterCounter++;
                            }
                            else
                            {
                                points += bird.Value;
                            }

                        }
                    }
                    if (nextBird == "InvincibleBirdHunter")
                    {
                        lives--;
                        vulnerableBirdHunterCounter = 0;
                    }
                    if (points >= 10000 && hasRun == true)
                    {
                        lives++;
                        hasRun = false;
                    }
                    Console.WriteLine($"{nextBird,-30} {points,-10} {lives}");
                    if (lives == 0)
                    {
                        break;
                    }

                }

            }
            Console.WriteLine($"\nThe total points: {points}");


        }
    }
}


