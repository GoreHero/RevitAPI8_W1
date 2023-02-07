using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI8_W2
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document; 

            NavisworksExportOptions nwсOptions = new NavisworksExportOptions 
            {
                ExportScope = NavisworksExportScope.Model,

                ViewId = doc.ActiveView.Id
            };

            doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Export.nwc", nwсOptions);
            
            TaskDialog.Show("Инфо", "Готово");

            return Result.Succeeded;

        }
    }
}