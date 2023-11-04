using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Model
{
    internal class Product
    {
        public int Id { get; set; }
        public string Naam{ get; set; }
        public int Prijs { get; set; }
        public string Beschrijving { get; set; }
        public int voorraadNiveau { get; set; }

        public Categorie? Categorie { get; set; }
        public int CategorieId { get; set; }
    }
}
