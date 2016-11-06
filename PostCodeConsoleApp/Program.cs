using PostCodeConsoleApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PostCodeConsoleApp
{
    class Program
    {
        /// <summary>
        /// I dont think the regex used covers overseas territories. This is because
        /// they use a different format some can have 4 letters with only 1 number.
        /// The regex given eensures a "9AA" ending which doesnt apply to Anguilla.
        /// Also in some other cases we have 4 characters together. Which will fail too.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Loading CSV");
            var csv = File.ReadAllText("import_data.csv").Split('\n')
                .Select(line => line.Split(','))
                .Where(line => line != null && line.Length > 1 && !line[0].Contains("row"))
                .ToDictionary(line => int.Parse(line[0]), line => line[1]);
            var failedCSV = new StringBuilder();
            var successCSV = new StringBuilder();
            var header = string.Format("{0},{1}", "row_id", "postcode");
            failedCSV.AppendLine(header);
            successCSV.AppendLine(header);

            var validator = new PostCodeValidator(string.Empty);
            Console.WriteLine("Sorting CSV by id");
            var orderedCSV = csv.OrderBy(dict => dict.Key);
            Console.WriteLine("Verifying PostCodes");
            foreach (var row in orderedCSV)
            {
                validator.PostCodeToVerify = row.Value;
                var postcode = string.Format("{0},{1}", row.Key, row.Value);
                if (validator.IsValidPostCode())
                {
                    successCSV.AppendLine(postcode);
                }
                else
                {
                    failedCSV.AppendLine(postcode);
                }
            }
            File.WriteAllText("succeeded_validations.csv", successCSV.ToString());
            File.WriteAllText("failed_validation.csv", failedCSV.ToString());
            Console.WriteLine("Validation Compelted Press a key to exit");
            Console.Read();
        }
    }
}
