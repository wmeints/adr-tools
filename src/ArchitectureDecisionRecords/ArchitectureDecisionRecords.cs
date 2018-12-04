using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArchitectureDecisionRecords
{
    public class ArchitectureDecisionRecords
    {
        public static List<ArchitectureDecisionRecord> List(string directory)
        {
            var recordFiles = Directory.GetFiles(directory, "*.md");

            return recordFiles
                .Select(x => ArchitectureDecisionRecord.FromFile(x))
                .ToList();
        }
    }
}
