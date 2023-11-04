using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Model
{
    internal class Bestelling
    {
        public int Id { get; set; }
        
        public DateTime Datum { get; set; }

        public int KlantId { get; set; }
    }
}
