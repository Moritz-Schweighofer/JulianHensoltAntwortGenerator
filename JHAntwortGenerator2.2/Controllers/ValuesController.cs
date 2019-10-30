using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JHAntwortGenerator2._2.Controllers
{
    [Consumes("application/json", "text/plain", "multipart/form-data", "application/x-www-form-urlencoded")]
    [Produces("text/html")]
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            //Liste Teil 1
            System.IO.StreamReader SRTeil1 = new System.IO.StreamReader("Teil1.txt");
            List<string> ListeTeil1 = new List<string>();

            while (SRTeil1.EndOfStream == false)
            {
                string Zeile = SRTeil1.ReadLine();
                ListeTeil1.Add(Zeile);
            }

            System.IO.StreamReader SRTeil2 = new System.IO.StreamReader("Teil2.txt");
            List<string> ListeTeil2 = new List<string>();
            while (SRTeil2.EndOfStream == false)
            {
                string Zeile = SRTeil2.ReadLine();
                ListeTeil2.Add(Zeile);
            }

            System.IO.StreamReader SRTeil3 = new System.IO.StreamReader("Teil3.txt");
            List<string> ListeTeil3 = new List<string>();
            while (SRTeil3.EndOfStream == false)
            {
                string Zeile = SRTeil3.ReadLine();
                ListeTeil3.Add(Zeile);
            }

            string Antwort = "";
            Random zufall = new Random();

            int Auswahl = zufall.Next(0, ListeTeil1.Count() - 1);
            Antwort = Antwort + ListeTeil1[Auswahl];

            Auswahl = zufall.Next(0, ListeTeil2.Count() - 1);
            Antwort = Antwort + " " + ListeTeil2[Auswahl];

            Auswahl = zufall.Next(0, ListeTeil3.Count() - 1);
            Antwort = Antwort + " " + ListeTeil3[Auswahl];
            string prefix = "<html><body><font size=\"130%\">";
            string sufix = "</font> </body> </html>";
            return Content(prefix + Antwort + sufix, "text/html", System.Text.Encoding.Default);
        }
    }
}
