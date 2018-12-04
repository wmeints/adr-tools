using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArchitectureDecisionRecords
{
    public class ApplicationOptions
    {
        public ApplicationOptions(string decisiionRecordFolder)
        {
            DecisionRecordFolder = decisiionRecordFolder;
        }

        public string DecisionRecordFolder { get; }

        public static ApplicationOptions Read(string filename)
        {
            using (var reader = new StreamReader(File.OpenRead(filename)))
            {
                var decisionRecordFolder = reader.ReadLine();
                return new ApplicationOptions(decisionRecordFolder);
            }
        }
    }
}
