﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gererateur_Scenario
{
    public class AvionSecours : AeronefUrgence
    {
        public AvionSecours(): base(){}
        public AvionSecours(string nom, double vitesse, double tempsEntretien, TypeEtat etat) : base(nom, vitesse, tempsEntretien, etat)
        {
            type = TypeAeronef.Secours;
        }

        public override string ToString()
        {
            return $"{Nom} - Type: {type}, Vitesse: {Vitesse}, TempsEntretien : {TempsEntretien}";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}";
        }
    }
}
