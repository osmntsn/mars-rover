using Hb.MarsRover.Commands;
using Hb.MarsRover.Managers;
using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;

namespace Hb.MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read rover configurations from "input.txt"
            IRoverProvider inputFileRoverManager = new InputFileRoverProvider();
            var roverProviderResult = inputFileRoverManager.GetRovers();

            //Execute rover commands
            foreach (var rover in roverProviderResult.Rovers)
            {
                foreach (var command in rover.GetRoverCommands())
                {
                    rover.ExecuteCommand(command, roverProviderResult.Plateau);
                }
            }

            //Print last rover states
            foreach (var rover in roverProviderResult.Rovers)
            {
                Console.WriteLine(rover.GetState().PrintState());
            }
        }
    }
}
