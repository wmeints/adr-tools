# ADR Tools
This repository contains a .net core global tool to manage architecture decision records for your project.
The idea is based on work published by Micheal Nygard on his blog: http://thinkrelevance.com/blog/2011/11/15/documenting-architecture-decisions.

## Installation
Make sure that you have .NET Core 2.1 SDK installed on your machine.
Run the following commands to compile and install the tool:

* `dotnet tool install --global ArchitectureDecisionRecords`

## Running the tool
You can start the tool with the command `adr`. It supports the following commands:

* `adr init`

Initializes a new repository in the folder `decisions` and creates a new `.adr-dir` file in the current working directory.
This file tells the tool where to store the decision records.

You can change the decisions folder by providing the `--path` option to this command.

* `adr new --title "<Title of the decision>"`

This creates a new decision record in the ADR repository. 
Please use quotes around the title if it contains more than one word.

## Development
You can build this tool locally as well. Execute the following steps to build 
and test the tool locally:

 * `dotnet pack -C release -o .\nupkg`
 * `dotnet tool install --global --add-source .\nupkg\ ArchitectureDecisionRecords`

## Requests, comments or bugs
Please file issues if you run into any problems. 
Feel free to send me a pull request for any new features you want included in the tool.