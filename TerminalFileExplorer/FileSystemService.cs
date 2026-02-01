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
    }
}