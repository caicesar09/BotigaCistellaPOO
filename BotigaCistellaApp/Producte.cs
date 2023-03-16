using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaApp
{
    class Producte
    {
        // Atributs
        private string nom;
        private double preuSenseIva;
        private double iva;
        private int quantitat;

        // Propietats
        public string Nom
        {
            get { return nom; }
            set { if (value != "") nom = value; }
        }
        public double PreuSenseIva
        {
            get { return preuSenseIva; }
            set { if (value >= 0) preuSenseIva = value; }
        }
        public double IVA
        {
            get { return iva; }
            set { if (value >= 0) iva = value; }
        }
        public int Quantitat
        {
            get { return quantitat; }
            set { if (value >= 0) quantitat = value; }
        }

        // Constructors
        public Producte() { iva = 21; quantitat = 0; }

        public Producte(string nom, double preuSenseIva)
        {
            this.nom = nom;
            this.preuSenseIva = preuSenseIva;
            iva = 21;
            quantitat = 0;
        }

        public Producte(string nom, double preuSenseIva, double iva, int quantitat) : this(nom, preuSenseIva)
        {
            this.iva = iva;
            this.quantitat = quantitat;
        }

        // Mètodes 
        public double Preu()
        {
            double preu = PreuSenseIva;
            return preu += preu * (iva / 100);
        }

        public override string ToString()
        {
            return $"{nom} | {Preu():0.00}";
        }
    }
}
