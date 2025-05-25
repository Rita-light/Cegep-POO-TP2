using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimulateurScenario.Model
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

        public static void Exporter(Scenario scenario, string cheminFichier)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Scenario));
            using (StreamWriter writer = new StreamWriter(cheminFichier))
            {
                serializer.Serialize(writer, scenario);
            }
        }
    }
}
