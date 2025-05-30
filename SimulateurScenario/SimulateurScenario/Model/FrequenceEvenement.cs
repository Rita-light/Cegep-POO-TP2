﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    public class FrequenceEvenement
    {
        public TypeEvenement Type { get; set; }
        public double Frequence { get; set; } = 0;

        public FrequenceEvenement()
        {
            
        }
        public FrequenceEvenement(TypeEvenement type, double frequence)
        {
            Type = type;
            Frequence = frequence;
        }

        public override string ToString()
        {
            return $"T{Type}|{Frequence}";
        }

        public string GetTypeAsString()
        {
            return Type.ToString();
        }
    }
}
