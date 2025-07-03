//  Jonathan Bodrero
//  Jul 3, 2025
//  Lab 8:  Maze 1

Console.Clear();
Console.WriteLine("Welcome to our aMAZEing game.");
Console.WriteLine("Use the arrow keys to move your character from top left to the * symbol.\n To exit, press Enter key.\n");
Console.WriteLine("Press any key when ready.");
Console.ReadKey(true);
Console.Clear();

int locFromLeft = 0;
int locFromTop = 0;
ConsoleKeyInfo input;
char mazeChar = ' ';


string[] mapRows = File.ReadAllLines("map.txt");

foreach (string row in mapRows)
{
    Console.WriteLine(row);
}
//  Start character at top left

Console.SetCursorPosition(0, 0);
Console.Write("@");
ConsoleKeyInfo keyIn;
do
{
    keyIn = Console.ReadKey(true);
  
    if (keyIn.Key == ConsoleKey.Escape)
    {
        Console.WriteLine("Thanks for playing.  Goodbye.");
        break;
                
    }
    
    

}
while (keyIn.Key != ConsoleKey.Escape);