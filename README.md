# youtube-mix-to-mp3-splitter
Desktop application for Windows OS, made with C# that splits a mix (from youtube link, mp4 or mp3 file) to several mp3 audio tracks. 

Download application:


Instructions:  

1) Select the Mix source (youtube link, mp4 or mp3 file).
2) Input the link or file path (depending 1st step).
3) Input the song list cut points with the following format for each line: HH:mm:ss song's title. Generally, this is on the Youtube video description or in the comments, you can copy & paste it. 
4) Select the output directory: where you want the mp3 files will be created.
5) Press the "Check song list" button. If everything goes well: 
6) Press the "Split the mix" button. If you selected the youtube link in the 1st step, consider it could take some time to download the video depending on your internet connection, music mixes are generally big files with hours of music. 

Main window:
![image](https://user-images.githubusercontent.com/6114482/166984232-60ea2ec9-f1f6-4e2b-92fb-cb9fb3f91631.png)

Temporal files (mp4 video from youtube, and mp3 converted from the mp4)
![image](https://user-images.githubusercontent.com/6114482/166985150-343574e4-f0b1-4d8e-8163-2822a0d6254f.png)

Mix splitted into several mp3 files (with track number): 
![image](https://user-images.githubusercontent.com/6114482/166987344-563384ae-c8b2-4532-8fb1-5ca2a3063c18.png)


Note: 
* There is a checkbox indicating your preference about deleting the temporary files that are created in the process (mp4 & mp3 files).
* Mp3 files are also updated with ID3 metadata info (track number and title). 
