using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    public class MoreInfo
    {
        public int codice { get; set; }
        public String materiale { get; set; }
        public double lunghezza { get; set; }
        public double costo { get; set; }
        public string info { get; set; }
        public string nomeCommittente { get; set; }
        public string azienda { get; set; }
    }
}