using Hb.MarsRover.Commands;
using Hb.MarsRover.Exceptions;
using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Managers
{
    public class InputFileRoverProvider : IRoverProvider
    {
        /// <summary>
        /// Reads rover configurations from input.txt file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InputFileNotFoundException"></exception>
        /// <exception cref="InputFileValidationException"></exception>
        public RoverProviderResult GetRovers()
        {
            if (!File.Exists("input.txt"))
                throw new InputFileNotFoundException();

            var fileContent = File.ReadAllLines("input.txt");

            if (fileContent.Length < 3)
                throw new InputFileValidationException("Incorrect line count. input.txt must contain at least 3 lines");

            if (fileContent.Length % 2 != 1)
                throw new InputFileValidationException("Incorrect line count. line count must be odd number");

            var plateuLine = fileContent.First();

            //group rover lines
            var roverLineGroups = fileContent.Skip(1).Chunk(2);


            List<Rover> rovers = new List<Rover>();
            foreach (var group in roverLineGroups)
            {
                rovers.Add(ParseRovoerGroup(group));
            }

            RoverProviderResult result = new RoverProviderResult();
            result.Rovers = rovers;
            result.Plateau = ParsePlateauLine(plateuLine);

            return result;
        }

        private Plateau ParsePlateauLine(string line)
        {
            int x = 0;
            int y = 0;

            var splitResult = line.Trim().Split(' ');

            if (splitResult.Length != 2)
                throw new InputFileValidationException("Incorrect plateu input.");

            if (!int.TryParse(splitResult[0], out x) || !int.TryParse(splitResult[1], out y))
            {
                throw new InputFileValidationException("An error occurred while parsing plateu input. Coordinates must be integer");
            }

            return new Plateau
            {
                X = x,
                Y = y
            };
        }

        private Rover ParseRovoerGroup(string[] group)
        {
            var coordLine = group[0];
            var commandLine = group[1];

            var state = ParseCoordinateLine(coordLine);
            var commands = ParseRoverCommands(commandLine);

            return new Rover(state, commands);
        }

        private RoverState ParseCoordinateLine(string line)
        {
            var splitResult = line.Trim().Split(' ');
            RoverState roverState = new RoverState();
            roverState.X = int.Parse(splitResult[0]);
            roverState.Y = int.Parse(splitResult[1]);


            Direction direction = Direction.Unknown;

            if (!Enum.TryParse(splitResult[2], out direction) || direction == Direction.Unknown)
                throw new InputFileValidationException($"Unkonwn direction at line {line}");

            roverState.Direction = direction;

            return roverState;
        }

        private IEnumerable<IRoverCommand> ParseRoverCommands(string line)
        {
            List<IRoverCommand> commands = new List<IRoverCommand>();
            var commandInterfaceType = typeof(IRoverCommand);

            // Get class types which imlements IRoverCommand and group them by CommandName
            var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => commandInterfaceType.IsAssignableFrom(p) && !p.IsInterface)
                                .ToDictionary(x => x.GetProperty("CommandName").GetValue(Activator.CreateInstance(x), null));

            // enumarete each character in command line and create command classes 
            foreach (var command in line.Trim())
            {
                if (commandTypes.ContainsKey(command.ToString()))
                {
                    commands.Add((IRoverCommand)Activator.CreateInstance(commandTypes[command.ToString()]));
                }
                else
                {
                    throw new InputFileValidationException($"Unkonwn command at line {line}");
                }
            }

            return commands;
        }
    }
}
