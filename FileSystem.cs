using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Notepad
{
    public class FileSystem : INotifyPropertyChanged
    {
        private string currentDir = "";
        public string CurrentDir
        {
            get { return currentDir; }
            set { currentDir = value; OnPropertyChange(); }
        }

        public FileSystem() { CurrentDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        private bool HasCompiler()
        {
            const string extension = "exe";
            const string dir = @"C:\cygwin64\bin\";
            var myFiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                 .Where(s => extension.Contains(Path.GetExtension(s)));
            foreach (var file in myFiles)
            {
                if (file.Contains("g++.exe"))
                {
                    string gccPath = Path.GetFullPath(file);
                    SaveConfiguration(gccPath);
                    return true;
                }
            }
            return false;
        }
        private bool HasConfigurationFile()
        {
            var currentFileList = Directory.GetFiles(CurrentDir, "*.json", SearchOption.AllDirectories);
            foreach (var files in currentFileList)
            {
                if (files.Contains("SavedConfiguration.json")) { return true; }
            }
            return false;
        }
        private void SaveConfiguration(string path)
        {
            string json = JsonConvert.SerializeObject(path);
            using (StreamWriter file = File.CreateText(CurrentDir + "SavedConfiguration.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, json);
            }
        }
        private bool HasSavedCompilerLocation()
        {
            if (HasConfigurationFile())
            {
            }
            return false;
        }
        private void ReadConfiguration() { }
    }
}
