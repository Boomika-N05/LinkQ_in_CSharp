using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Net.Security;
namespace LinqProgramming
{
    public class DirectoryFolder
    {
        public static void CreatingDirectory()
        {
            string FolderName = "Programming";
            if (Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName); //If any parent folders in the path don't exist, it automatically creates those as well, Ex:if we give like this ==> string path = @"C:\MyApp\Logs\2026";(it Creates 'MyApp', 'Logs', and '2026' if they don't exist yet)
                Console.WriteLine("Directory Folder created!");
            }
            else
            {
                Console.WriteLine("Directory not yet created");
            }

            string FilePath = Path.Combine(FolderName,"Coding.txt");

            File.WriteAllText(FilePath,"Hello From inside the folder");
            Console.WriteLine("File got created inside the folder");

            string readtxt = File.ReadAllText(FilePath);
            Console.WriteLine(readtxt);
            Console.WriteLine();
        }

        public static void DeletingDirectory()
        {
            string TempFolder = @"C:\App\TempFolder"; //this directory should be completely empty

            Directory.CreateDirectory(TempFolder);
            Console.WriteLine("Created temporary folder");

            Directory.Delete(TempFolder);
            Console.WriteLine("Deleted Temporary folder");
            Console.WriteLine();

            string FolderPath = @"C:\App\Temp\Logs";

            Directory.CreateDirectory(FolderPath);
            Console.WriteLine("Created a sample folder for deletion");

            
            if (Directory.Exists(FolderPath))
            {
                string FilPath = @"C:\App\Temp\Logs\code.txt"; // This entire string is a path, but the path points to the "Logs\code.txt" folder only, then if you "Directory.Delete()" it will delete that folder(Logs) and file(code.txt), everything inside that folder(Logs)
                File.WriteAllText(FilPath,"Hello From deleting Directory");
                Console.WriteLine("File got created successfully");
            }
            else
            {
                Console.WriteLine("Not yet created deleting files");
            }
            Directory.Delete(FolderPath,true); //Setting "recursive: true" forces C# to delete the target directory and all files/subdirectories inside it.
            Console.WriteLine("Folder's and file's is completely deleted");
            Console.WriteLine();
        }

        public static void MovingDirectory()
        {
            string currentPath = @"C:\App\OldCodex";
            string destinationpath = @"C:\App\NewCodex"; // This entire string is a path, but the path points to the "NewCodex" folder itself //The "destination path" must not already exist, or an exception will be thrown, so don't "CreateDirectory()" for "destinationpath" 

            Directory.CreateDirectory(currentPath);   
            Console.WriteLine("Created Current Directory");

            string filePath1 = Path.Combine(currentPath,"TxtFile.txt");
            using (StreamWriter s = File.CreateText(filePath1))
            {
                s.WriteLine("File created inside the current Directory");    
            }

            //Directory.Move(currentPath,destinationpath);  // Moves the entire 'OldCodex' directory into 'Coding\NewCodex'

            Console.WriteLine("OldCodex directory moved into the NewCodex directory successfully");
        }
    }
}