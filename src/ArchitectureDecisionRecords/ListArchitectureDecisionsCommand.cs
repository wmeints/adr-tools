using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArchitectureDecisionRecords
{
    /// <summary>
    /// Lists all decisions in the repository.
    /// </summary>
    public class ListArchitectureDecisionsCommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="options">The options for the command.</param>
        /// <returns>Returns the exit code for the command.</returns>
        public int Execute(ListArchitectureDecisionsCommandOptions options)
        {
            if (!File.Exists(".adr-dir"))
            {
                Console.WriteLine("Error: The ADR repository is not initialized. Please run dotnet adr init to initialize the repository.");
                return 1;
            }

            var applicationSettings = ApplicationOptions.Read(".adr-dir");

            if (!Directory.Exists(applicationSettings.DecisionRecordFolder))
            {
                Directory.CreateDirectory(applicationSettings.DecisionRecordFolder);
            }

            var decisions = ArchitectureDecisionRecords.List(applicationSettings.DecisionRecordFolder);
            
            foreach (var decision in decisions)
            {
                Console.WriteLine($"{decision.Id}.\t{decision.Title}\t{decision.FileName}");
            }

            return 0;
        }
    }
}
