using System.Security.Cryptography.X509Certificates;

namespace TerminalFileExplorer
{
    class ExplorerUI
    {
        public ExplorerUI(){}

        public void DisplayDirectory(string path, string[] dirs, string[] files, int selectedIndex)
        {
            System.Console.WriteLine($"Current directory: {path}");
            for(int x = 0; x < dirs.Length; x++)
            {
                if(selectedIndex < dirs.Length && x == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    System.Console.Write($"> {Path.GetFileName(dirs[x])}");
                    Console.ResetColor();
                    System.Console.WriteLine();
                }
                else
                {
                    System.Console.WriteLine($"> {Path.GetFileName(dirs[x])}");
                }
            }
            
            for(int x = 0; x < files.Length; x++)
            {
                if(selectedIndex >= dirs.Length && x == (selectedIndex - dirs.Length))
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                     System.Console.Write($"{Path.GetFileName(files[x])}");
                    Console.ResetColor();
                    System.Console.WriteLine();
                }
                else{System.Console.WriteLine($"{Path.GetFileName(files[x])}");}
                
            }
        }
    }
}