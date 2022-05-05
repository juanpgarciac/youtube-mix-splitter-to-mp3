using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YoutubeMixSplitter
{
    class SongTime
    {
        public int hours = 0;
        public int minutes = 0;
        public int seconds = 0;
    
        public SongTime(string timeString = "00:00:00" )
        {
            string[] timeArray = timeString.Split(":");
            (seconds,minutes,hours) = SongTime.deconstructTime(timeArray.Reverse().ToArray());
        }

        static private (int,int,int) deconstructTime(string[]  timeArray) //such thing exists ? 
        {
            return (int.Parse(timeArray[0]??="0"), 1 < timeArray.Length ? int.Parse(timeArray[1] ??= "0") : 0, 2 < timeArray.Length ? int.Parse(timeArray[2] ??= "0") : 0);
        }

        static public int songDuration(SongTime start, SongTime end)
        {
            int startSeconds = start.hours * 3600 + start.minutes * 60 + start.seconds;
            int endSeconds = end.hours * 3600 + end.minutes * 60 + end.seconds;
            return endSeconds - startSeconds;
        }

        public string theTime()
        {
            return fillZeroes(hours)+ ":" + fillZeroes(minutes) + ":" + fillZeroes(seconds);
        }

        static private string fillZeroes(int val)
        {
            if(val < 10)
            {
                return "0" + val;
            }
            return "" + val;
        }

    }
    internal class Song
    {
        private SongTime startTime;

        private SongTime endTime = null;

        private string name;

        private int number;

        private Song nextSong;

        public string Name { get => name; set => name = value; }

        public Song(string originalStr)
        {
            List<string> ostr = originalStr.Split(" ").ToList();

            Regex filter = new Regex("([0-9]+(:[0-9]+)+)");
            string _startTime = ostr.First();
            var match = filter.Match(_startTime);
            if (match.Success)
            {
                //MessageBox.Show(match.Value);
                ostr.RemoveAt(0);
                if (ostr[0].Equals("-"))
                {
                    ostr.RemoveAt(0);
                }
                this.Name = string.Join(" ",ostr).Trim().Replace("\r","").Replace("\n","");
                startTime = new SongTime(match.Value);
            }
            else
            {
                throw new Exception("Not valid format song line: " + originalStr);
            }
        }

        public void setNextSong(Song _song)
        {
            nextSong = _song;
            endTime = nextSong.startTime;
        }

        public int duration()
        {
            if (startTime == null || endTime == null) return 0;
            return SongTime.songDuration(startTime, endTime);
        }

        public string songStr()
        {
            return startTime.theTime() + " " + Name;
        }

    }
}
