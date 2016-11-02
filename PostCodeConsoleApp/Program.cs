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
            var values = File.ReadAllText("import_data.csv").Split(',');
        }
    }
}
