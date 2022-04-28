using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace YoutubeMixSplitter
{
    public class YoutubeVideoInfo
    {
        public string videoFile = "";
        public string videoName = "";
        public YoutubeVideoInfo(string _videoFile, string _videoName) {
            this.videoFile = _videoFile;
            this.videoName = _videoName; 
        }
    }
    internal class YoutubeVideoHandler
    {

        static public YoutubeVideoInfo YoutubeToMp4(string link, string outputFolder = "tmp")
        {
            YouTubeVideo video = YouTube.Default.GetVideo(link);
            
            string videoTitle = video.Title.Replace(" - YouTube", "");

            string videoName = CommonFunctions.MakeValidFileName(videoTitle);

            if(!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string videoFile = outputFolder +"\\"+ videoName + video.FileExtension;

            if(!File.Exists(videoFile))
                File.WriteAllBytes(videoFile, video.GetBytes());

            return new YoutubeVideoInfo(videoFile,videoName);
        }
    }


}
