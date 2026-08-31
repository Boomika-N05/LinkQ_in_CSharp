using System.IO;
using System;
using System.Net;
namespace LinqProgramming
{
    public class FileHandling
    {
        public static string path = @"C:\Development\LinkQ_in_CSharp\File_Handling_code.txt"; // "@" is called a verbatim string -- It treat the "\" characters as normal characters // assigning the location at where the file should be placed/stored
        public static void FilesOperation() // when you have large files and want to write many lines one by one while the writer is open, use this kind of code
        {
            string str = "Hello";
            Console.WriteLine($"{str} From file handling");

            using (StreamWriter write = new StreamWriter(path,append: true)) //the second argument "true" enables append mode 
            {
                write.WriteLine($"{str} By using new stream path");   
            }

            using (StreamReader read = new StreamReader(path)) //"Stream(reader/writer)" --> process text line by line or character by character using a buffer, making them far more memory-efficient, used for large files
            {
                string? r;
                while((r = read.ReadLine()) != null)
                {
                    Console.WriteLine(r);
                }
            }

            
            if (File.Exists(path)) // running at first time means put this "!" b/c at first time the file not yet created, then at second time remove it 
            {
                using (StreamWriter sw = File.CreateText(path)) // "using" --> it tells, Use this resource temporarily, and automatically clean it up when finished // "streamwriter" --> is a built-in class, It is responsible for writing text to the file
                {
                    sw.WriteLine("From FilesOperation1");
                    sw.WriteLine("Hello");
                    sw.WriteLine("World");
                    sw.WriteLine("Programming");
                }

                using (StreamReader sr = File.OpenText(path)) // "StreamReader" is a built-in class used to read text from a file //this line says: Open this text file and give me a reader called "sr"
                {
                    string? s; // it used to hold oneline from a file at a time 
                    while((s = sr.ReadLine()) != null) //this line says --> Read one line, put it into s, and keep repeating as long as a line was successfully read
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }

        public static void FilesOperation2()
        {
            string content = "From FilesOperation2 ";
            Console.WriteLine(content);

            // File.WriteAllText(path,content); //this line will overwrite the content(remove the previous content of that file and then write the content which we have given in this) 

            File.AppendAllText(path,"Hello from Append all text operation");

            string readTxt = File.ReadAllText(path); //helps to read the file
            Console.WriteLine(readTxt); //printing the file which it is reading
        }
    }
}