using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    public class Data
    {
        public static int selectedRow = 2;
        public static List<string> deletedTaskIds = new List<string>();
        //public static bool canWrite = false;
        //public static bool canDelete = false;
        //public static bool canWriteOnParent = false;
        //public static bool canAdd = false;


        public List<Task> tasks { get; set; }
        public List<Resource> resources { get; set; }
        public List<Role> roles { get; set; }

        // dati di prova
        public MoreInfo moreInfo { get; set; }
        public bool canWrite { get; set; }
        public bool canDelete { get; set; }
        public bool canWriteOnParent { get; set; }
        public bool canAdd { get; set; }


    }
}