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
using Excel = Microsoft.Office.Interop.Excel;

namespace BIMAsistant
{
    public class HousingList
    {
        
        public int Rows;
        public int Cols;
        private List<List<string>> Columns = new List<List<string>>();

        
        private string FilePath = string.Empty;
        private object missValue = System.Reflection.Missing.Value;

        private Excel.Application XL;
        private Excel.Workbook Book;
        private Excel.Worksheet Sheet;
        private Excel.Range Range;

        private object[,] Values = null;
       
        public HousingList(string FilePath)
        {
            this.FilePath = FilePath;
            this.Read();
            this.SetColumns();
            this.SanitizeHousingNumber();
            this.Release(this.Sheet);
            this.Release(this.Book);
            this.Release(this.XL);
        }
        private void Read()
        {
            try
            {
                this.XL = new Excel.Application();
                this.Book = XL.Workbooks.Open(this.FilePath, 0, true, 5, "", "");
                this.Sheet = (Excel.Worksheet)this.XL.Worksheets.get_Item(1);
                this.Range = this.Sheet.UsedRange;
                this.Values = (object[,])this.Range.Value2;
                this.Rows = this.Values.GetLength(0);
                this.Cols = this.Values.GetLength(1);

            }
            catch (Exception Error)
            {
                TaskDialog.Show("HousingList", "Unable to open Excel file " + Error.ToString());
            }

        }

        private void SetColumns()
        {
            for(int i = 0; i < this.Cols; i++)
            {
                List<string> placeHolder = new List<string>();
                for(int j = 0; j < this.Rows; j++)
                {
                   
                    placeHolder.Add(this.Values[j + 1, i + 1].ToString());
                }
                this.Columns.Add(placeHolder);
            }
        }

        private void SanitizeHousingNumber()
        {
            List<string> col1 = this.Columns[0];
            for(int i = 0; i < this.Rows; i++)
            {
                string[] words = col1[i].Split('-');
                this.Columns[0][i] = words[2];
            }
        }

        private void Release(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception Error)
            {
                obj = null;
                TaskDialog.Show("HousingList", "Unable to release the Object " + Error.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        

        public List<string> GetHousingNumber()
        {
            return this.Columns[0];
        }

         

    }
}
