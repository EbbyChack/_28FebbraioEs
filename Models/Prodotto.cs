using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _28FebbraioEs.Models
{
    public class Prodotto
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeArticolo { get; set; }
        public string Prezzo { get; set; }
        public string Descrizione { get; set; }
        [Display(Name = "Immagine principale")]
        public string ImmaginePrincipale { get; set; }
        [Display(Name = "Immagine aggiuntiva 1")]
        public string ImmagineAgg1 { get; set; }
        [Display(Name = "Immagine aggiuntiva 2")]
        public string ImmagineAgg2 { get; set; }
    }
}
