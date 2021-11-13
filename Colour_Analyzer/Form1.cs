using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Colour_Analyzer
{
    public partial class Form1 : Form
    {
        int fileCount;       // number of threads running
        int mThreadFinished;    // number of threads finished executing
        public delegate void delUpdateOutput(string res);   // Update the textbox output 
        Thread th;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  // create open file dialog instance

            ofd.Filter = "Image File|*.JPG|*.PNG|"; // filter image that is allowed
            ofd.Multiselect = true; // enable multiselect file

            // run code when pressed okay
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                outputInfo.Text += $"Starting...{System.Environment.NewLine}";  // display output that the thread is "Starting..."
                fileCount = ofd.FileNames.Length;    // initialize the number of files selected
                mThreadFinished = 0;    // initialize to 0, the number of thread that is finish

                // loop each file that is selected
                foreach (String file in ofd.FileNames)
                {
                    try
                    {
                        // create a new parameterized thread instance that analyze the image rgb color
                        th = new Thread(new ParameterizedThreadStart(AnalyzeImage));
                        // start the thread with passed parameter file
                        th.Start(file);
                    }
                    // display errors in output
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.Message);
                    }
                }
            }
        }

        /**
         * Calculate the image rgb color by percentage
         * @param   {object}    file    The object file path
         */
        private void AnalyzeImage(object file)
        {
            string res; // output results
            Bitmap img = new Bitmap(file.ToString());   // create instance of bitmap of file image
            Color c;    // image file color
            double
             rgbTotal,       // total RGB
             red = 0,        // total red percentage of image
             green = 0,      // total green percentage of image
             blue = 0;       // total blue percentage of image

            // loop over the image by pixels
            for (int y = 0; y < img.Height; y++)
                for (int x = 0; x < img.Width; x++)
                {
                    c = img.GetPixel(x, y); // get the rgb color of pixel position x,y
                    red += c.R;     // get red
                    green += c.G;   // get green
                    blue += c.B;    // get blue
                }

            // set the total rgb
            rgbTotal = (red + green + blue) / 100;

            red /= rgbTotal;    // calculate red percentage
            green /= rgbTotal;  // calculate green percentage
            blue /= rgbTotal;   // calculate blue percentage
                
            // set the results of image rgb
            res = $"(R:{red:F1}%, G:{green:F1}%, B:{blue:F1}%) : {file}{System.Environment.NewLine}";

            try
            {
                // update the output textbox with the results
                this.Invoke(new delUpdateOutput(updateFileOutput), res);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        /**
         *  Update the output textbox text
         *  @param  {string}     res     The results of the analyzed image.
         */
        public void updateFileOutput(string res)
        {
            mThreadFinished++;      // thread finished increment by 1
            outputInfo.Text += res; // set the output textbox text

            // if threadfinish is equal to the selected files means all thread are done, set output text to "Done...".
            if (mThreadFinished == fileCount)   
                outputInfo.Text += $"Done...{System.Environment.NewLine}";
        }
    }
}
