using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWPROJECT_MVC.Models
{
    // oggetto task con gli attributi necessari per la visualizzazione/gestione
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public int progress { get; set; }
        public bool progressByWorklog { get; set; }
        public int relevance { get; set; }
        public string type { get; set; }
        public string typeID { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int level { get; set; }
        public string status { get; set; }
        public string depends { get; set; }
        public bool canWrite { get; set; }
        public long start { get; set; }
        public int duration { get; set; }
        public long end { get; set; }
        public bool startIsMilestone { get; set; }
        public bool endIsMilestone { get; set; }
        public bool collapsed { get; set; }
        public List<string> assigs { get; set; }
        public bool hasChild { get; set; }
        public MoreInfo moreInfo { get; set; }
    }
}