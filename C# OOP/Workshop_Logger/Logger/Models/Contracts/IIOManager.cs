using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IIOManager
    {
        string CurretDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExist();

        string GetCurrentPath();
    }
}
