# Command-line interface

This folder contains a .NET Core console application project.

Text representing the state of the world with robot locations and movement commands is taken from the standard input stream. The state after execution is serialised into the standard output stream.

## How to run

```bat
dotnet run -p MartianRobots.Cli < SampleInput.txt
```
