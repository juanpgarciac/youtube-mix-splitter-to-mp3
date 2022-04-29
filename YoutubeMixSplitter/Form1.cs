using System.ComponentModel;

namespace YoutubeMixSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbMixSourceType.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private string youtubeVideoLink = "";
        private string mp4file = "tmp.mp4";
        private string mp3file = "tmp.mp3";
        private string outputFolder = "tmp";
        private string sourceURL = "";

        private void freeGUI(object sender, RunWorkerCompletedEventArgs e)
        {
            lbStatus.Text = "Done!";
            this.Enabled = true;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            if (ckDeleteTemporal.Checked)
            {
                if (File.Exists(mp4file))
                    File.Delete(mp4file);
                if (File.Exists(mp3file))
                    File.Delete(mp3file);
            }
            MessageBox.Show("Done! Now you can rock the world", "Important Message");
            CommonFunctions.OpenFolder(outputFolder);
        }
        private void downloadVideo(object sender, DoWorkEventArgs e)
        {
            
            YoutubeVideoInfo youtubeVideoInfo = YoutubeVideoHandler.YoutubeToMp4(sourceURL, outputFolder);
            mp4file = youtubeVideoInfo.videoFile;
            mp3file = outputFolder + "\\" + youtubeVideoInfo.videoName + ".mp3";
            convertMp4ToMp3(sender, e);
        }

        private void convertMp4ToMp3(object sender, DoWorkEventArgs e)
        {
            Mp4FileHandler.mp4ToMp3(mp4file, mp3file);
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            sourceURL = tbSourceURL.Text;
            if (String.IsNullOrEmpty(sourceURL))
            {
                MessageBox.Show(this,"The source URL should not be empty", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            this.Enabled = false; //Disable ourselves
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;

            switch (cbMixSourceType.SelectedItem.ToString())
            {
                case "Youtube Video Mix Link":
                    lbStatus.Text = "Downloading video and converting it to a mp4 file";
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(downloadVideo);
                    //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(freeGUI);
                    bw.RunWorkerAsync();
                    break;
                case "MP4 Video File":
                    lbStatus.Text = "Converting mp4 file to mp3";
                    mp3file = outputFolder + "\\" + Path.GetFileNameWithoutExtension(sourceURL);
                    Mp4FileHandler.mp4ToMp3(sourceURL, mp3file);
                    break;
                case "MP3 File":

                    break;
                default: 
                    break;
            }









        }
    }
}