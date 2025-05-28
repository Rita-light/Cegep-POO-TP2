using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario
{
    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Position(){ }
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        
        
        public  static Point ConvertirCoordonneesEnPixels(Position position)
        {
            double minLat = -90, maxLat = 90;
            double minLon = -180, maxLon = 180;

            // Dimensions de l’image ou du panel
            int largeurCarte = 960; // par exemple
            int hauteurCarte = 540;
           int x = (int)((position.Longitude - minLon) / (maxLon - minLon) * largeurCarte);
           int y = (int)((maxLat - position.Latitude) / (maxLat - minLat) * hauteurCarte); // latitude inversée


            return new Point(x, y);
        }
        
        public Position Clone()
        {
            return new Position
            {
                Latitude = this.Latitude,
                Longitude = this.Longitude
            };
        }
        
        public static Position GenererPositionAleatoire()
        {
            Random rnd = new Random();

            // Latitude entre -90 et 90
            double latitude = rnd.NextDouble() * 180 - 90;

            // Longitude entre -180 et 180
            double longitude = rnd.NextDouble() * 360 - 180;

            return new Position(latitude, longitude);
        }

        public double Distance(Position position)
        {
            double deltax = Math.Pow(position.Longitude - this.Longitude, 2);
            double deltay = Math.Pow(position.Latitude - this.Latitude, 2);
            return Math.Sqrt(deltax + deltay);
        }
        
        /// <summary>
        /// Calcule une nouvelle position en se rapprochant de la destination selon la distance donnée.
        /// Si la distance restante est inférieure ou égale à la distance à parcourir, la destination est atteinte.
        /// </summary>
        public static Position CalculerNouvellePosition(Position actuelle, Position destination, double distance)
        {
            double dx = destination.Longitude - actuelle.Longitude;
            double dy = destination.Latitude - actuelle.Latitude;
            double distanceTotale = Math.Sqrt(dx * dx + dy * dy);

            if (distanceTotale == 0 || distance >= distanceTotale)
            {
                // Destination atteinte ou dépassée
                return destination.Clone();
            }

            // Calcul du ratio pour se déplacer proportionnellement
            double ratio = distance / distanceTotale;

            double nouvelleLongitude = actuelle.Longitude + dx * ratio;
            double nouvelleLatitude = actuelle.Latitude + dy * ratio;

            return new Position(nouvelleLatitude, nouvelleLongitude);
        }


        


        
       

        
        
        
        
        
    }
    
    
    
    
    

}
