using snake_game;

Cord gridDimensions = new Cord(50, 20);
Cord snakePos = new Cord(10, 1);
Random rand = new Random();
Cord applePos = new Cord(rand.Next(1, gridDimensions.X-1), rand.Next(1, gridDimensions.Y-1));
int frameDelaymilli = 100;
Direction movementDirection = Direction.Down;

while (true)
{
    Console.Clear();
    snakePos.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Cord currentCord = new Cord(x, y);

            if (snakePos.Equals(currentCord))
                Console.Write("■");
            else if (applePos.Equals(currentCord))
                Console.Write("a");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    Thread.Sleep(frameDelaymilli);
}