using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMAsistant
{
    class AppInfo
    {
        public string appName = "Name : BIM Utils\n";
        public string appVersion = "Version : 3.0\n";
        public string developedBy = "Developed By : Taz Uddin\n";
        public string releaseDate = "Release Date : April 8, 2016\n";
        
        public void Show()
        {
            string str = appName + appVersion + developedBy + releaseDate;
            MessageBox.Show(str);
        }
        
    }
}
