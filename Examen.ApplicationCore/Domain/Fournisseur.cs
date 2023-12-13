using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Fournisseur
    {


        public String confirmPassword { get; set; }
        public String email { get; set; }
        [Key]

        public int identifiant { get; set; }
        public bool isAproved { get; set; }

        [MinLength(3)]
        [MaxLength(12)]
        public String nom { get; set; }

        public virtual IList<Produit> produits { get; set;}
    }
}
