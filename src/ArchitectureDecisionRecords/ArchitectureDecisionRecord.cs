using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ArchitectureDecisionRecords
{
    public class ArchitectureDecisionRecord
    {
        public ArchitectureDecisionRecord(int id, string fileName, string title)
        {
            Id = id;
            Title = title;
            FileName = fileName;
        }

        public int Id { get; }
        public string Title { get; }
        public string FileName { get; }

        public static ArchitectureDecisionRecord FromFile(string filename)
        {
            Regex fileNamePattern = new Regex(@"^(?<id>\d+)-(?<name>\S+).md$");
            Regex titlePattern = new Regex(@"^#\s+(?<id>\d+)\.\s+(?<title>.+)$");

            var fileInfo = new FileInfo(filename);

            if (!fileNamePattern.IsMatch(fileInfo.Name))
            {
                throw new ArgumentException("Invalid filename for decision record. Please use <id>-<name>.md as the filename pattern.");
            }

            using (var reader = new StreamReader(File.OpenRead(filename)))
            {
                string line = reader.ReadLine();

                if (!titlePattern.IsMatch(line))
                {
                    throw new ArgumentException("File contains an invalid title. Please start the file with '# <id>. <title>");
                }

                var titleMatch = titlePattern.Match(line);
                var id = int.Parse(titleMatch.Groups["id"].Value);
                var title = titleMatch.Groups["title"].Value;

                return new ArchitectureDecisionRecord(id, filename, title);
            }
        }
    }
}
