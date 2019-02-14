using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GoogleDriveService;
using Microsoft.Office.Tools.Ribbon;

namespace PowerPointAddIn1
{
    public partial class Ribbon1
    {
        public static bool pwr_btn = false;
        public static bool lng_btn = true; //hebrew

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            if (!pwr_btn)
            {
                this.toggleButton1.Image = this.toggleButton2.Image;
                this.toggleButton1.Label = "ON";
                pwr_btn = true;
            }

            else
            {
                this.toggleButton1.Image = this.toggleButton3.Image;
                this.toggleButton1.Label = "OFF";
                pwr_btn = false;
            }
        }

        private void dropDown1_SelectionChanged(object sender, RibbonControlEventArgs e)
        {

        }

        private void menu1_ItemsLoading(object sender, RibbonControlEventArgs e)
        {

        }

        private void toggleButton4_Click(object sender, RibbonControlEventArgs e)
        {
            if (lng_btn)
            {
                this.toggleButton4.Label = "English";
                lng_btn = false;
            }
            else
            {
                this.toggleButton4.Label = "עברית";
                lng_btn = true;
            }
        }

        private void editBox1_TextChanged(object sender, RibbonControlEventArgs e)
        {

        }

        private void editBox3_TextChanged(object sender, RibbonControlEventArgs e)
        {

        }

        private void toggleButton5_Click(object sender, RibbonControlEventArgs e)
        {
            string fclty_name = this.editBox2.Text;
            string dptm_name = this.editBox3.Text;
            string course_name = this.editBox1.Text;
            string year_name = this.editBox4.Text;
            string smstr_name = this.editBox5.Text;


            Globals.ThisAddIn.Application.ActivePresentation.Save();
            String Path1 = Globals.ThisAddIn.Application.ActivePresentation.Path + "\\" + Globals.ThisAddIn.Application.ActivePresentation.Name;
            String Path2 = Path.GetTempPath() + "\\" + Globals.ThisAddIn.Application.ActivePresentation.Name;
            Globals.ThisAddIn.Application.ActivePresentation.SaveAs(Path2);
            File.Delete(Path1);
            Globals.ThisAddIn.Application.ActivePresentation.SaveAs(Path1);
            UploadService us = new UploadService();
            us.uploadToDrive(Path2, 
                fclty_name +"\\"+ dptm_name+"\\"+ course_name+"\\"+ year_name+"\\"+ smstr_name);
 
        }

        private void editBox1_TextChanged_1(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
