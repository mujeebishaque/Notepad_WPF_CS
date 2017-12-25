using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string CompilerPath { get; set; }
        private string ConfigurationFilePath { get; set; }
        private const string ConfigurationFileName = "SavedConfigration.json";
        private bool HasSavedCompilerLocation = false;
        private const string defaultCompilerName = "g++.exe";
        public FileSystem()
        {
            CurrentDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }


        private bool HasCompiler()
        {
            const string extension = "exe";
            const string dir = @"C:\cygwin64\bin\";
            var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                 .Where(s => extension.Contains(Path.GetExtension(s)));
            foreach (var file in files)
            {
                if (file == defaultCompilerName)
                {
                    string gccPath = Path.GetFullPath(file);
                    CompilerPath = gccPath;
                    SaveConfiguration();
                    return true;
                }
            }
            return false;
        }
        private bool HasConfigurationFile()
        {
            var currentFileList = Directory.GetFiles(CurrentDir, "*.json", SearchOption.AllDirectories);
            foreach (var file in currentFileList)
            {
                if (file == ConfigurationFileName)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.Length > 0)
                    {
                        ConfigurationFilePath = Path.GetFullPath(file);
                        HasSavedCompilerLocation = true;
                    }
                    return true;
                }
            }
            return false;
        }
        private void SaveConfiguration()
        {
            if (HasCompiler())
            {
                string json = JsonConvert.SerializeObject(CompilerPath);
                using (StreamWriter file = File.CreateText(CurrentDir + "/" + ConfigurationFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, json);
                }
            }
        }

        private void ReadConfiguration()
        {
            if (HasSavedCompilerLocation && HasCompiler())
            {
                using (var file = File.OpenText(ConfigurationFilePath))
                using (var reader = new JsonTextReader(file))
                {
                    JObject readDataFromJson = (JObject)JToken.ReadFrom(reader);
                    string alreadySavedFilePath = (string)readDataFromJson;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}
