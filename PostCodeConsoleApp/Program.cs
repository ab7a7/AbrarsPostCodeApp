using PostCodeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var csv = File.ReadAllText("import_data.csv").Split('\n');

            var failedCSV = new StringBuilder();
            foreach(var row in csv)
            {
                var splitRow = row.Split(',');
                if (splitRow != null && splitRow.Length > 1)
                {
                    var validator = new PostCodeValidator(splitRow[1]);
                    if (!validator.IsValidPostCode())
                    {
                        failedCSV.AppendLine(string.Format("{0},{1}", splitRow[0], splitRow[1]));
                    }
                }
            }

            File.WriteAllText("failed_validation.csv", failedCSV.ToString());
        }
    }
}
