namespace CarSimulatorLibrary.Services
{
    public class Driver
    {
        public int Fatigue { get; private set; }

        public void IncreaseFatigue()
        {
            Fatigue++;
        }

        public void Rest()
        {
            Fatigue = 0;
        }
    }
}
