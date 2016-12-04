using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    public abstract class Parser : IParser
    {
        abstract public Dictionary<string, string> parse(string key, string value);
    }
}
