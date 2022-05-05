using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace YoutubeMixSplitter
{
    internal class Mp3FileHandler
    {

        static private void setID3MetaInfo(string filename, uint track, string title)
        {
            // change track & title in the file with Id3 info
            var tfile = TagLib.File.Create(filename);
            tfile.Tag.Track = track;
            tfile.Tag.Title = title;
            tfile.Save();

        }


        public static void SplitMp3File(Song[] songList, string sourceMp3File = "tmp\\tmp.mp3", string destinationPath = "tmp")
        {

            int secsOffset = 0;
            uint curSongIndex = 0;
            int maxSongs = songList.Length;
            int pad = maxSongs < 100 ? 2 : 3; //assuming there is no mix with more than 999 songs. 

            Song curSong = songList[curSongIndex];//first song
            int splitLength = curSong.duration();
            destinationPath = Path.Combine(destinationPath,Path.GetFileNameWithoutExtension(sourceMp3File));

            using (var reader = new Mp3FileReader(sourceMp3File))
            {
                FileStream writer = null;
                System.IO.Directory.CreateDirectory(destinationPath);//destination route
                Mp3Frame frame;
                uint trackNumber = 0;
                string newFileName = "";
                string title = "";
                Action createWriter = new Action(() => {
                    trackNumber = (curSongIndex + 1);
                    title = curSong.Name;
                    string newBaseNameForSplit = (curSongIndex + 1).ToString().PadLeft(pad, '0') + " - " + curSong.Name;
                    newFileName = Path.Combine(destinationPath, CommonFunctions.MakeValidFileName(newBaseNameForSplit) + ".mp3");
                    if (File.Exists(newFileName))
                    {
                        File.Delete(newFileName);
                    }
                    writer = File.Create(newFileName);
                });

               

                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) 
                        createWriter();

                    if ((int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                    {
                        curSongIndex++;
                        if (curSongIndex < maxSongs)
                        {
                            curSong = songList[curSongIndex];
                            writer?.Dispose();// time for a new file
                            setID3MetaInfo(newFileName, trackNumber, title);
                            createWriter();
                            secsOffset = (int)reader.CurrentTime.TotalSeconds;
                            splitLength = curSong.duration();
                        }
                    }
                    writer?.Write(frame.RawData, 0, frame.RawData.Length);
                }
                if (writer != null)
                {
                    writer.Dispose();
                    setID3MetaInfo(newFileName, trackNumber, title);

                } 
                    
            }
        }
    }
}
