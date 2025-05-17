using System;

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
        
        public static string ConvertirEnDMS(double coordonnee, bool estLatitude)
        {
            string direction;

            if (estLatitude)
                direction = coordonnee >= 0 ? "N" : "S";
            else
                direction = coordonnee >= 0 ? "E" : "O";

            coordonnee = Math.Abs(coordonnee);
    
            int degres = (int)coordonnee;
            double minutesDecimal = (coordonnee - degres) * 60;
            int minutes = (int)minutesDecimal;
            double secondes = (minutesDecimal - minutes) * 60;
            // {secondes:0.###}'
            return $"{degres}° {minutes}' {direction}";
        }

    }

}