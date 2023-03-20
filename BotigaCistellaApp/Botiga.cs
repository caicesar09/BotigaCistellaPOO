using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotigaCistellaApp
{
    class Botiga
    {
        // Atributs
        private string nomBotiga;
        private Producte[] productes;
        private int nElements;

        // Propietats
        public string Nom { get; set; }
        public Producte Producte 
        {
            get { return productes[nElements - 1]; }
            set { if (nElements < productes.Length) { productes[nElements] = value; nElements++; } else { AmpliarBotiga(1); } }
        }
        public int NumElements { get; set; }

        // Constructors
        public Botiga() { nElements = 0; }

        public Botiga(string nomBotiga, int nElements)
        {
            this.nomBotiga = nomBotiga;
            this.nElements = nElements;
        }

        public Botiga(string nomBotiga, Producte[] productes, int nElements) : this(nomBotiga, nElements)
        {
            this.productes = productes;
        }

        // Mètodes
        
        public int EspaiLliure()
        {
            return -1;
        }

        public int Indexador()
        {
            return 0;
        }

        public bool AfegirProducte(Producte producte)
        {
            return false;
        }

        public void AmpliarBotiga(int ampliacio)
        {

        }

        public bool ModificarPreu(string producte, double preu)
        {
            return false;
        }

        public bool BuscarProducte(Producte producte)
        {
            return false;
        }

        public bool ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
        {
            return false;
        }

        public bool OrdenarProducte()
        {
            return false;
        }

        public bool OrdenarPreus()
        {
            return false;
        }

        public bool EsborrarProducte(Producte producte)
        {
            return false;
        }

        public void Mostrar()
        {

        }

        public override string ToString()
        {
            string res = String.Empty;
         
            for (int i = 0; i < productes.Length; i++)
            {
                Console.WriteLine(productes[i].Nom);
            }

            return res;
        }


        /*
        public Producte ProducteNou 
        {
            get { return productes[nElem - 1]; }
            set { if (nElem < productes.Length) { productes[nElem] = value; nElem++ } else { AmpliarBotiga(1)} }
        }
        */
    }
}
