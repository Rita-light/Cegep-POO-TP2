namespace Gererateur_Scenario
{
    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Latitude}|{Longitude}";
        }
    }

}