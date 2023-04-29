using System;
using System.Collections.Generic;

namespace Mars_Rovers
{
    /// <summary>
    /// Acts upon the given string variable by creating either a plateauMap or Rover.
    /// </summary>
    public class LineReader
    {

    /// <summary>
    /// Recieves two strings and attempts to convert both strings into integers.
    /// </summary>
    /// <param name="xCord"> String value representing the X coordinate to be converted to an integer. </param>
    /// <param name="yCord"> String value representing the Y coordinate to be converted to an integer.</param>
    /// <returns> A tuple of integers representing the X and Y coordinates given.</returns>
    /// <exception cref="System.ArgumentException">Parameters are not strings.</exception>
    private (int xCoordinate, int yCoordinate) stringToTuple(string xCord, string yCord)
    {
            List<int> coordinates = new List<int>();

            int coordinate;
            bool successfulXCord = int.TryParse(xCord, out coordinate);
            if (successfulXCord)
            {
                //Console.WriteLine($"Converted '{xCord}' to {coordinate}.");
                coordinates.Add(coordinate);
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{xCord ?? "<null>"}' failed.");
            }


            bool successfulYCord = int.TryParse(yCord, out coordinate);
            if (successfulYCord)
            {
                //Console.WriteLine($"Converted '{yCord}' to {coordinate}.");
                coordinates.Add(coordinate);
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{yCord ?? "<null>"}' failed.");
            }

            return (coordinates[0], coordinates[1]);
    }

        //moved to the plateau class or Rover class
    public Plateau plateauDimensionsLine(string plateauDimensions)
    {
            string[] plateauDimensionsWords = plateauDimensions.Split(' ');
            //method to convert to tuple for both Map creation and Rover Creation
            (int XDimension, int YDimension) = stringToTuple(plateauDimensionsWords[0], plateauDimensionsWords[1]);
            Plateau plateau = new Plateau(XDimension, YDimension);
            //Console.WriteLine("Plateau is X: {0} and Y: {1}", XDimension, YDimension);
            return plateau;
    }

        //also moved to the rover class (use String to Tuple as a public method or composistion) 
    public Rover roverCreationLine(string roverCreation, Plateau map)
    {
            string[] roverCreationWords = roverCreation.Split(' ');
            (int XCoordinate, int YCoordinate) = stringToTuple(roverCreationWords[0], roverCreationWords[1]);
            char direction = roverCreationWords[2].ToCharArray()[0];
            Rover newRover = new Rover(XCoordinate, YCoordinate, direction, map);

            return newRover;
    }

        //moved to inside the rover class
    public void roverMovementLine(string roverMovement, Rover movingRover)
    {
            string[] roverMovements = roverMovement.Split(' ');
            //rover to be added to a list of Rovers AFTER it has moved (for output)
            foreach (char ch in roverMovements[0].ToCharArray())
            {
                //method to read the char and determine what the Rover is to do
                movingRover.readInstruction(ch);
            }

            //Console.WriteLine(movingRover.getPosition());                 ******************************************
    }

    }
}
