using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class FrequenceEvenement
    {
        public TypeEvenement Type { get; set; }
        public double Frequence { get; set; }

        public FrequenceEvenement(TypeEvenement type, double frequence)
        {
            Type = type;
            Frequence = frequence;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Fréquence: {Frequence}";
        }

        public string GetTypeAsString()
        {
            return Type.ToString();
        }
    }
}
