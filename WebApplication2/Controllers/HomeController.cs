using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace WebApplication2.Controllers
{
    public class HomeController : ApiController
    {
        List<string> ClassIt = new List<String>()
        {
            "Il Gatto è sul Tavolo",
            "Gli indirizzi dei servizi web non sono scrivibili in questo contatto."
        };
        List<string> ClassEng = new List<string>
        {
            "The Cat is on the Table",
            "Web service addresses are not writeable on this contact."
        };
        [HttpGet]
       // public IEnumerable<string> GetLabels(string Language)
            public HttpResponseMessage Authenticate(string Language)
        {
            if (Language == "it")
            {
                string XML = "<note><body>Gli indirizzi dei servizi web non sono scrivibili in questo contatto.</body></note>";
                return new HttpResponseMessage()
                {
                    Content = new StringContent(XML, Encoding.UTF8, "application/xml")
                };
            }
            else
            {
                string XML = "<note><body>Web service addresses are not writeable on this contact.</body></note>";
                return new HttpResponseMessage()
                {
                    Content = new StringContent(XML, Encoding.UTF8, "application/xml")
                };
            }
        }
    }
}
