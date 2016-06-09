using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
namespace BIMAsistant
{
    class TitleBlocks
    {      
        public FamilySymbol TitleBlock = null;
        public IList<Element> IList;

        public TitleBlocks(Autodesk.Revit.DB.Document m_rvtDoc)
        {
            FilteredElementCollector titleBlockcollector = new FilteredElementCollector(m_rvtDoc);
            titleBlockcollector.OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_TitleBlocks);
            this.IList = titleBlockcollector.ToElements();    
        }

        public int Count()
        {
            return this.IList.Count();
        }
    }
}
