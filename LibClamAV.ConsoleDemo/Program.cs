using System;
using System.IO;
using LibClamAV;

namespace LibClamAV.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string DatabaseDirectory;
            do
            {
                Console.Write("Please specify ClamAV Database directory : ");
                if (Directory.Exists(DatabaseDirectory = Console.ReadLine().Replace("\"", "")))
                    break;
            } while (!Directory.Exists(DatabaseDirectory));

            ClamEngine clam = new ClamEngine(DatabaseDirectory);

            string FileToScan;
            bool Quit = false;
            do
            {
                do
                {
                    Console.Write("\nEnter full path of file to scan or drag/drop to this window\nOr \"q\" to exit : ");
                    if (File.Exists(FileToScan = Console.ReadLine().Replace("\"", "")))
                        break;
                    if (Quit = FileToScan.ToLower() == "q")
                        continue;
                } while (!File.Exists(FileToScan) || !Quit);

                if(!Quit)
                {
                    string VirusName;
                    bool IsInfected = clam.IsFileInfected(FileToScan, out VirusName);

                    if(IsInfected)
                        Console.WriteLine("This file is infected! Virus : {0}\n", VirusName);
                    else
                        Console.WriteLine("This file is clean.\n");
                }
            } while (!Quit);

            clam.Dispose();
        }
    }
}
