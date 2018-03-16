using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    // definizione dell' oggetto ROLE (Ad una task posso associare una persona. Questa persona ha un "ruolo")
    public class Role
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}