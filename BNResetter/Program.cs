using System;
using System.IO;
using System.Linq;

namespace BNResetter
{
    class Program
    {
        private const string ProjectsPath = @"C:\TC\systemprofile\.BuildServer\config\projects";

        static void Main()
        {
            try
            {
                var files = Directory.GetFiles(ProjectsPath, "*buildNumbers.properties", SearchOption.AllDirectories);

                Console.WriteLine($"Found {files.Length} files:");

                foreach (var file in files)
                {
                    Console.WriteLine($"Resetting build number for {Path.GetFileName(file)}");
                    var text = File.ReadAllLines(file);

                    var newText = text
                        .Select(line => line.Contains("next.build=") ? "next.build=1" : line)
                        .ToArray();

                    File.WriteAllLines(file, newText);
                }

                Console.WriteLine("=======================");
                Console.WriteLine("Done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
