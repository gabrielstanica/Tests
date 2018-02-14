using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMethodRepetitive();
        }

        public static void TestMethodRepetitive()
        {

            WebExtract.Page_Load();
            //RemoveFiles.DeleteFiles(@"D:\gastanica_RO-3050829_5456\EAOS\QECS\TOOLS\GatorScripts\ScriptLauncher\Launcher\StarWars_Heroes\Test_003_GalacticWars", "res_");
            //var st = new StackTrace();
            //var name = SplitCamelCase.GetMethodName(st);
            //SplitCamelCase s = new SplitCamelCase(0, 100);
            //s.RepetetiveSteps(name, 10000);

            Console.ReadKey();
        }
    }
}
