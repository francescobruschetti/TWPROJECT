using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    // oggetto in cui memorizzo tutti i dati necessari per il funzionamento della pagina Gantt.cshtml
    public class Data
    {
        public static int selectedRow = 2;
        public static List<string> deletedTaskIds = new List<string>();
        public bool canWrite { get; set; }
        public bool canDelete { get; set; }
        public bool canWriteOnParent { get; set; }
        public bool canAdd { get; set; }

        public List<Task> tasks { get; set; }
        public List<Resource> resources { get; set; }
        public List<Role> roles { get; set; }

        // dati di prova
        public MoreInfo moreInfo { get; set; }
    }
}