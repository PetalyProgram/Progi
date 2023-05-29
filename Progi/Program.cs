using Progi;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    static List<Opponent> Opponents = new List<Opponent>();
    static void Main(string[] args)
    {
        
        Console.Write("\nHány ellenféllel szeretnél játszani : ");
        int numberOfOpponents = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Self self = new Self();
        self.Write();
        for (int i = 0; i < numberOfOpponents; i++)
        {
            Opponent opponent = new Opponent(i + 1);
            Opponents.Add(opponent);
            Opponents[i].Ai();
            Opponents[i].Write();
        }
        Console.ReadKey();
    }
}

class Card
{
    public string Name { get; private set; }
    public string Point { get; private set; }

    string[] names = { "pikk", "kőr", "treff", "káró" };
    string[] points = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jumbó", "dáma", "király", "ász"};
    public Card()
    {
        Name = names[new Random().Next(names.Length)];
        Thread.Sleep(10);
        Point = points[new Random().Next(points.Length)];
        Thread.Sleep(10);
    }
}