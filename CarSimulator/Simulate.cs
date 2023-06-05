using CarSimulatorLibrary.Services;

namespace CarSimulator
{
    public class Simulate
    {
        private Driver driver;
        private Car car;

        public Simulate()
        {
            driver = new Driver();
            car = new Car();
        }

        public void Run()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                CarSimulatorLibrary.Services.UIHelper.PrintMenu();
                int choice = CarSimulatorLibrary.Services.UIHelper.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        car.ChangeDirection(Car.Direction.West);
                        CarSimulatorLibrary.Services.UIHelper.DriveCar(driver, car, "åt vänster");
                        break;
                    case 2:
                        car.ChangeDirection(Car.Direction.East);
                        CarSimulatorLibrary.Services.UIHelper.DriveCar(driver, car, "åt höger");
                        break;
                    case 3:
                        if (car.HasEnoughFuel())
                        {
                            car.DriveForward();
                            CarSimulatorLibrary.Services.UIHelper.DriveCar(driver, car, "framåt");
                        }
                        else
                        {
                            Console.WriteLine("Bensinen är slut. Välj ett alternativ:");
                            Console.WriteLine("1. Tanka bilen");
                            Console.WriteLine("2. Avsluta");
                            Console.Write("Ditt val: ");
                            int fuelChoice = CarSimulatorLibrary.Services.UIHelper.GetMenuChoice();

                            switch (fuelChoice)
                            {
                                case 1:
                                    car.Refuel();
                                    Console.WriteLine("Bilen tankas.");
                                    Console.WriteLine($"Bensin: {car.Fuel}/20");
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    exitProgram = true;
                                    Console.WriteLine("Programmet avslutas.");
                                    break;
                                default:
                                    Console.WriteLine("Ogiltigt val. Försök igen.");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;
                    case 4:
                        car.Reverse();
                        CarSimulatorLibrary.Services.UIHelper.DriveCar(driver, car, "bakåt");
                        break;
                    case 5:
                        driver.Rest();
                        Console.WriteLine("Bilföraren tar en paus och vilar.");
                        Console.WriteLine($"Förarens trötthet: {driver.Fatigue}/10");
                        Console.WriteLine();
                        break;
                    case 6:
                        car.Refuel();
                        Console.WriteLine("Bilen tankas.");
                        Console.WriteLine($"Bensin: {car.Fuel}/20");
                        Console.WriteLine();
                        break;
                    case 7:
                        exitProgram = true;
                        Console.WriteLine("Programmet avslutas.");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.WriteLine();
                        break;
                }
            }
        }


    }
}