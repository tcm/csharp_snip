using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessReportsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // this code requires the following COM reference in the project:
            // Microsoft Access 14.0 Object Library
            //
            var objAccess = new Microsoft.Office.Interop.Access.Application();
            objAccess.Visible = false;
            objAccess.OpenCurrentDatabase(@"\\filesrv\Entwicklung\TESTDB.accdb");

            

            string queryName = "RECHNUNG";
            string reportName = "Bericht_RECHNUNG";

            objAccess.CurrentDb().QueryDefs[queryName].SQL = string.Format("EXEC erzeuge_Rechnung '583234'");
            objAccess.DoCmd.OpenReport(reportName);
            objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acReport, reportName);

            objAccess.CurrentDb().QueryDefs[queryName].SQL = string.Format("EXEC erzeuge_Rechnung '583235'");
            objAccess.DoCmd.OpenReport(reportName);
            objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acReport, reportName);

            objAccess.CurrentDb().QueryDefs[queryName].SQL = string.Format("EXEC erzeuge_Rechnung '583236'");
            objAccess.DoCmd.OpenReport(reportName);
            objAccess.DoCmd.Close(Microsoft.Office.Interop.Access.AcObjectType.acReport, reportName);

        

            objAccess.CloseCurrentDatabase();
            objAccess.Quit();


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
