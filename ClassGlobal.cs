using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WPF_MVVM_Learn
{
    public static class ClassGlobal
    {
        public static T ToEnum<T>(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                return (T)Enum.Parse(typeof(T), "0", true);
            }
        }
        public static void BrowseFolderDirectory(ref string FolderDirectory)
        {
            FolderBrowserDialog FolderDialog = new FolderBrowserDialog();
            FolderDialog.ShowNewFolderButton = true;

            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                FolderDirectory = FolderDialog.SelectedPath;
            }
        }
        public static List<string> GetAllMediaFileNames(MediaType mediaType, string folder)
        {
            List<string> List = new List<string>();

            switch (mediaType)
            {
                case MediaType.Image:
                    {
                        var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                        .Where(s => 
                        s.EndsWith(".png") || 
                        s.EndsWith(".jpg") || 
                        s.EndsWith(".jpeg") || 
                        s.EndsWith(".bmp"));

                        foreach (string file in files)
                        {
                            List.Add(string.Format("file:///{0}", file));
                        }
                        break;
                    }
                case MediaType.Video:
                    {
                        var files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                        .Where(s => 
                        s.EndsWith(".mp4") || 
                        s.EndsWith(".mkv"));

                        foreach (string file in files)
                        {
                            List.Add(string.Format("file:///{0}", file));
                        }
                        break;
                    }
                default:
                    break;
            }
            return List;
        }
        public static string GetAppsDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        public static void PlayVideos(MediaElement CT, string VideoName)
        {
            CT.Position = TimeSpan.Zero;
            CT.Source = new Uri(VideoName);
            CT.Play();
        }
        public static void StopVideos(MediaElement CT)
        {
            CT.Stop();
        }
    }

    #region Enums
    public enum PageNumber
    {
        Unknown,
        Page_1,
        Page_2,
        Page_3
    }
    public enum MediaType
    {
        Unknown,
        Video,
        Image
    }
    public enum MediaStatus
    {
        Playing,
        Stopped
    }
    public enum MessageBoxType
    {
        Unknown,
        Single_Button,
        Multi_Button,
        Multi_Button_With_Timeout
    }
    public enum Decisions
    {
        No,
        Yes
    }
    #endregion
}