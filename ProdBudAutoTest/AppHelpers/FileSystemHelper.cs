using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Prodat.AppHelpers
{
    public class FileSystemHelper
    {
        private static readonly FileSystemHelper instance = new FileSystemHelper();

        static FileSystemHelper() { }

        private FileSystemHelper() { }

        public static FileSystemHelper Instance
        {
            get
            {
                return instance;
            }
        }
        public async Task<string> ReadDataAsync(string fileName)
        {
            try
            {
                var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), fileName);

                if (backingFile == null || !File.Exists(backingFile))
                {
                    return null;
                }
                string FileData = string.Empty;
                using (var reader = new StreamReader(backingFile, true))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        FileData = line;
                    }
                }

                return FileData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SaveDataAsync(string fileName, string Data)
        {
            try
            {
                var backingFile = Path.Combine(System.Environment.
                    GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), fileName);
                using (var writer = File.CreateText(backingFile))
                {
                    await writer.WriteLineAsync(Data);
                }
            }
            catch (Exception ex)
            {
            }

        }

        public bool IsFileExists(string fileName)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), fileName);

            if (backingFile == null || !File.Exists(backingFile))
            {
                return false;
            }
            return true;
        }
        public void DeleteFile(string fileName)
        {
            if (IsFileExists(fileName))
            {
                var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), fileName);

                File.Delete(backingFile);
            }
        }
    }
}
