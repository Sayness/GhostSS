using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhostSS.model
{
    public class Result
    {
        public string result { get; set; }

        public Result(string result)
        {
            this.result = result;
        }
    }
}
