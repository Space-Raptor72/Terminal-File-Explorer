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
    }
}