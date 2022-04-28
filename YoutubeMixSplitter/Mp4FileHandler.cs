using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeMixSplitter
{
    internal class Mp4FileHandler
    {
    

        static public string mp4ToMp3(string videoFile = "tmp\\tmp.mp4", string mp3File = "tmp\\tmp.mp3")
        {
            if (File.Exists(mp3File)) return mp3File;
            if (!File.Exists(videoFile)) throw new FileNotFoundException();
            var inputFile = new MediaFile { Filename = videoFile };
            var outputFile = new MediaFile { Filename = mp3File };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);

            }
            return mp3File;
        }
    }
}
