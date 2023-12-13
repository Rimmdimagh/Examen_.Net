using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Examen.Interfaces;
using Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ProduitService : Service<Produit>, IProduitService
    {
        public ProduitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Fournisseur> ListesFournisseurByC(Categorie c)
        {

            //return c.ProduitList.SelectMany(p => p.fournisseurs);

            //une autre méthode
            return GetMany(p => p.categories.Equals(c)).SelectMany(p => p.fournisseurs);
            //p thenya heya condition ta3 l qblha kol 
        }

        public IEnumerable<Produit> GetCinqProdui()
        {
            return GetAll().OfType<Chimique>().OrderByDescending(p => p.price).Take(5);
        }
        public double prixProduit(Categorie c)
        {
           //return GetAll().OfType<Biologique>().Where(p => p.categories.Equals(c)).Average(p => p.price);
           //2eme methode
           return c.ProduitList.OfType<Biologique>().Average(p => p.price);
        }
    }
}

