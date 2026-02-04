using System.Security.Cryptography.X509Certificates;

namespace TerminalFileExplorer
{
    class ExplorerUI
    {
        public void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();  
        }

         public void DisplayDirectory(string path, string[] dirs, string[] files, int selectedIndex)
        { 

            string[] entireDirectory = dirs.Concat(files).ToArray();
            int chunks = (int)Math.Ceiling(((double)entireDirectory.Length  / (double)Console.WindowHeight)); 
            
            int startingIndex = 0; 
            for(int x = 1; x <= chunks; x++)
            {
                
                if(selectedIndex < (Console.WindowHeight * x) - 1)
                {
                    if(x == 1){break;}
                    startingIndex = ((x - 1) * Console.WindowHeight) - 1;
                    break;
                }
            }
         
            for(int i = startingIndex; i < (startingIndex + (Console.WindowHeight)) - 1; i++)
            {
                if(i == entireDirectory.Length){break;}
                if(i == selectedIndex)
                {
                     Console.BackgroundColor = ConsoleColor.Cyan;
                     System.Console.Write($"> {Path.GetFileName(entireDirectory[i])}, {i}");
                     Console.ResetColor();
                     System.Console.WriteLine();
                }
                else
                {
                    System.Console.WriteLine($"{Path.GetFileName(entireDirectory[i])}, {i}");
                }
            }
          
        }

        public void MainLoop(ref string CurrentDirectory, FileSystemService File_Service_Object)
        {
          
            string[] dirs = File_Service_Object.ScanForDirectory(CurrentDirectory); 
            string[] files = File_Service_Object.ScanForFiles(CurrentDirectory); 

            int selectedIndex = 0; 
            
            while(true)
            {
                
                DisplayDirectory(CurrentDirectory, dirs, files, selectedIndex);

                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.DownArrow){selectedIndex++;}
                else if(key.Key == ConsoleKey.UpArrow){selectedIndex--;}
                else if(key.Key == ConsoleKey.RightArrow)
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


                if(selectedIndex < 0){selectedIndex = (dirs.Length + files.Length) - 1;}
                if(selectedIndex > (dirs.Length + files.Length) - 1){selectedIndex = 0;}

                ClearConsole();
            }
        }
    }
}