using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TerminalFileExplorer
{
    class FileSystemService
    {
        
        public string[] ScanForDirectory(string path)
        { 
            return Directory.GetDirectories(path); 
        }

        public string[] ScanForFiles(string path)
        {
            return Directory.GetFiles(path); 
        }

        public string GetNextDirectory(string dir)
        {
            return Path.GetFullPath(dir); 
        }

        public void OpenFile(string file)
        {
            try{
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = file,
                        UseShellExecute = true
                    }
                    
                };
                process.Start();
            }catch(Exception e){System.Console.WriteLine(e);}
        }
    }
}