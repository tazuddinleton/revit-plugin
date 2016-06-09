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
    class CreateFloorPlans : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {           
            Create2DForm create2D = new Create2DForm(commandData);
            create2D.ShowDialog();
            return Result.Succeeded;
        }
    }
}
