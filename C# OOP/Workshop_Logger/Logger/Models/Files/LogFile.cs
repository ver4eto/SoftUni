using Logger.Contracts;
using Logger.Enumerations;
using Logger.IOManagment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Files
{
    public class LogFile : IFile
    {
        private string currentPath;
        private IIOManager IOManager;
        private const string dataFormat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }
        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMassage = string.Format(format, dateTime.ToString(dataFormat, CultureInfo.InvariantCulture), level.ToString(), message);

            return formattedMassage;
        }
    }
}
