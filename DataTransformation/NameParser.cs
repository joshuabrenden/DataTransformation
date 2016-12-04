using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class NameParser : Parser
    {
        override
        public Dictionary<string, string> parse(string key, string value) {
            return new Dictionary<string, string>
            {
                { key.Trim(), value.Trim() }
            };
        }
    }
}
