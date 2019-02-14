using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;
using Hackaton_Recorder;
using System.Collections.Concurrent;

namespace PowerPointAddIn1
{
    public partial class ThisAddIn
    {
        // [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        //private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        bool finishedrecording;
        //            System.Windows.Forms.MessageBox.Show("Finished");

        Recorder2 rec;
        PowerPoint.CustomLayout customLayout;
        bool isSlideShow = false;
        int lastSlide=-1;
         ConcurrentQueue<speechToText> Task_Queue = new ConcurrentQueue<speechToText>();
        void Start_Record(string FileName)
        {
            rec = new Recorder2();
            rec.startRecording(Path.GetTempPath()  + FileName+".wav");
            /*
             
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            string command = "set bitspersample 16 channels 1 samplepersec 16000";
            mciSendString(command, "", 0, 0);
            mciSendString("record recsound", "", 0, 0);

            */


        }

        void End_Record(string FileName)
        {
            /*
            mciSendString("save recsound " + Path.GetTempPath() + "\\"+ FileName+".wav","", 0, 0);
            mciSendString("close recsound ", "", 0, 0);
            // Application.ActivePresentation.Slides[lastSlide].NotesPage.Shapes[2].TextFrame.TextRange.Text += "\n" + speechToText.ConvertSpeechToText(Path.GetTempPath() + "\\" + FileName + ".wav", "en-US");//he
            */
            rec.stopRecording();
            speechToText STT = new speechToText();
            STT.wavFilePath = ""+ Path.GetTempPath() + "\\" + FileName + ".wav";
            STT.Language = "en-US";
            if(Ribbon1.lng_btn)
                STT.Language = "he-IL";
            STT.lastSlide = lastSlide;
            STT.presntation = this;
            STT.TTL = 10;
            //STT.ConvertSpeechToText();
            Task_Queue.Enqueue(STT);
            //Thread thread1 = new Thread(new ThreadStart(STT.ConvertSpeechToText));
            //thread1.Start();
            //STT.ConvertSpeechToText();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void updateCommentSlide(string comment,int index)
        {
            try
            {
                Application.ActivePresentation.Slides[index].NotesPage.Shapes[2].TextFrame.TextRange.Text += "\n " + comment;//he
            }
            catch (System.Runtime.InteropServices.COMException){
                updateCommentSlide(comment, index);
            }

        }

        
        void Application_SlideShowNextSlideEventHandler(PowerPoint.SlideShowWindow Wn)
        {
            int i = Application.ActivePresentation.SlideShowWindow.View.Slide.SlideIndex;
            if (isSlideShow && lastSlide!=-1 && Ribbon1.pwr_btn)
            {
                End_Record("Slide-"+lastSlide);
                
                Start_Record("Slide-"+i);

            }
            lastSlide = i;

        }

        void Application_SlideShowBeginEventHandler(PowerPoint.SlideShowWindow Wn)
        {

            isSlideShow = true;
            int i = Application.ActivePresentation.SlideShowWindow.View.Slide.SlideIndex;
            if (Ribbon1.pwr_btn)
                Start_Record("Slide-" + i);
            //System.Windows.Forms.MessageBox.Show(isSlideShow.ToString());
        }

        void Application_SlideShowEndEventHandler(Presentation Pres)
        {
            isSlideShow = false;
            if (Ribbon1.pwr_btn)
            {
                End_Record("Slide-" + lastSlide);
                finishedrecording = true;
            }
            lastSlide = -1;

        }

        private void semaPhore()
        {
            while (true)
            {
                if (!Task_Queue.IsEmpty)
                {
                    speechToText SST;
                    Task_Queue.TryDequeue(out SST);
                    SST.ConvertSpeechToText();
                }
            }
            System.Windows.Forms.MessageBox.Show("Finish update the notes");
            finishedrecording = false;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            finishedrecording = false;
            Thread thread1 = new Thread(new ThreadStart(semaPhore));
            thread1.Start();
            //Globals.ThisAddIn.Application.SlideShowNextSlide += new PowerPoint.EApplication
            Globals.ThisAddIn.Application.SlideShowBegin += new PowerPoint.EApplication_SlideShowBeginEventHandler(Application_SlideShowBeginEventHandler);
            Globals.ThisAddIn.Application.SlideShowEnd += new PowerPoint.EApplication_SlideShowEndEventHandler(Application_SlideShowEndEventHandler);

            Globals.ThisAddIn.Application.SlideShowNextSlide += new PowerPoint.EApplication_SlideShowNextSlideEventHandler(Application_SlideShowNextSlideEventHandler);

           // Globals.ThisAddIn.Application.SlideSelectionChanged += new PowerPoint.EApplication_SlideSelectionChangedEventHandler(Application_SlideSelectionChanged);

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            //Globals.ThisAddIn.Application.SlideSelectionChanged -= Application_SlideSelectionChanged;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
