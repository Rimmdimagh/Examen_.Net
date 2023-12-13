using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Produit
    {
        [DataType(DataType.Date,ErrorMessage ="invalide")]

        public DateTime DateProd { get; set; }
        public String destination1 {  get; set; }
        public String nom {  get; set; }
        public double price {  get; set; }
        public int produitID {  get; set; }

        public int CategorieFK { get; set; }
      

        public virtual IList<Fournisseur> fournisseurs { get; set; }
          //[ForeignKey("CategorieFK")]
        public virtual Categorie categories { get; set; }




    }
}
