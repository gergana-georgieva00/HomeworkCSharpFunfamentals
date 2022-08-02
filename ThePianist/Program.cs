using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
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

                string pieceName = input[0];
                string composer = input[1];
                string key = input[2];

                Piece piece = new Piece(pieceName, composer, key);
                pieces.Add(piece);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splitCommand = command.Split('|');

                if (command.Contains("Add"))
                {
                    string pieceName = splitCommand[1];
                    string composer = splitCommand[2];
                    string key = splitCommand[3];

                    Piece piece = new Piece(pieceName, composer, key);
                    if (pieces.Any(p => p.Name == pieceName))
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece);
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command.Contains("Remove"))
                {
                    string pieceName = splitCommand[1];

                    if (pieces.Any(p => p.Name == pieceName))
                    {
                        Piece piece = pieces.Find(p => p.Name == pieceName);
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else
                {
                    string pieceName = splitCommand[1];
                    string newKey = splitCommand[2];

                    if (pieces.Any(p => p.Name == pieceName))
                    {
                        Piece piece = pieces.Find(p => p.Name == pieceName);
                        piece.Key = newKey;
                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }

            foreach (Piece piece in pieces)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }

    class Piece
    {
        public Piece(string name, string composer, string key)
        {
            this.Name = name;
            this.Composer = composer;
            this.Key = key;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
}
