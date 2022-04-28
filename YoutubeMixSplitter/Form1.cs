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

        private void initializeVars()
        {

        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            string sourceURL = tbSourceURL.Text;
            if (String.IsNullOrEmpty(sourceURL))
            {
                MessageBox.Show(this,"The source URL should not be empty", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            switch (cbMixSourceType.SelectedItem.ToString())
            {
                case "Youtube Video Mix Link":
                    
                    YoutubeVideoInfo youtubeVideoInfo = YoutubeVideoHandler.YoutubeToMp4(sourceURL,outputFolder);
                    mp4file = youtubeVideoInfo.videoFile;
                    mp3file = outputFolder + "\\" + youtubeVideoInfo.videoName + ".mp3";
                    Mp4FileHandler.mp4ToMp3(mp4file, mp3file);

                    break;
                case "MP4 Video File":
                    mp3file = outputFolder + "\\" + Path.GetFileNameWithoutExtension(sourceURL);
                    Mp4FileHandler.mp4ToMp3(sourceURL, mp3file);
                    break;
                case "MP3 File":

                    break;
                default: 
                    break;
            }
            if (ckDeleteTemporal.Checked)
            {
                File.Delete(mp4file);
                File.Delete(mp3file);
            }








        }
    }
}