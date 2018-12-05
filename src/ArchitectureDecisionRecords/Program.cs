using CommandLine;
using System;

namespace ArchitectureDecisionRecords
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<CreateArchitectureDecisionRecordOptions, InitializeRepositoryCommandOptions, ListArchitectureDecisionsCommandOptions>(args).MapResult(
                (CreateArchitectureDecisionRecordOptions opts) => new CreateArchitectureDecisionCommand().Execute(opts),
                (InitializeRepositoryCommandOptions opts) => new InitializeRepositoryCommand().Execute(opts),
                (ListArchitectureDecisionsCommandOptions opts) => new ListArchitectureDecisionsCommand().Execute(opts),
                (error) => 1);
        }
    }
}
