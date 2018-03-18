using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    // classe dell'oggetto "Risosa". Ogni task può avere delle risorse a lui associato
    public class Resource
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}