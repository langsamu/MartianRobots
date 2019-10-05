# Class library

This folder contains a .NET Core class library project.

## Architecture

- [Parser](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/Parser.cs) converts a textual representation of a world with robots and movement commands into an object graph.
- [World](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/World.cs) and [Robot](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/Robot.cs) represent entities in the Martian Robots domain.
- [Command](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/Command.cs) represents and its derivates ([forward](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/ForwardCommand.cs), [left](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/LeftCommand.cs) and [right](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/RightCommand.cs)) implement robot actions corresponding to commands.
- [Serialiser](https://github.com/langsamu/MartianRobots/blob/master/MartianRobots/Serialiser.cs) converts the state of the world after executing commands into a textual representation.