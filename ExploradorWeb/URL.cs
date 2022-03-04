using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploradorWeb
{
    internal class URL
    {
        public string Url { get; set; }
        public int contador { get; set; }
        public DateTime fechaVisitada { get; set; }

        public string pagina()
        {
            string buscar;
            if (Url.Contains("."))
            {
                if (!Url.Contains("https://"))
                {
                    buscar = "https://" + Url;
                    return buscar;
                }
                else
                    return Url;
            }
            else
                buscar = "http://www.google.com/search?q=" + Url;

            return buscar;
        }
    }
}
