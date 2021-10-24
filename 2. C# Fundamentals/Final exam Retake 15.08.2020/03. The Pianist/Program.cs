using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < numOfPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|').ToArray();
                string piece = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                dict.Add(piece, new List<string>());
                dict[piece].Add(composer);
                dict[piece].Add(key);
            }

            string[] command = Console.ReadLine().Split('|').ToArray();

            while (!command.Contains("Stop"))
            {
                string action = command[0];

                switch (action)
                {
                    case "Add":
                        string currentPiece = command[1];
                        string currentComposer = command[2];
                        string currentKey = command[3];

                        if (!dict.ContainsKey(currentPiece))
                        {
                            dict.Add(currentPiece, new List<string>());
                            dict[currentPiece].Add(currentComposer);
                            dict[currentPiece].Add(currentKey);

                            Console.WriteLine($"{currentPiece} by {currentComposer} in {currentKey} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{currentPiece} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        currentPiece = command[1];

                        if (dict.ContainsKey(currentPiece))
                        {
                            dict.Remove(currentPiece);

                            Console.WriteLine($"Successfully removed {currentPiece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        currentPiece = command[1];

                        string newKey = command[2];

                        if (dict.ContainsKey(currentPiece))
                        {
                            currentComposer = dict[currentPiece][0];

                            dict[currentPiece].Clear();

                            dict[currentPiece].Add(currentComposer);
                            dict[currentPiece].Add(newKey);

                            Console.WriteLine($"Changed the key of {currentPiece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                        }
                        break;
                }

                command = Console.ReadLine().Split('|').ToArray();
            }

            foreach (var piece in dict
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
