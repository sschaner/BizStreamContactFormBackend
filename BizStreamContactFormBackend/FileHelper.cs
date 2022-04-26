using BizStreamContactFormBackend.DataTransferObjects.PersonContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizStreamContactFormBackend
{
    public class FileHelper
    {
        public static void AddPersonToFile(string path, Person person)
        {
            StreamWriter writer = new StreamWriter(path, true);
            StringBuilder builder = new StringBuilder();
            builder.Append(person.FirstName);
            builder.Append("|");
            builder.Append(person.LastName);
            builder.Append("|");
            builder.Append(person.Email);
            builder.Append("|");
            builder.Append(person.Message);
            writer.WriteLine(builder.ToString(), true);
            writer.Flush();
            writer.Close();
        }
    }
}
