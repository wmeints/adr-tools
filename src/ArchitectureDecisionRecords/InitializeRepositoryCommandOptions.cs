using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectureDecisionRecords
{
    /// <summary>
    /// Options for the initialization command.
    /// </summary>
    [Verb("init", HelpText = "Initializes a new ADR repository.")]
    public class InitializeRepositoryCommandOptions
    {
        /// <summary>
        /// Gets or sets the path where the decision records should be stored.
        /// </summary>
        [Option('p', "path", HelpText = "Output path to initialize the repository.", Default = "decisions", Required = false)]
        public string Path { get; set; }
    }
}
