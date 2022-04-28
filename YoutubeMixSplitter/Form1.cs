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
                    
                    YoutubeVideoInfo youtubeVideoInfo = YoutubeVideo.Youtube2mp4(sourceURL);
                    mp4file = youtubeVideoInfo.videoFile;
                    mp3file = youtubeVideoInfo.videoName + ".mp3";
                    break;
                case "MP4 Video File": 

                    break;
                case "MP3 File":
                    break;
                default: 
                    break;
        }
    }
    }
}