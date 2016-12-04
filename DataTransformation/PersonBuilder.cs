using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class PersonBuilder
    {
        private string rawPersonText;
        public List<Person> persons = new List<Person>();

        public PersonBuilder(String rawPersonText)
        {
            this.rawPersonText = rawPersonText;
            createPersons();
        }

        private void createPersons()
        {
            //Splits the raw data into separate people by empty lines
            string[] rawPersons = getRawPersons(rawPersonText);

            //Iterates through the raw data and creates a Person object
            foreach (string rawPerson in rawPersons)
                persons.Add(parsePerson(rawPerson));
        }

        private Person parsePerson(string rawPerson)
        {
            //Creates a Person object from the raw data
            //This method is a little long, I would have liked to refactor a bit to make it shorter and more readable
            Person person = new Person();

            //Splits into individual lines of info about the person
            string[] rawPersonInfo = getRawPersonInfo(rawPerson);

            foreach (string infoLine in rawPersonInfo)
            {
                //Each line has a key and a value
                string key = parsekey(infoLine);
                string value = parseValue(infoLine);

                if (String.Equals(key, "(Name)"))
                {
                    person.name = value;
                }
                else if (String.Equals(key, "(Age)"))
                {
                    person.age = value;
                }
                //Sometimes the city has a state, so need to handle that case
                else if (String.Equals(key, "(City)"))
                {
                    if (value.Contains(","))
                    {
                        person.city = parseCity(value);
                        person.state = parseState(value);
                    }
                    else
                    {
                        person.city = value;
                    }
                }
                else if (String.Equals(key, "(Flags)"))
                {
                    person.gender = parseFemaleFlag(value) ? "Female" : "Male";
                    person.isStudent = parseStudentFlag(value);
                    person.isEmployee = parseEmployeeFlag(value);
                }
            }


            return person;
        }

        private string[] getRawPersons(string rawPersonDate)
        {
            return rawPersonText.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] getRawPersonInfo(string rawPerson)
        {
            return rawPerson.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string parsekey(string infoLine)
        {
            return infoLine.Substring(1, infoLine.IndexOf(")")).ToLower();
        }

        private string parseValue(string infoLine)
        {
            return infoLine.Remove(0, infoLine.IndexOf(")") + 1);
        }

        private string parseCity(string value)
        {
            return value.Substring(0, value.IndexOf(","));
        }

        private string parseState(string value)
        {
            return value.Remove(0, value.IndexOf(",") + 2);
        }

        private bool parseFemaleFlag(string flagValue)
        {
            return char.Equals(flagValue[0], 'Y');
        }

        private bool parseStudentFlag(string flagValue)
        {
            return char.Equals(flagValue[1], 'Y');
        }

        private bool parseEmployeeFlag(string flagValue)
        {
            return char.Equals(flagValue[2], 'Y');
        }

        public List<Person> getPersons()
        {
            return persons;
        }

        private class ParsedPerson
        {
            private Dictionary<string, string> personData;
            private Person person = new Person();

            public ParsedPerson(Dictionary<string, string> personData)
            {
                this.personData = personData;
            }

            private void createPerson()
            {
                person.name = personData["name"];
                person.age = personData["age"];
                person.city = personData["city"];
                person.state = personData["state"];
  
            }

            public Person getPerson()
            {
                return person;
            }
        }
    }
}
