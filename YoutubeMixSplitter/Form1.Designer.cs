namespace YoutubeMixSplitter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSourceURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMixSourceType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSongList = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.ckDeleteTemporal = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnOptions = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSourceURL
            // 
            this.tbSourceURL.Location = new System.Drawing.Point(27, 94);
            this.tbSourceURL.Name = "tbSourceURL";
            this.tbSourceURL.Size = new System.Drawing.Size(371, 23);
            this.tbSourceURL.TabIndex = 1;
            this.tbSourceURL.Text = "https://www.youtube.com/watch?v=m4wllxpGKew";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Mix source type:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Indicate mix file/link source: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input the song list (each item with format hh:mm:ss [song name]):";
            // 
            // cbMixSourceType
            // 
            this.cbMixSourceType.FormattingEnabled = true;
            this.cbMixSourceType.Items.AddRange(new object[] {
            "Youtube Video Mix Link",
            "MP4 Video File ",
            "MP3 File"});
            this.cbMixSourceType.Location = new System.Drawing.Point(27, 34);
            this.cbMixSourceType.Name = "cbMixSourceType";
            this.cbMixSourceType.Size = new System.Drawing.Size(371, 23);
            this.cbMixSourceType.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Select file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output directory:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(27, 376);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(371, 23);
            this.textBox2.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 376);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Select directory";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnSplit
            // 
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(139, 430);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(110, 23);
            this.btnSplit.TabIndex = 10;
            this.btnSplit.Text = "2. Split the mix";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(27, 28);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(224, 23);
            this.progressBar.TabIndex = 11;
            this.progressBar.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Progress:";
            // 
            // tbSongList
            // 
            this.tbSongList.Location = new System.Drawing.Point(25, 145);
            this.tbSongList.Multiline = true;
            this.tbSongList.Name = "tbSongList";
            this.tbSongList.Size = new System.Drawing.Size(485, 210);
            this.tbSongList.TabIndex = 13;
            this.tbSongList.Text = "00:00:00 number 1\r\n00:20:00 number 2\r\n25:45 number 2.5\r\n01:40:00 number 3\r\n300:00" +
    ":11 number 4";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(88, 10);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(48, 15);
            this.lbStatus.TabIndex = 14;
            this.lbStatus.Text = "Waiting";
            // 
            // ckDeleteTemporal
            // 
            this.ckDeleteTemporal.AutoSize = true;
            this.ckDeleteTemporal.Checked = true;
            this.ckDeleteTemporal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDeleteTemporal.Location = new System.Drawing.Point(27, 405);
            this.ckDeleteTemporal.Name = "ckDeleteTemporal";
            this.ckDeleteTemporal.Size = new System.Drawing.Size(222, 19);
            this.ckDeleteTemporal.TabIndex = 15;
            this.ckDeleteTemporal.Text = "Delete temporal files after conversion";
            this.ckDeleteTemporal.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 430);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "1. Check song list";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Location = new System.Drawing.Point(33, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 67);
            this.panel1.TabIndex = 17;
            // 
            // pnOptions
            // 
            this.pnOptions.Controls.Add(this.label1);
            this.pnOptions.Controls.Add(this.cbMixSourceType);
            this.pnOptions.Controls.Add(this.button3);
            this.pnOptions.Controls.Add(this.tbSourceURL);
            this.pnOptions.Controls.Add(this.ckDeleteTemporal);
            this.pnOptions.Controls.Add(this.label2);
            this.pnOptions.Controls.Add(this.tbSongList);
            this.pnOptions.Controls.Add(this.label3);
            this.pnOptions.Controls.Add(this.btnSplit);
            this.pnOptions.Controls.Add(this.button1);
            this.pnOptions.Controls.Add(this.button2);
            this.pnOptions.Controls.Add(this.label4);
            this.pnOptions.Controls.Add(this.textBox2);
            this.pnOptions.Location = new System.Drawing.Point(33, 12);
            this.pnOptions.Name = "pnOptions";
            this.pnOptions.Size = new System.Drawing.Size(537, 466);
            this.pnOptions.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 566);
            this.Controls.Add(this.pnOptions);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnOptions.ResumeLayout(false);
            this.pnOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox tbSourceURL;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbMixSourceType;
        private Button button1;
        private Label label4;
        private TextBox textBox2;
        private Button button2;
        private Button btnSplit;
        private ProgressBar progressBar1;
        private Label label5;
        private TextBox tbSongList;
        private Label label6;
        private CheckBox ckDeleteTemporal;
        private ProgressBar progressBar;
        private Label lbStatus;
        private Button button3;
        private Panel panel1;
        private Panel pnOptions;
    }
}