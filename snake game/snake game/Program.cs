using snake_game;

Cord gridDimensions = new Cord(50, 20);
Cord snakePos = new Cord(10, 1);
Random rand = new Random();
Cord applePos = new Cord(rand.Next(1, gridDimensions.X-1), rand.Next(1, gridDimensions.Y-1));
int frameDelaymilli = 100;
Direction movementDirection = Direction.Down;
int score = 0;

List<Cord> snakePosHistory = new List<Cord>();
int tailLenght = 1;

while (true)
{
    Console.Clear();
    Console.WriteLine("Score : " + score);
    snakePos.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Cord currentCord = new Cord(x, y);

            if (snakePos.Equals(currentCord) || snakePosHistory.Contains(currentCord))
                Console.Write("■");
            else if (applePos.Equals(currentCord))
                Console.Write("■");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    
    if (snakePos.Equals(applePos))
    {
        tailLenght++;
        score++;
        applePos = new Cord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
    }
    else if(snakePos.X==0 || snakePos.Y==0 || snakePos.X==gridDimensions.X-1 || snakePos.Y==gridDimensions.Y-1 || snakePosHistory.Contains(snakePos))
    {
        score = 0;
        tailLenght = 0;
        snakePos = new Cord(10, 1);
        snakePosHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }

    snakePosHistory.Add(new Cord(snakePos.X, snakePos.Y));

    if (snakePosHistory.Count > tailLenght)
        snakePosHistory.RemoveAt(0);

    DateTime time = DateTime.Now;

    while((DateTime.Now-time).Milliseconds < frameDelaymilli)
    {
        if(Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
            }
        }
    }
}