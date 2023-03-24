using System;
using System.IO;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 arguments: From, To, Type
            if (checkExistPath(args[0], args[1]))
            {
                try
                {
                    Console.WriteLine("[START AT "+DateTime.Now.ToString()+"]");
                    Console.WriteLine("Total files copied: "+CopyFilesRecursively(args[0], args[1], args[2]));
                    Console.WriteLine("[FINISH AT " + DateTime.Now.ToString() + "]");
                }
                catch(Exception es)
                {
                    Console.WriteLine("Error getting files: "+es.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid paths");
            }
        }

        private static bool checkExistPath(string from,string to)
        {
            bool isValid = false;
            if (Directory.Exists(from) && Directory.Exists(to))
                isValid = true;
            return isValid;
        }

        private static int CopyFilesRecursively(string sourcePath, string targetPath,string type)
        {
            int totalFiles = 0;
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*."+type, SearchOption.AllDirectories))
            {
                FileInfo info = new FileInfo(newPath);
                if (DateTime.Today.DayOfYear == info.CreationTime.DayOfYear)
                {
                    File.Copy(newPath, targetPath + "\\" + Path.GetFileName(newPath), true);
                    Console.WriteLine(++totalFiles);
                }
            }
            return totalFiles;
        }
    }
}
