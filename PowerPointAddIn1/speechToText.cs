using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;

namespace PowerPointAddIn1
{
    class speechToText
    {
        string python = @"C:\Users\Zahi\AppData\Local\Programs\Python\Python36\python.exe";

        // python app to call 
        string myPythonApp = "C:\\Work\\PowerPointAddIn1\\PowerPointAddIn1\\voice.py";

        string JsonPath = "C:\\Work\\PowerPointAddIn1\\PowerPointAddIn1\\hackBgu-6827d92f3980.json";
        public int TTL;
        public string wavFilePath;
        public string Language;
        public int lastSlide;
        public ThisAddIn presntation;

        public void ConvertSpeechToText()
        {

            // full path of python interpreter 
             

            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.CreateNoWindow = true;

            // start python app with 3 arguments  
            // 1st arguments is pointer to itself,  
            // 2nd and 3rd are actual arguments we want to send 
            myProcessStartInfo.Arguments = myPythonApp +" "+ wavFilePath + " " + Language + " " + JsonPath;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start the process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            // in order to avoid deadlock we will read output first 
            // and then wait for process terminate: 


            /*if you need to read multiple lines, you might use: 
                string myString = myStreamReader.ReadToEnd() */
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();

            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            if(myString == null)
                 myString = myStreamReader.ReadLine();
            myProcess.Close();

            if (myString != null)
                presntation.updateCommentSlide(myString, lastSlide);
            else if (TTL>0)
            {
                TTL--;
                ConvertSpeechToText();
            }
        }
    }
}
