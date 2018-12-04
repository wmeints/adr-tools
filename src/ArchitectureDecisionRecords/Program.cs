using CommandLine;
using System;

namespace ArchitectureDecisionRecords
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<CreateArchitectureDecisionRecordOptions, InitializeRepositoryCommandOptions>(args).MapResult(
                (CreateArchitectureDecisionRecordOptions opts) => new CreateArchitectureDecisionCommand().Execute(opts),
                (InitializeRepositoryCommandOptions opts) => new InitializeRepositoryCommand().Execute(opts),
                (error) => 1);
        }
    }
}
