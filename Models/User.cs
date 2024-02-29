using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _28FebbraioEs.Models
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
       
    }
}