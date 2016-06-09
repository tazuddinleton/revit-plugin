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
    class FloorPlans
    {
        private Autodesk.Revit.DB.Document m_rvtDoc;
        public ViewPlan selectedFloorPlan = null;
        public List<ViewPlan> floorPlans;
        public List<string> housingNum = null;
        
        public FloorPlans(Autodesk.Revit.DB.Document m_rvtDoc)
        {
            this.m_rvtDoc = m_rvtDoc;
            this.floorPlans = new List<ViewPlan>(new FilteredElementCollector(m_rvtDoc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().Where<ViewPlan>(v => !v.IsTemplate && ViewType.FloorPlan == v.ViewType));
        }
        
        
        public bool CreateDependents()
        {
            ElementId levelID = this.selectedFloorPlan.get_Parameter(BuiltInParameter.PLAN_VIEW_LEVEL).Id;            

            

            if(this.selectedFloorPlan != null && this.housingNum != null)
            {
                using (Transaction t = new Transaction(m_rvtDoc, "Create dependent views"))
                {
                    t.Start();
                    try
                    {
                        for (int i = 0; i < housingNum.Count(); i++ )
                        {
                            ElementId viewID = this.selectedFloorPlan.Duplicate(ViewDuplicateOption.AsDependent);
                            ViewPlan plan = m_rvtDoc.GetElement(viewID) as ViewPlan;
                            if(plan == null)
                            {
                                throw new Exception("Can't create dependent views");
                            }
                            plan.Name = housingNum[i];
                           // var shape = plan.GetCropRegionShapeManager();
                            
                        }

                            t.Commit();
                        return true;
                    }
                    catch
                    {
                        t.RollBack();
                    }
                }
            }
            else
            {
                TaskDialog.Show("Revit", housingNum.ToString() + selectedFloorPlan.ToString());
            }
            return false;
        }
    }
}
