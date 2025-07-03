//  Jonathan Bodrero
//  Jul 3, 2025
//  Lab 8:  Maze 1

Console.Clear();
Console.WriteLine("Welcome to our aMAZEing game.");
Console.WriteLine("Use the arrow keys to move your character from top left to the * symbol.\n");

string[] mapRows = File.ReadAllLines("map.txt");
foreach (string row in mapRows)
{
    Console.WriteLine(row);
}