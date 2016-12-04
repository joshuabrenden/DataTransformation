using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformation
{
    class Person
    {

        public string name { get; set; }
        public string age { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        public string gender { get; set; }
        public bool isStudent { get; set; }
        public bool isEmployee { get; set; }

        public Person()
        {

        }

        public string getFormattedPerson()
        {
            //Creates a formatted string for the person.
            //I would have liked to refactor this, as it is a bit sloppy and needs to account for other fields not existing (if a person didn't have a city etc)
            StringBuilder sb = new StringBuilder(name);
            string isStudentString = isStudent ? "Yes" : "No";
            string isEmployeeString = isEmployee ? "Yes" : "No";

            sb.Append(" [");

            if (!String.IsNullOrEmpty(age))
            {
                sb.Append(age)
                  .Append(", ");
            }

            sb.Append(gender)
              .Append("]")
              .AppendLine()
              .Append("    ")
              .Append("City     : ")
              .Append(city)
              .AppendLine()
              .Append("   ");

            if(!String.IsNullOrEmpty(state))
            {
                sb.Append(" State    : ")
                  .Append(state)
                  .AppendLine()
                  .Append("   ");
            }

            sb.Append(" Student  : ")
              .Append(isStudentString)
              .AppendLine().Append("    ")
              .Append("Employee : ")
              .Append(isEmployeeString);

            return sb.ToString(); 
        }
        
    }
}
