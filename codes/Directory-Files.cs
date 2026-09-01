using System;
namespace LinqProgramming
{
    class DirectoryFiles
    {
        public static void LogDataFiles()
        {
            string mainFolder = @"C:\Development\MyCApp\Logs";
        
            Directory.CreateDirectory(mainFolder);

            File.WriteAllText(Path.Combine(mainFolder, "app.txt"),
            "App log"
            );

            File.WriteAllText(Path.Combine(mainFolder, "error.txt"),
            "Error log"
            );

            string ProgramFolder = Path.Combine(mainFolder, "Program");
            Directory.CreateDirectory(ProgramFolder);

            File.WriteAllText(Path.Combine(ProgramFolder, "Prog.txt"),
            "Program log"
            );

            File.WriteAllText(Path.Combine(ProgramFolder, "data.csv"),
            "Name,Age\nAlice,25"
            );

            string HelloFolder = Path.Combine(mainFolder, "Hello");
            Directory.CreateDirectory(HelloFolder);

            File.WriteAllText(Path.Combine(HelloFolder, "sample.txt"),
            "sample log"
            );

            File.WriteAllText(Path.Combine(HelloFolder, "image.png"),
            "a placeholder text file"
            );
            Console.WriteLine("Folders and files are created successfully.");

            string[] getAllFiles = Directory.GetFiles(mainFolder);// you will get all the path's of that file's in that directory
            foreach(string pathfile in getAllFiles)
            {
                Console.WriteLine(pathfile);
            }

            Console.WriteLine();

            string[] getTxtFiles = Directory.GetFiles(mainFolder, "*.txt", SearchOption.AllDirectories); // you will get only the text files from all the subdirectories inside the directory
            Console.WriteLine("Path of the Text files only: ");
            foreach(string txtfiles in getTxtFiles)
            {
                Console.WriteLine(txtfiles);
            }

            Console.WriteLine();
            string[] getdirectory = Directory.GetDirectories(mainFolder);
            Console.WriteLine("Path of the Diorectories: ");
            foreach(string dir in getdirectory)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine();
            string[] getBothDirFil = Directory.GetFileSystemEntries(mainFolder);
            Console.WriteLine("Path of the both files and directories: ");
            foreach(string bth in getBothDirFil)
            {
                Console.WriteLine(bth);
            }

            Console.WriteLine();
            string[] getdrives = Directory.GetLogicalDrives();
            Console.WriteLine("Drive name where the directory get saved: ");
            foreach(string dr in getdrives)
            {
                Console.WriteLine(dr);
            }

        }
    }
}