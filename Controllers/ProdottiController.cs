using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using _28FebbraioEs.Models;

namespace _28FebbraioEs.Controllers
{
    public class ProdottiController : Controller
    {
        // GET: Prodotti
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserisciProdotto(Prodotto prodotto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;





            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                             INSERT INTO Product (NomeArticolo, Prezzo, Descrizione, ImmaginePrincipale, ImmagineAgg1, ImmagineAgg2, Attivo) 
                             VALUES (@NomeArticolo, @Prezzo, @Descrizione, @ImmaginePrincipale, @ImmagineAgg1, @ImmagineAgg2, @Attivo)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@NomeArticolo", prodotto.NomeArticolo);
                    cmd.Parameters.AddWithValue("@Prezzo", prodotto.Prezzo);
                    cmd.Parameters.AddWithValue("@Descrizione", prodotto.Descrizione);
                    cmd.Parameters.AddWithValue("@ImmaginePrincipale", prodotto.ImmaginePrincipale);
                    cmd.Parameters.AddWithValue("@ImmagineAgg1", prodotto.ImmagineAgg1);
                    cmd.Parameters.AddWithValue("@ImmagineAgg2", prodotto.ImmagineAgg2);
                    cmd.Parameters.AddWithValue("@Attivo", 1);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }






            return RedirectToAction("Index");
        }
    }
}
