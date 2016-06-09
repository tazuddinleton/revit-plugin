using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BIMAsistant;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

namespace BIMAsistant
{
    public partial class Create2DForm : System.Windows.Forms.Form
    {
        Autodesk.Revit.ApplicationServices.Application m_rvtApp;
        Document m_rvtDoc;

        
        HousingList housingListObject;
        FloorPlans floorPlans;
        public Create2DForm(ExternalCommandData commandData)
        {
            // get access to the top most objects 
            UIApplication rvtUIApp = commandData.Application;
            UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            m_rvtApp = rvtUIApp.Application;
            m_rvtDoc = rvtUIDoc.Document;
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (this.openXLfile.ShowDialog() == DialogResult.OK)
            {
                string filePath = this.filePath.Text = openXLfile.FileName;

                if (Path.GetExtension(filePath) == ".xlsx" || Path.GetExtension(filePath) == ".xls")
                {
                    housingListObject = new HousingList(openXLfile.FileName);
                    statusLabel.Text += "\n" + housingListObject.Rows.ToString() + " housing number loaded.";
                }
                else
                {
                    MessageBox.Show("Invalid file extension! \nPlease select '.xlsx' or '.xls' files only.");
                    this.statusLabel.Text += "\nHousing number not loaded.";
                }
            }
        }

        private void Create2DForm_Load(object sender, EventArgs e)
        {
            floorPlans = new FloorPlans(m_rvtDoc);
            var views = floorPlans.floorPlans;           

            for(int i = 0; i < views.Count(); i++)
            {
                ViewPlan view = views[i];
                Parameter param = view.get_Parameter(BuiltInParameter.VIEW_DEPENDENCY);
                
                if(param.AsString() == "Primary" || param.AsString() == "Independent")
                {
                    selectFloorPlan.Items.Add(view.Name.ToString());
                }
            }
        }

        private void selectFloorPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            floorPlans.selectedFloorPlan = floorPlans.floorPlans[selectFloorPlan.SelectedIndex];
        }

        private void createUnitPlans_Click(object sender, EventArgs e)
        {
            floorPlans.housingNum = housingListObject.GetHousingNumber();
            bool status = floorPlans.CreateDependents();
            if(status)
            {
                statusLabel.Text += "Successful";
            }
            else
            {
                statusLabel.Text += "Failed!";
            }
        }
    }
}
