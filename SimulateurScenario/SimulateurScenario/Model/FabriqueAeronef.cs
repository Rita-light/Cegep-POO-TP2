using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurScenario.Model
{
    class FabriqueAeronef
    {
        private static FabriqueAeronef instance;
        private static readonly object padlock = new object();
        public static FabriqueAeronef Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FabriqueAeronef();
                    }
                    return instance;
                }
            }
        }
        private FabriqueAeronef() { }

        //Modifier parce que passait un type string
        public Aeronef CreerAeronef(string nom, TypeAeronef type, double vitesse, double tempsEmbarquement, double tempsDebarquement, double capacite, double tempsEntretien)
        {
            switch (type)
            {
                case TypeAeronef.Passager:
                    return new AvionPassager(nom, vitesse, tempsEntretien, (int)capacite, tempsEmbarquement, tempsDebarquement);
                case TypeAeronef.Cargo:
                    return new AvionCargaison(nom, vitesse, tempsEntretien, capacite, tempsEmbarquement, tempsDebarquement);
                case TypeAeronef.Secours:
                    return new AvionSecours(nom, vitesse, tempsEntretien);
                case TypeAeronef.Citerne:
                    return new AvionCiterne(nom, vitesse, tempsEntretien);
                case TypeAeronef.Helicoptere:
                    return new Helicoptere(nom, vitesse, tempsEntretien);
                default:
                    throw new ArgumentException("Type d'aéronef inconnu");
            }
        }
    }
}
