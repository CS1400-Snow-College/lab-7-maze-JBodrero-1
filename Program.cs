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
//ConsoleKeyInfo input;
//char mazeChar = ' ';


string[] mapRows = File.ReadAllLines("map.txt");
int maxWidth = mapRows[0].Length;
int maxHeight = mapRows.Length;
Console.WriteLine($"Max wide = {maxWidth} max height = {maxHeight}");
Console.ReadKey(true);

//  Start character at top left
DrawMaze(locFromLeft, locFromTop);
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
        if (locFromLeft + 1 < maxWidth)
        {
            locFromLeft++;
            DrawMaze(locFromLeft, locFromTop);
        }
        
    }
    else if (keyIn.Key == ConsoleKey.LeftArrow) //&& (mazeChar != '#'))
    {
        if (locFromLeft -1 >=0 )
        {
            locFromLeft--;
            DrawMaze(locFromLeft, locFromTop);
        }
    }
    else if (keyIn.Key == ConsoleKey.UpArrow) //&& (mazeChar != '#'))
    {
        if (locFromTop -1 >=0 )
        {
            locFromTop--;
            DrawMaze(locFromLeft, locFromTop);
        }
    }
    else if (keyIn.Key == ConsoleKey.DownArrow) //&& (mazeChar != '#'))
    {
        if (locFromTop < maxHeight-1 )
        {
            locFromTop++;
            DrawMaze(locFromLeft, locFromTop);
        }
    }
}
while (keyIn.Key != ConsoleKey.Escape);
Console.CursorVisible = true;

void DrawMaze(int fromLeft, int fromTop)
{
    Console.Clear();
    foreach (string row in mapRows)
    {
        Console.WriteLine(row);

    }
    Console.SetCursorPosition(fromLeft, fromTop);
    Console.Write("@");
}