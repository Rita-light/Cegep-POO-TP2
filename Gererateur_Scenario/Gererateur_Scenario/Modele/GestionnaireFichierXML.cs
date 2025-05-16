using System.IO;
using System.Xml.Serialization;

namespace Gererateur_Scenario
{
    public class GestionnaireFichierXML
    {
        public static Scenario Importer(string cheminFichier)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Scenario));
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Open))
            {
                return (Scenario)serializer.Deserialize(fs);
            }
        }
        public static void Exporter(Scenario scenario, string xmlPath) { }
    }
}