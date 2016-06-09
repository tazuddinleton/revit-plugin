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
    [Transaction(TransactionMode.Automatic)]
    public class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            string tabName = "BIM Utils";
            application.CreateRibbonTab(tabName);

            RibbonPanel creation = application.CreateRibbonPanel(tabName,"Creation");

            PushButtonData sheetButtonData = new PushButtonData("cmdCreateSheet", "Sheet", thisAssemblyPath, "BIMAsistant.CreateSheets");
            PushButton sheet = creation.AddItem(sheetButtonData) as PushButton;
            sheet.ToolTip = "Create sheets automatically and place 2D unitplan and 3D views automatically";
            BitmapImage sheetIcon = new BitmapImage(new Uri("pack://application:,,,/BIMAsistant;component/Resources/sheet.png"));
            sheet.LargeImage = sheetIcon;

            // create 2D button
            
            PushButtonData unitPlanButtonData = new PushButtonData("cmdCreateFloorPlans", "Unit 2D", thisAssemblyPath, "BIMAsistant.CreateFloorPlans");

            PushButton unitPlan = creation.AddItem(unitPlanButtonData) as PushButton;

            unitPlan.ToolTip = "Create 2D unitplan from housing number";
            unitPlan.LargeImage = sheetIcon;

            // create 3D button

            //PushButtonData unit3DButtonData = new PushButtonData("cmdCreate3DViews", "3D Views", thisAssemblyPath, "BIMAsistant.CreateFloorPlans");

            //PushButton unit3D = creation.AddItem(unit3DButtonData) as PushButton;

            //unit3D.ToolTip = "Create 3D views";
           // BitmapImage unit3DIcon = new BitmapImage(new Uri("pack://application:,,,/BIMAsistant;component/Resources/unit3D.png"));
           // unit3D.LargeImage = unit3DIcon;
             
            return Result.Succeeded;
        }
    }
}
