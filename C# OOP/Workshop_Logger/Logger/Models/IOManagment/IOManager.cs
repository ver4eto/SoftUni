using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.IOManagment
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }
        public IOManager(string currentDirectory, string currentFile)
            :this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;

        }
        public string CurretDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurretDirectoryPath + this.currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurretDirectoryPath))
            {
                Directory.CreateDirectory(this.CurretDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
