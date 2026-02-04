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
           int page = selectedIndex / (Console.WindowHeight -1);
           int startingIndex = page * (Console.WindowHeight -1);
           int endingIndex = startingIndex + (Console.WindowHeight -1); 

           for(int i = startingIndex; i < endingIndex; i++)
            {
                if(i >= entireDirectory.Length){break;}
                if(i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    System.Console.Write($"> {Path.GetFileName(entireDirectory[i])}");
                    Console.ResetColor(); 
                    System.Console.WriteLine();
                }
                else
                {
                    System.Console.WriteLine($"{Path.GetFileName(entireDirectory[i])}");
                }
            }
        }


        public void MainLoop(ref string CurrentDirectory, FileSystemService File_Service_Object, CommandHandler commandHandler)
        {
          
            string[] dirs = File_Service_Object.ScanForDirectory(CurrentDirectory); 
            string[] files = File_Service_Object.ScanForFiles(CurrentDirectory); 

            int selectedIndex = 0; 
            
            while(true)
            {
                
                DisplayDirectory(CurrentDirectory, dirs, files, selectedIndex);
                try{
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if(key.Key == ConsoleKey.DownArrow){selectedIndex++;}
                    else if(key.Key == ConsoleKey.UpArrow){selectedIndex--;}
                    else if(key.Key == ConsoleKey.RightArrow){commandHandler.Right_Arrow(ref CurrentDirectory, ref dirs, ref files, selectedIndex); selectedIndex = 0;}
                    else if(key.Key == ConsoleKey.LeftArrow){commandHandler.Left_Arrow(ref CurrentDirectory, ref dirs, ref files); selectedIndex = 0;}
                }catch{continue;}



                if(selectedIndex < 0){selectedIndex = (dirs.Length + files.Length) - 1;}
                if(selectedIndex > (dirs.Length + files.Length) - 1){selectedIndex = 0;}

                ClearConsole();
            }
        }
    }
}