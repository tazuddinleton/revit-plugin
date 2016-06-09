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
    public partial class CreateSheetForm : System.Windows.Forms.Form
    {
        Autodesk.Revit.ApplicationServices.Application m_rvtApp;
        Document m_rvtDoc;

        TitleBlocks titleBlockObject;
        HousingList housingListObject;
        Sheet sheetObject;

        public CreateSheetForm(ExternalCommandData commandData)
        {
            // get access to the top most objects 
            UIApplication rvtUIApp = commandData.Application;
            UIDocument rvtUIDoc = rvtUIApp.ActiveUIDocument;
            m_rvtApp = rvtUIApp.Application;
            m_rvtDoc = rvtUIDoc.Document;
            InitializeComponent();
        }

        private void CreateSheetForm_Load(object sender, EventArgs e)
        {
            titleBlockObject = new TitleBlocks(m_rvtDoc);
            IList<Element> titleBlocks = titleBlockObject.IList;
            foreach(Element tBlock in titleBlocks)
            {
                this.selectTitleBox.Items.Add(tBlock.Name.ToString());
            }
            statusLabel.Text += "\n" + titleBlockObject.Count().ToString() + " titleblock(s) found.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectTitleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            titleBlockObject.TitleBlock = titleBlockObject.IList[selectTitleBox.SelectedIndex] as FamilySymbol;            
           
        }

        

        private void browseButton_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AppInfo appData = new AppInfo();
            appData.Show();

        }

        private void createSheetsButton_Click(object sender, EventArgs e)
        {
            string name = inputSheetName.Text;
            string suffix = inputSheetNumSuffix.Text;

            /*
             * 
             *  if (String.IsNullOrWhiteSpace(filePath.Text))
            {
                MessageBox.Show("Please select housing list!");
            }
             else 
             * */

            if (this.titleBlockObject.TitleBlock == null)            
            {
                MessageBox.Show("Title block not selected!");
                 
            }
            else if ((String.IsNullOrWhiteSpace(name) || (string.IsNullOrWhiteSpace(name))))
            {
                MessageBox.Show("Please correct name and number suffix!");
            }
            else 
            {
                if(suffix == "2D")
                {
                    sheetObject = new Sheet(m_rvtDoc, name, suffix, titleBlockObject.TitleBlock);//, housingListObject.GetHousingNumber()
                    bool status = sheetObject.creatSheetFromIDs(); //sheetObject.CreateSheet2D();
                    if (status)
                    {
                        statusLabel.Text += "\nSuccessful!.";
                    }
                    else
                    {
                        statusLabel.Text += "\nFailed!";
                    }
                }
                else if(suffix == "3D")
                {
                    sheetObject = new Sheet(m_rvtDoc, name, suffix, titleBlockObject.TitleBlock);//housingListObject.GetHousingNumber()
                    bool status = sheetObject.CreateSheet3D();
                    if(status)
                    {
                        statusLabel.Text += "\nSuccessful!.";
                    }
                    else
                    {
                        statusLabel.Text += "\nFailed!";
                    }
                }
                else
                {
                    MessageBox.Show("Pleaase correct number suffix!");
                }
            }
        }
    }
}
