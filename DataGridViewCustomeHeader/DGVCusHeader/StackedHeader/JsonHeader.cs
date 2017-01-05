using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackedHeader
{
    public class JsonHeader
    {
        public JsonHeader(string text)
        {
            this.T = text;
            this.C = new List<JsonHeader>();
        }
        public string T { get; set; }
        public List<JsonHeader> C;
    }
}
