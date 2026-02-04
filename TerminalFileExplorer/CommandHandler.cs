using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;

namespace TerminalFileExplorer
{
    class CommandHandler
    {
        FileSystemService File_Service_Object; 
        public CommandHandler(FileSystemService File_Service_Object)
        {
            this.File_Service_Object = File_Service_Object;
        }

        public void Right_Arrow(ref string CurrentDirectory, ref string[] dirs, ref string[] files, int selectedIndex)
        {
            if(selectedIndex < dirs.Length)
            {
                CurrentDirectory = File_Service_Object.GetNextDirectory(dirs[selectedIndex]);
                dirs = File_Service_Object.ScanForDirectory(CurrentDirectory);
                files = File_Service_Object.ScanForFiles(CurrentDirectory);
                selectedIndex = 0;  
            }
            else
            {
                File_Service_Object.OpenFile(Path.GetFullPath(files[(selectedIndex - dirs.Length)])); 
            }
        }
    }
}