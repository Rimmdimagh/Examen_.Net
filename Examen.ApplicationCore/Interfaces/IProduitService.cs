using Examen.ApplicationCore.Domain;
using Examen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IProduitService:IService<Produit>
    {
        public IEnumerable<Fournisseur> ListesFournisseurByC(Categorie c);
        public IEnumerable<Produit> GetCinqProdui();
        public double prixProduit(Categorie c);
    }
}
