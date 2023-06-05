namespace CarSimulatorLibrary.Services
{
    public class Car
    {
        public enum Direction
        {
            North,
            South,
            West,
            East
        }

        public Position CurrentPosition { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public int Fuel { get; private set; }

        public Car()
        {
            CurrentDirection = Direction.North;
            Fuel = 20;
            CurrentPosition = new Position(0, 0); // Exempel på startposition (0, 0)
        }

        private void UpdatePosition(int xOffset, int yOffset)
        {
            CurrentPosition.X += xOffset;
            CurrentPosition.Y += yOffset;
        }

        public void TurnLeft()
        {
            CurrentDirection = (Direction)(((int)CurrentDirection + 3) % 4);
        }

        public void TurnRight()
        {
            CurrentDirection = (Direction)(((int)CurrentDirection + 1) % 4);
        }

        public void ChangeDirection(Direction newDirection)
        {
            int currentDirectionValue = (int)CurrentDirection;
            int newDirectionValue = (int)newDirection;

            int directionChange = (newDirectionValue - currentDirectionValue + 4) % 4;

            switch (directionChange)
            {
                case 1:
                    TurnRight();
                    UpdatePosition(1, 0); // Justera positionen efter högersväng
                    break;
                case 3:
                    TurnLeft();
                    UpdatePosition(-1, 0); // Justera positionen efter vänstersväng
                    break;
                default:
                    // Ingen ändring av position för 0 eller 2 steg
                    break;
            }
        }

        public void DriveForward()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    UpdatePosition(0, 1);
                    break;
                case Direction.South:
                    UpdatePosition(0, -1);
                    break;
                case Direction.West:
                    UpdatePosition(-1, 0);
                    break;
                case Direction.East:
                    UpdatePosition(1, 0);
                    break;
            }

            Fuel--;
        }

        public void Reverse()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    UpdatePosition(0, -1);
                    break;
                case Direction.South:
                    UpdatePosition(0, 1);
                    break;
                case Direction.West:
                    UpdatePosition(1, 0);
                    break;
                case Direction.East:
                    UpdatePosition(-1, 0);
                    break;
            }

            Fuel--;
        }

        public void Refuel()
        {
            Fuel = 20;
        }

        public bool HasEnoughFuel()
        {
            return Fuel > 0;
        }
    }
}
