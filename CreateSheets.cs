using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
namespace BIMAsistant
{
    [Transaction(TransactionMode.Manual)]
    public class CreateSheets : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CreateSheetForm createSheetForm = new CreateSheetForm(commandData);
            createSheetForm.ShowDialog();

            
            

            return Result.Succeeded;            
        }       

        
    }  


}
