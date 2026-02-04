

using System.ComponentModel.Design;

namespace TerminalFileExplorer{ 
    class Program 
    {
        static void Main(string[] args)
        {
            string CurrentDirectory = "C:\\Program Files (x86)\\Steam";
            ExplorerUI Ui_Object = new ExplorerUI(); 
            FileSystemService File_Service_Object = new FileSystemService(); 
            CommandHandler commandHandler = new CommandHandler(File_Service_Object); 
            Ui_Object.MainLoop(ref CurrentDirectory, File_Service_Object, commandHandler); 
        }
    }
}