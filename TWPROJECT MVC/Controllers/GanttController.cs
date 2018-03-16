using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWPROJECT_MVC.Models;

// servono per la lettura della lingua
using System.Threading;
using System.Globalization;

// servono per la connessione al database su SQL server
using System.Data;
using System.Data.SqlClient;

namespace TWPROJECT_MVC.Controllers
{
    public class GanttController : Controller
    {
        public SQLConnection db;
        public static Data dbData;

        // permessi (di prova), necessari per specificare cosa può/non può fare l'utente
        // TODO: andranno letti dal db
        private bool puoScrivere = false;
        private bool puoAggiungere = false;
        private bool puoEliminare = false;
        private bool puoScrivereOnParent = false;

        // PAGINA DI PROVA
        // GET: /Gantt
        public ActionResult Index()
        {
            return View();
        }

        // CONTROLLER EFFETTIVO PER LA PAGINA GANTT
        // usando GET: /Gantt/Gantt chiamo la pagina che visualizza i dati, rappresentandoli attraverso un gantt
        public ActionResult Gantt()
        {
            // imposto la lingua del testo della pagina (View/Gantt/Gantt.cshtml)
            setLanguage();

            try
            {
                db = new SQLConnection(); // creo un oggetto SQLConnection con cui stabilire una connessione al database

                dbData = new Data(); // creo un nuovo oggetto Data in cui è specificata la struttura dell'oggetto json, per la pagina Gantt (View/Gantt/Gantt.cshtml)

                // creo e popolo la lista di Task, leggendo i dati dal db
                dbData.tasks = new List<Task>();
                dbData.tasks = getTasks();

                // creo e popolo la lista di Resource, leggendo i dati dal db
                dbData.resources = new List<Resource>();
                dbData.resources = getResources();

                // creo e popolo la lista di Role, leggendo i dati dal db
                dbData.roles = new List<Role>();
                dbData.roles = getRoles();

                // imposto i privilegi forniti all'utente che utilizzerà la pagina
                dbData.canWrite = puoScrivere;
                dbData.canAdd = puoAggiungere;
                dbData.canDelete = puoEliminare;
                dbData.canWriteOnParent = puoScrivereOnParent;

            }
            catch (SqlException e)
            {
            }

            db.connection.Close();


            return View(dbData);
        }

        // DA ELIMINARE
        // PROVA: GET: /Gantt/Prova
        public ActionResult Prova()
        {
            // imposto la lingua del testo della pagina
            setLanguage();

            try
            {
                db = new SQLConnection(); // creo un oggetto SQLConnection

                dbData = new Data(); // creo un nuovo oggetto Data

                // creo e popolo la lista di Task
                dbData.tasks = new List<Task>();
                dbData.tasks = getTasks();

                // creo e popolo la lista di Resource
                dbData.resources = new List<Resource>();
                dbData.resources = getResources();

                // creo e popolo la lista di Role
                dbData.roles = new List<Role>();
                dbData.roles = getRoles();

                dbData.canWrite = puoScrivere;
                dbData.canAdd = puoAggiungere;
                dbData.canDelete = puoEliminare;
                dbData.canWriteOnParent = puoScrivereOnParent;

            }
            catch (SqlException e)
            {
            }

            db.connection.Close();

            return View(dbData);
        }


        // interoga il db per farsi restituire la lista delle Tasks
        private List<Task> getTasks()
        {
            List<Task> tasks = new List<Task>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM tasks", db.connection); // predispongo la query che voglio eseguire
            db.connection.Open(); // apro la connessione con il db
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // eseguo la query

            try
            {
                int i = 0; // utilizzato per la generazione di dati di prova
                // leggo e memorizzo tutti i dati ricevuti dal db
                while (reader.Read())
                {
                    tasks.Add(new Task
                    {
                        id = -Convert.ToInt32(reader["ID"]),
                        name = reader["Name"].ToString(),
                        progress = Convert.ToInt32(reader["Progress"]),
                        progressByWorklog = Convert.ToBoolean(reader["ProgressByWorklog"]),
                        relevance = Convert.ToInt32(reader["Relevance"]),
                        type = reader["Type"].ToString(),
                        typeID = reader["TypeID"].ToString(),
                        description = reader["Description"].ToString(),
                        code = reader["Code"].ToString(),
                        level = Convert.ToInt32(reader["Level"]),
                        status = reader["Status"].ToString(),
                        depends = reader["Depends"].ToString(),
                        canWrite = Convert.ToBoolean(reader["CanWrite"]), 
                        start = Convert.ToInt64(reader["StartDate"]),
                        duration = Convert.ToInt32(reader["Duration"]),
                        end = Convert.ToInt64(reader["EndDate"]),
                        startIsMilestone = Convert.ToBoolean(reader["StartIsMilestone"]),
                        endIsMilestone = Convert.ToBoolean(reader["EndIsMilestone"]),
                        collapsed = Convert.ToBoolean(reader["Collapsed"]),
                        hasChild = Convert.ToBoolean(reader["HasChild"]),
                        assigs = new List<string>(),
                        moreInfo = createMoreInfoData(i) // aggiungo dati di prova all'oggetto
                        
                    });
                    i++;
                }
                // chiudo la connessione con il db
                reader.Close();

            }
            catch (SqlException e)
            {
                reader.Close();
            }

            return tasks;
        }


        // interroga il db per farsi restituire la lista delle Resources
        private List<Resource> getResources()
        {
            List<Resource> resources = new List<Resource>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM resources", db.connection); // predispongo la query che voglio eseguire
            db.connection.Open(); // apro la connessione con il db
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // eseguo la query

            try
            {

                // read and memorize all received data
                while (reader.Read())
                {
                    resources.Add(new Resource
                    {
                        id = reader["ID"].ToString(),
                        name = reader["Name"].ToString(),

                    });
                }

                reader.Close();

            }
            catch (SqlException e)
            {
                reader.Close();
            }

            return resources;
        }

        // interroga il db per farsi restituire la lista dei Role
        private List<Role> getRoles()
        {
            List<Role> roles = new List<Role>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM roles", db.connection); // predispongo la query che voglio eseguire
            db.connection.Open(); // apro la connessione con il db
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection); // eseguo la query

            try
            {

                // read and memorize all received data
                while (reader.Read())
                {
                    roles.Add(new Role
                    {
                        id = reader["ID"].ToString(),
                        name = reader["Name"].ToString(),

                    });
                }

                reader.Close();

            }
            catch (SqlException e)
            {
                reader.Close();
            }

            return roles;
        }

        // creo dati di prova
        private MoreInfo createMoreInfoData(int i)
        {
            MoreInfo data = new MoreInfo();
                data.codice = i;
                data.materiale = "mat" + i;
                data.lunghezza = i;
                data.costo = i + 2;
                data.info = "info"+i;
                data.nomeCommittente = "committ"+i;
                data.azienda = "az"+i;
            return data;
        }


        // imposta la lingua del testo della pagina
        private void setLanguage()
        {
            string lang = "it"; // cambiandolo con "en" prende usa il ile GanttLanguage.en (i seguenti 2 campi vanno modificati anche nel file Global.asax.cs)
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            // optional: salvo la lingua scelta in un cookie
            /*HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = "it";
            Response.Cookies.Add(cookie);*/
        }

    }
}