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
            try
            {
                IRoverProvider inputFileRoverManager = new InputFileRoverProvider();
                var roverProviderResult = inputFileRoverManager.GetRovers();

                //Execute rover commands
                foreach (var rover in roverProviderResult.Rovers)
                {
                    foreach (var command in rover.GetRoverCommands())
                    {
                        rover.ExecuteCommand(command, roverProviderResult.Plateau);
                    }

                    Console.WriteLine(rover.GetState().PrintState());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
