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
        public Botiga() { nElements = 0; productes = new Producte[nElements]; }

        public Botiga(string nomBotiga, int nElements)
        {
            this.nomBotiga = nomBotiga;
            this.nElements = nElements;
            productes = new Producte[nElements];
        }

        public Botiga(string nomBotiga, Producte[] productes, int nElements) : this(nomBotiga, nElements)
        {
            this.productes = productes;
        }

        // Mètodes
        
        public int EspaiLliure()
        {
            return productes.Length - nElements;
        }

        public int Indexador()
        {
            return 0;
        }

        public bool AfegirProducte(Producte producte)
        {
            if (nElements < productes.Length) productes[nElements] = producte; nElements++;
            return nElements < productes.Length;
        }

        public void AmpliarBotiga(int ampliacio)
        {
            Array.Resize(ref productes, productes.Length + ampliacio);
        }

        public void ModificarPreu(Producte producte, double preu)
        {
            int indexProducte = BuscarProducte(producte);
            if (indexProducte != 0)
                productes[indexProducte].PreuSenseIva = preu; 
        }

        public int BuscarProducte(Producte producte)
        {
            int index = 0;
            for (int i = 0; i < nElements; i++) if (producte.Nom == productes[i].Nom) index = i;
            return index;
        }

        public void ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
        {
            int indexProducte = BuscarProducte(producte);
            if (indexProducte != 0)
            {
                productes[indexProducte].Nom = nouNom;
                productes[indexProducte].PreuSenseIva = nouPreu;
                productes[indexProducte].Quantitat = novaQuantitat;
            }
        }

        /*
        public void OrdenarProducte()
        {
            for (int numVolta = 0; numVolta < nElements - 1; numVolta++)
            {
                for (int i = 0; i < nElements - 1; i++)
                {
                    Producte actual = productes[i];
                    Producte seguent = productes[i + 1];
                    if (actual > seguent) // Override
                    {
                        int aux = actual;
                        actual = seguent;
                        seguent = aux;

                        productes[i] = actual;
                        productes[i + 1] = seguent;
                    }
                }
            }
        }
        */

        public bool OrdenarPreus()
        {
            return false;
        }

        public void EsborrarProducte(Producte producte)
        {
            int indexProducte = BuscarProducte(producte);
            if (indexProducte != 0)
            {
                productes[indexProducte].Nom = "";
                productes[indexProducte].PreuSenseIva = 0;
                productes[indexProducte].Quantitat = 0;
            }
        }

        public void Mostrar()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string res = "";

            if (nElements > 0) 
            {
                for (int i = 0; i < nElements; i++) res += $"Nom: {productes[i].Nom}\n";
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
