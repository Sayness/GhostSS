using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostSS.model
{
    public class Processus
    {
        public string name { get; set; }
        public List<Result> results { get; set; }

        public Processus(string name)
        {
            this.results = new List<Result>();
            this.name = name;
        }
    }
}
