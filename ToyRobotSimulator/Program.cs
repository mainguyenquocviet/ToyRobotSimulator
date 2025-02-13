
namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            string[] commands;
            string filePath = $"D:\\source\\ToyRobotSimulator\\ToyRobotSimulator\\commands.txt"; // Change this to the path of the commands.txt file

            try
            {
                commands = File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file commands.txt was not found.");
                return;
            }

            foreach (var command in commands)
            {
                robot.ExecuteCommand(command);
            }
        }
    }

    public class Robot
    {
        private int X { get; set; }
        private int Y { get; set; }
        private Direction Facing { get; set; }
        private bool IsPlaced { get; set; } = false;

        private readonly int TableWidth = 5;
        private readonly int TableHeight = 5;

        public void ExecuteCommand(string command)
        {
            string[] parts = command.Split(' ');
            string action = parts[0];

            if (action == "PLACE" && parts.Length == 2)
            {
                string[] position = parts[1].Split(',');

                if (position.Length == 3 && Enum.TryParse(position[2], out Direction direction))
                {
                    int.TryParse(position[0], out int x);
                    int.TryParse(position[1], out int y);

                    if (IsValidPosition(x, y))
                    {
                        X = x;
                        Y = y;
                        Facing = direction;
                        IsPlaced = true;
                    }
                }
            }
            else if (IsPlaced)
            {
                switch (action)
                {
                    case "MOVE":
                        Move();
                        break;
                    case "LEFT":
                        TurnLeft();
                        break;
                    case "RIGHT":
                        TurnRight();
                        break;
                    case "REPORT":
                        Report();
                        break;
                }
            }
        }

        private void Move()
        {
            int newX = X;
            int newY = Y;

            switch (Facing)
            {
                case Direction.NORTH:
                    newY++;
                    break;
                case Direction.SOUTH:
                    newY--;
                    break;
                case Direction.EAST:
                    newX++;
                    break;
                case Direction.WEST:
                    newX--;
                    break;
            }

            if (IsValidPosition(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

        private void TurnLeft()
        {
            Facing = (Direction)(((int)Facing + 3) % 4);
        }

        private void TurnRight()
        {
            Facing = (Direction)(((int)Facing + 1) % 4);
        }

        private void Report()
        {
            Console.WriteLine($"{X},{Y},{Facing}");
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < TableWidth && y >= 0 && y < TableHeight;
        }
    }

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
}
