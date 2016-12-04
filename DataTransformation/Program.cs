using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonBuilder parser = new PersonBuilder(getInputFileString());
            List<Person> persons = parser.getPersons();

            foreach (Person person in persons)
                Console.WriteLine(person.getFormattedPerson());

            Console.WriteLine("Press any key to quit.");
            Console.Read();
        }

        //Gets the full text of the file
        //File must be located in the bin folder (would've liked to have it take the path from args in main)
        static string getInputFileString()
        {
            string rawPersonText = null;

            try
            {
                using (StreamReader sr = new StreamReader("InputFile.txt"))
                {
                    rawPersonText = sr.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not read file.");
                Console.WriteLine(e.Message);
            }

            return rawPersonText;
        }
    }
}
