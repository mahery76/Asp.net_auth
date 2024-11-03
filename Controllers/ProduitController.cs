using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace resto.Controllers
{
    public class ProduitController : Controller
    {
        // GET: /produit/
        public string Index()
        {
            return"this is my default produit controller ";
        }
        // GET: /produit/AddProdui/
        public string AddProduit()
        {
            return "this is the add produit action method ...";
        }
    }
}
