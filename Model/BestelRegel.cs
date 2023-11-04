using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Model
{
    internal class BestelRegel
    {
        public int BestellingsID { get; set; }
        public int ProductID { get; set; }
        public int Hoeveelheid { get; set; }
        public int Prijs {  get; set; }
    }
}
