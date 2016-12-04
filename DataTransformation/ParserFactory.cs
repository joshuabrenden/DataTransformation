using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class ParserFactory
    {
        public static Parser getParser(string parserType)
        {
            switch (parserType)
            {
                case "person":
                    return new NameParser();
                case "age":
                    return new AgeParser();
                case "city":
                    return new CityParser();
                case "flags":
                    return new FlagsParser();
                default:
                    throw new ApplicationException(string.Format("Parser '{0}' cannot be created", parserType));
            }
        }
    }
}
