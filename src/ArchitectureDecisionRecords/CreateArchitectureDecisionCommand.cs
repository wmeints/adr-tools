using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchitectureDecisionRecords
{
    public class CreateArchitectureDecisionCommand
    {
        public int Execute(CreateArchitectureDecisionRecordOptions options)
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

            var records = ArchitectureDecisionRecords.List(applicationSettings.DecisionRecordFolder);
            var recordId = 1;

            if (records.Any())
            {
                recordId = records.Select(x => x.Id).Max() + 1;
            }

            var filename = FileNameFromTitle(recordId, options.Title);

            using (var writer = new StreamWriter(File.OpenWrite(Path.Combine(applicationSettings.DecisionRecordFolder, filename))))
            {
                writer.WriteLine($"# {recordId}. {options.Title}");
                writer.WriteLine();
                writer.WriteLine($"Date: {DateTime.Now.ToShortDateString()}");
                writer.WriteLine();
                writer.WriteLine("## Status");
                writer.WriteLine();
                writer.WriteLine("Concept");
                writer.WriteLine();
                writer.WriteLine("## Context");
                writer.WriteLine();
                writer.WriteLine("TODO: Describe the context of the decision.");
                writer.WriteLine();
                writer.WriteLine("## Decision");
                writer.WriteLine();
                writer.WriteLine("The change that we're proposing or have agreed to implement.");
                writer.WriteLine();
                writer.WriteLine("## Consequences");
                writer.WriteLine();
                writer.WriteLine("TODO: Describe what becomes easier, any new risks and things that become harder because of the decision.");
            }

            Console.WriteLine($"Created new record with title '{options.Title}'");

            return 0;
        }

        private string FileNameFromTitle(int id, string title)
        {
            string slug = title.ToLower();
            slug = new Regex(@"\s+").Replace(slug, "-");

            var filename = string.Format("{0:0000}-{1}.md", id, slug);

            return filename;
        }
    }
}
