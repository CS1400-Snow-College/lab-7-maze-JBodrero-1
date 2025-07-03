//  Jonathan Bodrero
//  Jul 3, 2025
//  Lab 8:  Maze 1

using System.Diagnostics;  //  Allows stopwatch functionality
Stopwatch watch = new Stopwatch();

int locFromLeft = 0;    //  Set location variables.
int locFromTop = 0;
int proposedFromLeft = 0;
int proposedFromTop = 0;

string[] mapRows = File.ReadAllLines("map.txt");    //  Read in maze map

//  Console.WriteLine($"Max wide = {maxWidth} max height = {maxHeight}");  Debugging code

Console.Clear();        //  Give instructions
Console.WriteLine("Welcome to our aMAZEing game.");
Console.WriteLine("Use the arrow keys to move your character from start (top left) to the * symbol.\n To exit, press the Escape key.");
Console.WriteLine("Press any key when ready.");
Console.ReadKey(true);      //  Checks for key to start maze
Console.Clear();        


//  Start character at top left and draw maze
DrawMaze(locFromLeft, locFromTop, mapRows);
Console.SetCursorPosition(0, 0);
Console.Write("@");
ConsoleKeyInfo keyIn;
Console.CursorVisible = false;
watch.Start();      // Start watch
do
{
    keyIn = Console.ReadKey(true);      //  Read character

    if (keyIn.Key == ConsoleKey.Escape) //  If escape, quit game.
    {
        Console.WriteLine("Thanks for playing.  Goodbye.");
        //Console.CursorVisible = true;
        break;
    }
    else if (keyIn.Key == ConsoleKey.RightArrow) //  Right arrow move
    {
        proposedFromLeft = locFromLeft + 1;
        proposedFromTop = locFromTop;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))    // Check valid move.
        {
            locFromLeft++;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    else if (keyIn.Key == ConsoleKey.LeftArrow) //  Left arrow move
    {
        proposedFromLeft = locFromLeft - 1;
        proposedFromTop = locFromTop;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))    // Check valid move.
        {
            locFromLeft--;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    else if (keyIn.Key == ConsoleKey.UpArrow) //  Up arrow move
    {
        proposedFromLeft = locFromLeft ;
        proposedFromTop = locFromTop - 1;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))    // Check valid move.
        {
            locFromTop--;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    else if (keyIn.Key == ConsoleKey.DownArrow) //  Down arrow move
    {
        proposedFromLeft = locFromLeft ;
        proposedFromTop = locFromTop + 1;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))    // Check valid move.
        {
            locFromTop++;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    if (mapRows[locFromTop] [locFromLeft] == '*')   //  Detect win.
    {
        watch.Stop();   //  Stop watch and compute time to complete.
        Console.Clear();
        Console.WriteLine($"Congratulations!  You completed the maze in {watch.ElapsedMilliseconds/1000} seconds.");
        break;
    }
}
while (keyIn.Key != ConsoleKey.Escape); //  Play game while any key but escape

Console.CursorVisible = true;   //  Make cursor visible in console after game.


static void DrawMaze(int fromLeft, int fromTop, string[] mapRows)   //  Method to draw maze.
{
    Console.Clear();
    foreach (string row in mapRows)
    {
        Console.WriteLine(row);

    }
    Console.SetCursorPosition(fromLeft, fromTop);
    Console.Write("@");
}


static bool TryMove(int proposedLeft, int proposedTop, string[] mapRows)  // Check if move is valid.
{
    int maxWidth = mapRows[0].Length;
    int maxHeight = mapRows.Length;
    if (proposedLeft < 0 || proposedLeft > maxWidth)    //  If outside of width, do nothing
    {
        return false;
    }
    else if (proposedTop < 0 || proposedTop >= maxHeight - 1)  //  If outside of height, do nothing
    {
        return false;
    }
    else if (mapRows[proposedTop][proposedLeft] == '#')//  Enforce walls.
    {
        return false;
    }
    else { return true; }   //  If valid move, proceed.
}
