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
        

        
       

        
        
        
        
        
    }
    
    
    
    
    

}
