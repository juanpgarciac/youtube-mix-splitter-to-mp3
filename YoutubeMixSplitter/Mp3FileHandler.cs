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


        public static void SplitMp3File(Song[] songList, string sourceMp3File = "tmp\\tmp.mp3", string destinationPath = "tmp\\mix")
        {

            int splitLength = 480; // default seconds

            int secsOffset = 0;
            //int splitIndex = 0;
            int curSongIndex = 0;
            int maxSongs = songList.Length;
            Song curSong = songList[curSongIndex];//first song
            splitLength = curSong.duration();
            

            using (var reader = new Mp3FileReader(sourceMp3File))
            {
                FileStream writer = null;
                System.IO.Directory.CreateDirectory(destinationPath);//Crear ruta de destino


                Action createWriter = new Action(() => {
                    string newBaseNameForSplit = (curSongIndex+1)+" - "+curSong.Name;//listadoCanciones[actualSong].Numero + listadoCanciones[actualSong].Nombre;
                    string newFileName = Path.Combine(destinationPath, CommonFunctions.MakeValidFileName(newBaseNameForSplit) + ".mp3");
                    if (File.Exists(newFileName))
                    {
                        File.Delete(newFileName);
                    }
                    writer = File.Create(newFileName);

                    //AudioSplitOutput audioSplitOutput = new AudioSplitOutput();
                    //audioSplitOutput.FileName = newFileName;
                    //audioSplitOutput.AudioTimeOffsetTotalMilliseconds = ulong.Parse(reader.CurrentTime.TotalMilliseconds.ToString());
                    //outputAudioSplitList.Add(audioSplitOutput);
                });

                Mp3Frame frame;

                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    if ((int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                    {
                        curSongIndex++;
                        if (curSongIndex < maxSongs)
                        {
                            curSong = songList[curSongIndex];
                            writer?.Dispose();// time for a new file
                            createWriter();
                            secsOffset = (int)reader.CurrentTime.TotalSeconds;
                            splitLength = curSong.duration();
                        }
                    }
                    writer?.Write(frame.RawData, 0, frame.RawData.Length);
                }
                if (writer != null) writer.Dispose();
            }
            //return outputAudioSplitList;
        }





    }
}
