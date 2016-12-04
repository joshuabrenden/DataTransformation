using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class CityParser : Parser
    {
        override
        public Dictionary<string, string> parse(string key, string value)
        {

            Dictionary<string, string> parsedData = new Dictionary<string, string>
            {
                { key.Trim(), value.Trim() }
            };

            if (value.Contains(","))
            {
                parsedData.Add("state", value.Remove(0, value.IndexOf(",") + 2));
            }
            
            return parsedData;
        }
    }
}
