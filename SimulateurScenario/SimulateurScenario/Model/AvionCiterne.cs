﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class AvionCiterne : AeronefUrgence
    {
        public AvionCiterne()
        {

        }

        public AvionCiterne(string nom, double vitesse, double tempsEntretien, TypeEtat etat) : base(nom, vitesse, tempsEntretien, etat)
        {
            type = TypeAeronef.Citerne;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }

        public override string Serialiser()
        {
            return $"{base.Serialiser()}";
        }
    }
}
