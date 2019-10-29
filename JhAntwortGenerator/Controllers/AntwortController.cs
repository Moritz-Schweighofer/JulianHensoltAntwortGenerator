using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JhAntwortGenerator.Controllers
{
    [Consumes("application/json", "text/plain", "multipart/form-data", "application/x-www-form-urlencoded")]
    [Produces("text/html")]
    [Route("[controller]")]
    [ApiController]
    public class AntwortController : ControllerBase
    {
        // GET: api/Antwort
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
            Antwort = Antwort + " <br/> " + ListeTeil2[Auswahl];

            Auswahl = zufall.Next(0, ListeTeil3.Count() - 1);
            Antwort = Antwort + " <br/> " + ListeTeil3[Auswahl];
            string prefix = "<html><body><font size=\"130%\">";
            string sufix = "</font> </body> </html>";
            return Content(prefix + Antwort + sufix,"text/html");
        }

        // GET: api/Antwort/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Antwort
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Antwort/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
