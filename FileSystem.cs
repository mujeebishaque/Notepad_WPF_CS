using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Notepad
{
    public class FileSystem : INotifyPropertyChanged
    {
        private string CurrentDirectory;
        private const string defaultCompilerName = "g++.exe";
        private string CompilerPath;
        private const string ConfigurationFileName = "configuration.txt";
        public FileSystem() { CurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); }

        public void SaveAndRun()
        {
            var mainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow).richtextbox;
            var randomNumber = new Random();
            int randomFileName = randomNumber.Next(12, 2000);
            string filePath = CurrentDirectory + @"\" + randomFileName + ".cpp";
            string allRichText = mainWindow.Text;

            if (File.Exists(filePath))
            {
                int anotherRandomName = randomNumber.Next(133, 999);
                filePath = CurrentDirectory + @"\" + anotherRandomName + ".cpp";
                File.WriteAllText(filePath, allRichText);
            }
            File.WriteAllText(filePath, allRichText);
            FileSystemInfo infoGrabber = new FileInfo(filePath);
            string fileName = infoGrabber.Name;
            RunProgram(fileName);
        }
        public bool HasCompiler()
        {
            const string defaultDirectory = @"C:\cygwin64\bin";
            var files = Directory.GetFiles(defaultDirectory, "*.exe", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var info = new FileInfo(file);
                if (info.Name == defaultCompilerName)
                {
                    CompilerPath = info.FullName;
                    return true;
                }
            }
            return false;
        }
        private void Configurations()
        {
            var fileInfo = new FileInfo(ConfigurationFileName);
            // if more than 5 chars are there, path is already given
            if (File.Exists(ConfigurationFileName) && fileInfo.Length > 5) { return; }
            if (File.Exists(ConfigurationFileName) && fileInfo.Length == 0)
            {
                //write compiler path to current dir
                File.WriteAllText(CurrentDirectory + "\\" + ConfigurationFileName, CompilerPath);
            }
        }
        public void RunProgram(string fileName)
        {
            string alteredName = fileName.Substring(0, fileName.Length - 4);
            // g++ -o helloworld helloworld.cpp --std=c++14
            const string flag = "--std=c++14";
            string cmdCommand = "g++ -o " + alteredName + " " + fileName + " " + flag;
            string runCommand = "./" + alteredName + ";" + "pause;";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.Arguments = cmdCommand;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();

            Process.Start("powershell", runCommand);

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}
