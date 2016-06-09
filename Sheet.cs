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
    class Sheet
    {
        private string sheetName;
        private string numSuffix;
        private Autodesk.Revit.DB.Document m_rvtDoc;
        private List<ViewPlan> floorPlans;
        private List<View3D> view3Ds;
        private FamilySymbol titleBlock;
        private List<string> housingNum;
        private ICollection<ElementId> viewIDs;

        public Sheet(Autodesk.Revit.DB.Document m_rvtDoc, string sheetName, string numSuffix, FamilySymbol titleBlock)// List<string> housingNum
        {
            this.m_rvtDoc = m_rvtDoc;
            this.sheetName = sheetName;
            this.numSuffix = numSuffix;
            this.titleBlock = titleBlock;
            //this.housingNum = housingNum;            
            this.floorPlans = this.Get2D();          
            this.view3Ds = Get3D();            
        }
        /*
        public void CreateSheet2D()
        {
            if(titleBlock != null && housingNum.Count() > 0)
            {
                using (Transaction t = new Transaction(m_rvtDoc, "Create a new ViewSheet"))
                {
                    t.Start();
                    try
                    {
                        for(int i = 0; i < housingNum.Count(); i++)
                        {
                            ViewSheet viewSheet = ViewSheet.Create(m_rvtDoc, titleBlock.Id);
                            if(viewSheet == null)
                            {
                                throw new Exception("Failed to create new Sheet");
                            }
                            viewSheet.Name = this.sheetName;
                            viewSheet.SheetNumber = housingNum[i] + "-" + this.numSuffix;

                            // place views on sheet
                            for (int j = 0; j < this.floorPlans.Count(); j++)
                            {
                                if(this.floorPlans[j].Name.ToString() + "-" + this.numSuffix == viewSheet.SheetNumber)
                                {
                                    UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2, (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                                    Viewport viewPort = Viewport.Create(m_rvtDoc, viewSheet.Id, this.floorPlans[j].Id, new XYZ(location.U, location.V, 0));
                                    this.floorPlans.Remove(this.floorPlans[j]);
                                }
                            }
                        }
                        t.Commit();
                    }
                    catch
                    {
                        t.RollBack();
                    }
                }
            }
        } */
         


        public bool CreateSheet2D()
        {
            if (titleBlock != null && this.floorPlans.Count() > 0)
            {                
                using (Transaction t = new Transaction(m_rvtDoc, "Create sheet using view"))
                {
                    t.Start();
                    try
                    {
                        for (int i = 0; i < floorPlans.Count(); i++)
                        {
                            ViewSheet viewSheet = ViewSheet.Create(m_rvtDoc, titleBlock.Id);
                            if (viewSheet == null)
                            {
                                throw new Exception("Failed to create new Sheet");
                            }
                            viewSheet.Name = this.sheetName;
                            viewSheet.SheetNumber = floorPlans[i].Name.ToString() +"-" + this.numSuffix;
                            UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2, (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                            Viewport viewPort = Viewport.Create(m_rvtDoc, viewSheet.Id, this.floorPlans[i].Id, new XYZ(location.U, location.V, 0));
                            
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
            return false;
        }


        public bool creatSheetFromIDs()
        {
            if (titleBlock != null && this.floorPlans.Count() > 0)
            {
                using (Transaction t = new Transaction(m_rvtDoc, "Create sheet using view"))
                {
                    t.Start();
                    try
                    {
                        for (int i = 0; i < floorPlans.Count(); i++)
                        {
                            ICollection<ElementId> IDs = this.GetDependenViewsID(this.floorPlans[i]);
                            foreach (ElementId ID in IDs)
                            {
                                ViewPlan view = m_rvtDoc.GetElement(ID) as ViewPlan;

                                ViewSheet viewSheet = ViewSheet.Create(m_rvtDoc, titleBlock.Id);
                                if (viewSheet == null)
                                {
                                    throw new Exception("Failed to create new Sheet");
                                }
                                viewSheet.Name = this.sheetName;
                                viewSheet.SheetNumber = view.Name.ToString() + "-" + this.numSuffix;
                                UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2, (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                                Viewport viewPort = Viewport.Create(m_rvtDoc, viewSheet.Id, ID, new XYZ(location.U, location.V, 0));
                            }

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
            return false;
        }

        /*
        public void CreateSheet3D()
        {
            if (titleBlock != null && housingNum.Count() > 0)
            {
                using (Transaction t = new Transaction(m_rvtDoc, "Create a new ViewSheet"))
                {
                    t.Start();
                    try
                    {
                        for (int i = 0; i < housingNum.Count(); i++)
                        {
                            ViewSheet viewSheet = ViewSheet.Create(m_rvtDoc, titleBlock.Id);
                            if (viewSheet == null)
                            {
                                throw new Exception("Failed to create new Sheet");
                            }
                            viewSheet.Name = this.sheetName;
                            viewSheet.SheetNumber = housingNum[i] + "-" + this.numSuffix;

                            // place views on sheet
                            for (int j = 0; j < this.view3Ds.Count(); j++)
                            {
                                if (this.view3Ds[j].Name.ToString() + "-" + this.numSuffix == viewSheet.SheetNumber)
                                {
                                    UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2, (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                                    Viewport viewPort = Viewport.Create(m_rvtDoc, viewSheet.Id, this.view3Ds[j].Id, new XYZ(location.U, location.V, 0));
                                    view3Ds.Remove(view3Ds[j]);
                                }
                            }
                        }
                        t.Commit();
                    }
                    catch
                    {
                        t.RollBack();
                    }
                }
            }
        }
        */

        public bool CreateSheet3D()
        {
            if (titleBlock != null && view3Ds.Count() > 0)
            {
                using (Transaction t = new Transaction(m_rvtDoc, "Create a new sheet using available 3d views"))
                {
                    t.Start();
                    try
                    {
                        for (int i = 0; i < view3Ds.Count(); i++)
                        {
                            ViewSheet viewSheet = ViewSheet.Create(m_rvtDoc, titleBlock.Id);
                            if (viewSheet == null)
                            {
                                throw new Exception("Failed to create new Sheet");
                            }
                            viewSheet.Name = this.sheetName;
                            
                            viewSheet.SheetNumber = view3Ds[i].Name.ToString() + "-" + this.numSuffix;

                            UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2, (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                            Viewport viewPort = Viewport.Create(m_rvtDoc, viewSheet.Id, this.view3Ds[i].Id, new XYZ(location.U, location.V, 0));
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
            return false;
        }

        private List<ViewPlan> Get2D()
        {            
            List<ViewPlan> views = new List<ViewPlan>(new FilteredElementCollector(m_rvtDoc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>().Where<ViewPlan>(v => !v.IsTemplate && ViewType.FloorPlan == v.ViewType));
            
            return views;
        }

        private List<View3D> Get3D()
        {           
            List<View3D> views = new List<View3D>(new FilteredElementCollector(m_rvtDoc).OfClass(typeof(View3D)).Cast<View3D>().Where<View3D>(v => !v.IsTemplate && ViewType.ThreeD == v.ViewType));

            return views;
        } 

        private ICollection<ElementId> GetDependenViewsID(ViewPlan floorPlan)
        {
            return floorPlan.GetDependentViewIds();
            
        }

    }
}
