using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArchitectureDecisionRecords
{
    public class InitializeRepositoryCommand
    {
        public int Execute(InitializeRepositoryCommandOptions options)
        {
            if(File.Exists(".adr-dir"))
            {
                Console.WriteLine("Repository already initialized. Please remove the .adr-dir file and run the command again to create a new repository configuration file.");
                return 1;
            }

            using(var writer = new StreamWriter(File.OpenWrite(".adr-dir")))
            {
                writer.WriteLine(options.Path);
            }

            Directory.CreateDirectory(options.Path);

            Console.WriteLine("Succesfully initialized a new ADR repository. Enjoy!");

            return 0;
        }
    }
}
