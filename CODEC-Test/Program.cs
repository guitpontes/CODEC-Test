// See https://aka.ms/new-console-template for more information
Console.WriteLine("This application is for test purpose from CODEC");

char keepGoing = 'Y';
while(keepGoing != 'N')
{
    Console.WriteLine("Insert the grid config. EG. 5x5, 3x4, 4x4, etc:");
    var gridConfig = Console.ReadLine().ToUpper();

    Console.WriteLine("The command config should be -- L: Turn the robot left R: Turn the robot right F: Move forward on it's facing direction. E.G. LFLRFLFF");
    Console.WriteLine("Insert command: ");
    var commandLine = Console.ReadLine().ToUpper();

    var gridArray = gridConfig?.Split('X');
    int x = int.Parse(gridArray[0]);
    int y = int.Parse(gridArray.Last());

    Robot robot = new(x, y);

    foreach (var item in commandLine)
    {
        if (item == 'L')
            robot.TurnLeft();
        else if (item == 'R')
            robot.TurnRight();    
        else
            robot.MoveForward();
    }
    Console.WriteLine($"The final position is: {robot.GetPosition()}");
    Console.WriteLine("Want to try again? y/N");
    keepGoing = Console.ReadLine()[0];
}



public class Robot
{
    public int LengthX { get; private set; }
    public int LengthY { get; private set; }
    public int DirectionX { get; private set; }
    public int DirectionY { get; private set; }
    public int PositionX { get; private set; }
    public int PositionY { get; private set; }
    public string Direction { get; private set; }

    public Robot(int lengthX, int lengthY)
    {
        this.LengthX = lengthX;
        this.LengthY = lengthY;
        
        this.DirectionX = 0;
        this.DirectionY = 1;

        this.PositionX = 1;
        this.PositionY = 1;
    }
    public void TurnLeft()
    {
        if (DirectionX != 0)
        {
            if (this.DirectionX == 1)
            {
                this.DirectionY = 1;
            }
            else
            {
                this.DirectionY = -1;
            }

            this.DirectionX = 0;
        }
        else
        {
            if (this.DirectionY == 1)
            {
                this.DirectionX = -1;
            }
            else
            {
                this.DirectionX = 1;
            }

            this.DirectionY = 0;
        }
    }

    public void TurnRight()
    {
        if(DirectionX != 0)
        {
            if(this.DirectionX == 1)
            {
                this.DirectionY = -1;
            }
            else
            {
                this.DirectionY = 1;
            }

            this.DirectionX = 0;
        }
        else
        {
            if (this.DirectionY == 1)
            {
                this.DirectionX = 1;
            }
            else
            {
                this.DirectionX = -1;
            }

            this.DirectionY = 0;
        }
    }

    public void MoveForward()
    {
        if (this.DirectionX == 0)
        {
            if (this.DirectionY == 1)
            {
                if (this.PositionY < this.LengthY)
                {
                    this.PositionY++;
                }
            }
            else
            {
                if((this.PositionY - 1) >= 1)
                {
                    this.PositionY--;
                }
            }
        }
        else
        {
            if(this.DirectionX == 1)
            {
                if(this.PositionX < this.LengthX)
                {
                    this.PositionX++;
                }
            }
            else
            {
                if((this.PositionX - 1) >= 1)
                {
                    this.PositionX--;
                }
            }
        }
    }

    public string GetPosition()
    {
        if (DirectionX == 0)
        {
            if (DirectionY == 1)
            {
                this.Direction = "North";
            }
            else
            {
                this.Direction = "South";
            }
        }
        else
        {
            if (DirectionX == 1)
            {
                this.Direction = "East";
            }
            else
            {
                this.Direction = "West";
            }
        }

        return $"The position is {PositionX}, {PositionY}, {this.Direction }";
    }
}
