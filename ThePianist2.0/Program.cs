using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Piece> pieces = new List<Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|');
                Piece piece = new Piece(input[0], input[1], input[2]);
                pieces.Add(piece);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splCommand = command.Split('|');

                if (command.Contains("Add"))
                {
                    string pieceName = splCommand[1];
                    string composer = splCommand[2];
                    string key = splCommand[3];

                    Piece piece = new Piece(pieceName, composer, key);

                    if (pieces.Any(p => p.PieceName == pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece);
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if(command.Contains("Remove"))
                {
                    string pieceName = splCommand[1];

                    if (pieces.Any(p => p.PieceName == pieceName))
                    {
                        Piece pieceToRemove = pieces.Find(p => p.PieceName == pieceName);
                        pieces.Remove(pieceToRemove);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else
                {
                    string pieceName = splCommand[1];
                    string newKey = splCommand[2];

                    if (pieces.Any(p => p.PieceName == pieceName))
                    {
                        Piece pieceToRemove = pieces.Find(p => p.PieceName == pieceName);
                        pieceToRemove.Key = newKey;
                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.PieceName} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }

    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.PieceName = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string PieceName { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
