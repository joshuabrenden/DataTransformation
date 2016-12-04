using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    interface IParser
    {
        Dictionary<string, string> parse(string key, string value);
    }
}
