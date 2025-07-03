//  Jonathan Bodrero
//  Jul 3, 2025
//  Lab 8:  Maze 1

Console.Clear();
Console.WriteLine("Welcome to our aMAZEing game.");
Console.WriteLine("Use the arrow keys to move your character from top left to the * symbol.\n To exit, press Escape key.\n");
Console.WriteLine("Press any key when ready.");
Console.ReadKey(true);
Console.Clear();

int locFromLeft = 0;
int locFromTop = 0;
int proposedFromLeft = 0;
int proposedFromTop = 0;
//ConsoleKeyInfo input;
//char mazeChar = ' ';


string[] mapRows = File.ReadAllLines("map.txt");
int maxWidth = mapRows[0].Length;
int maxHeight = mapRows.Length;
Console.WriteLine($"Max wide = {maxWidth} max height = {maxHeight}");
Console.ReadKey(true);

//  Start character at top left
DrawMaze(locFromLeft, locFromTop, mapRows);
Console.SetCursorPosition(0, 0);
Console.Write("@");
ConsoleKeyInfo keyIn;
Console.CursorVisible = false;
do
{
    //DrawMaze(locFromTop, locFromLeft);
    keyIn = Console.ReadKey(true);

    if (keyIn.Key == ConsoleKey.Escape)
    {
        Console.WriteLine("Thanks for playing.  Goodbye.");
        //Console.CursorVisible = true;
        break;
    }
    else if (keyIn.Key == ConsoleKey.RightArrow) //&& (mazeChar != '#'))
    {
        proposedFromLeft = locFromLeft + 1;
        proposedFromTop = locFromTop;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))
        {
            locFromLeft++;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }

    }
    else if (keyIn.Key == ConsoleKey.LeftArrow) //&& (mazeChar != '#'))
    {
        proposedFromLeft = locFromLeft - 1;
        proposedFromTop = locFromTop;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))
        {
            locFromLeft--;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    else if (keyIn.Key == ConsoleKey.UpArrow) //&& (mazeChar != '#'))
    {
        proposedFromLeft = locFromLeft ;
        proposedFromTop = locFromTop - 1;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))
        {
            locFromTop--;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    else if (keyIn.Key == ConsoleKey.DownArrow) //&& (mazeChar != '#'))
    {
        proposedFromLeft = locFromLeft ;
        proposedFromTop = locFromTop + 1;
        if (TryMove(proposedFromLeft, proposedFromTop, mapRows))
        {
            locFromTop++;
            DrawMaze(locFromLeft, locFromTop, mapRows);
        }
    }
    if (mapRows[locFromTop] [locFromLeft] == '*')
    {
        Console.Clear();
        Console.WriteLine("Congratulations!  You won!");
        break;
    }
}
while (keyIn.Key != ConsoleKey.Escape);
Console.CursorVisible = true;

static void DrawMaze(int fromLeft, int fromTop, string[] mapRows)
{
    Console.Clear();
    foreach (string row in mapRows)
    {
        Console.WriteLine(row);

    }
    Console.SetCursorPosition(fromLeft, fromTop);
    Console.Write("@");
}

static bool TryMove(int proposedLeft, int proposedTop, string[] mapRows)
{
    int maxWidth = mapRows[0].Length;
    int maxHeight = mapRows.Length;
    if (proposedLeft < 0 || proposedLeft > maxWidth)
    {
        return false;
    }
    else if (proposedTop < 0 || proposedTop >= maxHeight - 1)
    {
        return false;
    }
    else if (mapRows[proposedTop][proposedLeft] == '#')//  Enforce walls.
    {
        return false;
    }  
    else { return true; }

}
