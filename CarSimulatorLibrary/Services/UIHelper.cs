namespace CarSimulatorLibrary.Services
{
    public class UIHelper
    {
        public static void PrintMenu()
        {
            Console.WriteLine("1. Sväng vänster");
            Console.WriteLine("2. Sväng höger");
            Console.WriteLine("3. Köra framåt");
            Console.WriteLine("4. Backa");
            Console.WriteLine("5. Rasta");
            Console.WriteLine("6. Tanka bilen");
            Console.WriteLine("7. Avsluta");
            Console.Write("Vad vill du göra härnäst? ");
        }

        public static int GetMenuChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Ogiltigt val. Försök igen: ");
            }
            return choice;
        }

        public static void DriveCar(Driver driver, Car car, string action)
        {
            Console.Clear();
            driver.IncreaseFatigue();
            Console.WriteLine($"Bilföraren {action}.");

            Console.WriteLine("Körriktning: " + GetDirectionText(car.CurrentDirection));
            Console.WriteLine($"Bensin: {car.Fuel}/20");
            Console.WriteLine($"Förarens trötthet: {driver.Fatigue}/10");

            if (driver.Fatigue >= 7)
            {
                Console.WriteLine("Bilföraren börjar bli trött. Ta en paus snart!");
            }

            if (driver.Fatigue >= 10)
            {
                Console.WriteLine("Bilföraren är mycket trött. Ta en paus nu!");
            }

            Console.WriteLine();
        }

        public static string GetDirectionText(Car.Direction direction)
        {
            switch (direction)
            {
                case Car.Direction.North:
                    return "Norr";
                case Car.Direction.South:
                    return "Söder";
                case Car.Direction.West:
                    return "Väster";
                case Car.Direction.East:
                    return "Öster";
                default:
                    return "Okänd riktning";
            }
        }
    }
}