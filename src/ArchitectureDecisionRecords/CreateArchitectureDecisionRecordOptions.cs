using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectureDecisionRecords
{
    /// <summary>
    /// Options for creating a new architecture decision record
    /// </summary>
    [Verb("new", HelpText = "Create a new decision record")]
    public class CreateArchitectureDecisionRecordOptions
    {
        /// <summary>
        /// Gets or sets the title of the architecture decision record
        /// </summary>
        /// <value>A string indicating the title of the decision record</value>
        [Option('t', "title", HelpText = "The title of the decision record", Required = true)]
        public string Title { get; set; }
    }
}
