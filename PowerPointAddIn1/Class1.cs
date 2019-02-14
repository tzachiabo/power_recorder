using NAudio.Wave;
using System;
using System.Timers;
using System.Threading.Tasks;

namespace Hackaton_Recorder
{

    public class Recorder2
    {
        public WaveFileWriter waveFile = null;
        public WaveInEvent waveSource = null;
        /*
        public static void Main(string[] args)
        {
            Recorder2 rec2 = new Recorder2();
            rec2.startRecording();

            Timer timer = new Timer(5000);
            timer.Elapsed += async (sender, e) => await HandleTimer(rec2);
            timer.Start();
            Console.Write("Press any key to exit... ");
            Console.ReadKey();
        }
        
        private static Task HandleTimer(Recorder2 rec2)
        {
            Console.Write("Ending record");
            rec2.stopRecording(null,null);
            return null;
        }
        */



        public void startRecording(String path)
        {
            waveSource = new WaveInEvent();

            //waveSource2 = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(16000, 16, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new WaveFileWriter(path, waveSource.WaveFormat);

            waveSource.StartRecording();
        }

        public void stopRecording()
        {
            if (waveSource!=null)
                waveSource.StopRecording();
        }

        void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                //waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                //waveFile = null;
            }
        }
    }
}