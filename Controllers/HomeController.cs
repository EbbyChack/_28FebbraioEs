using _28FebbraioEs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _28FebbraioEs.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Product WHERE Attivo = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<Prodotto> prodotti = new List<Prodotto>();
                    while (rdr.Read())
                    {
                        Prodotto prodotto = new Prodotto();
                        
                        prodotto.Id = (int)rdr["Id"];
                        prodotto.NomeArticolo = (string)rdr["NomeArticolo"];
                        prodotto.Prezzo = (string)rdr["Prezzo"];
                        prodotto.Descrizione = (string)rdr["Descrizione"];
                        prodotto.ImmaginePrincipale = (string)rdr["ImmaginePrincipale"];
                        prodotto.ImmagineAgg1 = (string)rdr["ImmagineAgg1"];
                        prodotto.ImmagineAgg2 = (string)rdr["ImmagineAgg2"];
                        prodotti.Add(prodotto);
                    }
                    return View(prodotti);
                }
            }
            
        }

        [HttpPost]
        public ActionResult Elimina(int id)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Product SET Attivo = 0 WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}