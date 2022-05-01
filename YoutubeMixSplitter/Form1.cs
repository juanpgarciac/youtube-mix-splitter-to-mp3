using System.ComponentModel;

namespace YoutubeMixSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbMixSourceType.SelectedIndex = 0;
            if (Directory.Exists("tmp"))
            {
                Directory.Delete("tmp", true);
            }
            
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
            btnSplit.Enabled = false;
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            if (ckDeleteTemporal.Checked)
            {
                if (File.Exists(mp4file) && sourceURL != mp4file)
                    File.Delete(mp4file);
                if (File.Exists(mp3file) && sourceURL != mp3file)
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
            splitMp3(sender, e);
        }

        private void splitMp3(object sender, DoWorkEventArgs e)
        {
            Mp3FileHandler.SplitMp3File(songsList, mp3file, outputFolder);
        }
        private void btnSplit_Click(object sender, EventArgs e)
        {
            sourceURL = tbSourceURL.Text;
            if (String.IsNullOrEmpty(sourceURL))
            {
                MessageBox.Show(this,"The source URL should not be empty", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            pnOptions.Enabled = false; //Disable options
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }
            BackgroundWorker bw = new BackgroundWorker();
            //bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(freeGUI);

            switch (cbMixSourceType.SelectedItem.ToString())
            {
                case "Youtube Video Mix Link":
                    lbStatus.Text = "Downloading video and converting it to a mp4 file. Please wait patienly.";
                    bw.DoWork += new DoWorkEventHandler(downloadVideo);
                    bw.RunWorkerAsync();
                    break;
                case "MP4 Video File":
                    lbStatus.Text = "Converting mp4 file to mp3.";
                    mp4file = sourceURL;
                    mp3file = outputFolder + "\\" + Path.GetFileNameWithoutExtension(sourceURL)+".mp3";
                    bw.DoWork += new DoWorkEventHandler(convertMp4ToMp3);
                    bw.RunWorkerAsync();
                    break;
                case "MP3 File":
                    lbStatus.Text = "Splitting the mp3 file.";
                    mp3file = sourceURL;
                    bw.DoWork += new DoWorkEventHandler(splitMp3);
                    bw.RunWorkerAsync();
                    break;
                default:
                    pnOptions.Enabled = true; //Disable options
                    progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                    break;
            }
        }
        private Song[] songsList;
        private void button3_Click(object sender, EventArgs e)
        {
            btnSplit.Enabled = false;
            string songListText = tbSongList.Text;
            if (String.IsNullOrEmpty(songListText))
            {
                MessageBox.Show(this, "The song list should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] songsStrs = songListText.Split("\n");
            List<Song> songs = new List<Song>();
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
                    songsList = songs.ToArray(); 
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

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = "";
            string title = "";
            string extension = "";


            switch (cbMixSourceType.SelectedItem.ToString())
            {
                case "MP4 Video File":
                    filter = "MP4 Filetype|*.mp4";
                    title = "Select your Mp4 mix file";
                    extension = ".mp4";
                    break;

                case "MP3 File":
                    filter = "MP3 Filetype|*.mp3";
                    title = "Select your Mp3 mix file";
                    extension = ".mp3";
                    break;
            }
            openFileDialog1.Filter = filter;
            openFileDialog1.Title = title;
            openFileDialog1.ValidateNames = true;
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                {
                    tbSourceURL.Text = fileName;
                    MessageBox.Show("Done! Now you can set the cut points below (HH:mm:ss # Name of the song) then click the 'Split Mix button'", "Important Message");
                }
                else
                {
                    MessageBox.Show("There was an error with the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbMixSourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSourceURL.Text = "";
            lbInputFileURL.Text = !(cbMixSourceType.SelectedItem.ToString() == "Youtube Video Mix Link") ? "Input the file mix source: " : "Input the Youtube mix link source: ";            
            btSelectFile.Visible = !(cbMixSourceType.SelectedItem.ToString() == "Youtube Video Mix Link");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        outputFolder = fbd.SelectedPath;                        
                    }
                    else
                    {
                        MessageBox.Show("There was an error with the directory selection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        outputFolder = "tmp";
                    }
                }
            }
            tbOutputDirectory.Text = outputFolder;
        }
    }
}