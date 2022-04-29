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
            pnOptions.Enabled = true;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
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
            pnOptions.Enabled = false; //Disable options
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
        private List<Song> songs;
        private void button3_Click(object sender, EventArgs e)
        {
            btnSplit.Enabled = false;
            string songList = tbSongList.Text;
            if (String.IsNullOrEmpty(songList))
            {
                MessageBox.Show(this, "The song list should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] songsStrs = songList.Split("\n");
            songs = new List<Song>();
            Song curSong = null;
            Song prevSong = null;
            try
            {
                for (int i = 0; i < songsStrs.Length; i++)
                {
                    curSong = new Song(songsStrs[i]);
                    if (curSong != null)
                    {
                        if (prevSong != null)
                        {
                            prevSong.setNextSong(curSong);
                        }
                        prevSong = curSong;
                        songs.Add(curSong);
                    }
                }
                lbStatus.Text = songs.Count + " songs formatted in the list";
                if(songs.Count > 0)
                {
                    btnSplit.Enabled = true;
                    MessageBox.Show(this, "The song list format seems nice, now press the Split button to start the process, then wait (patienly)");
                }
                else
                {
                    MessageBox.Show(this, "No songs list detected in the list, you add any?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                
            }
            catch (Exception err)
            {
                
                MessageBox.Show(this, "The was an error, please check the song's list format:\n"+err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbStatus.Text ="The was an error, please check the song's list format";
            }

            
        }
    }
}