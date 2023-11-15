using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Model
{
    public class Klant
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int KlantID { get; set; }
       public string Naam {  get; set; }
       public string Email  {  get; set; } 
       
       public bool IsAdmin { get; set; }
       public string Adres { get; set; }
       public string Wachtwoord { get; set; }
    }
}
