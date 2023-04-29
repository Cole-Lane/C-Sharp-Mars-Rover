using System;
namespace Mars_Rovers
{
    /// <summary>
    /// Class used in composistion with the Rover class. Allows the Rover to compute its direction vector for movement.
    /// </summary>
    public class Compass
    {
        private readonly (int East, int North)[] Vector = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        private (int East, int North) currentVector;
        private readonly char[] directions = new char[] { 'N', 'E', 'S', 'W' };
        private char currentDirection;

        /// <summary>
        /// Constuctor used to set the current direction.
        /// </summary>
        /// <param name="Heading">Character signifying the direction that the compass is pointing towards from the 4 basic directions (N, S, E, W).</param>
        public Compass(char Heading)
        {
            currentDirection = Heading;
            setVector();
        }

        /// <summary>
        /// Changes the direction that the compass is pointing based on the given integer. Then calls the setVector method to update the Vector for movement calculation.
        /// </summary>
        /// <param name="rightOrLeft">Integer (either 1 or -1) that is added to the current index of the directions array.</param>
        public void changeDirection(int rightOrLeft)
        {
            //determine the new direction by first find the value, check to see if newDirection is OutOfBounds
            int newDirection = Array.IndexOf(directions, currentDirection) + rightOrLeft;

            //Decision making to prevent the directions array from going out of bounds
            //First check is to see if the value is higher than the length of the array, if it is, it returns to the beginning of the array.
            //Second checks is to verify that the value is not negative, if it is, returns to the end of the array.
            if (newDirection > directions.Length - 1)
                currentDirection = directions[0];

            else if (newDirection < 0)
                currentDirection = directions[directions.Length - 1];

            else
                currentDirection = directions[newDirection];


            //Console.WriteLine("Current direction is: {0}", currentDirection);             ******************************************************************************************

            //call to setVector so the Rover can pull movement data if it moves.
            setVector();
        }

        /// <summary>
        /// Returns a character that represents the current direction.
        /// </summary>
        /// <returns>Char for the current direction that is assigned to the Compass (N,S,E,W).</returns>
        public char getDirection()
        {
            return currentDirection;
        }

        /// <summary>
        /// Method to set the movement vector based on the currentDirection character.
        /// </summary>
        private void setVector()
        {
            //Using Switch as it is more readable and works better with scaling 
            switch (currentDirection)
            {
                case 'N':
                    //direction is north (0,1)
                    currentVector = Vector[0];
                    break;
                case 'E':
                    //direction is east (1,0)
                    currentVector = Vector[1];
                    break;
                case 'S':
                    //direction is south (0,-1)
                    currentVector = Vector[2];
                    break;
                case 'W':
                    //direction is west (-1,0)
                    currentVector = Vector[3];
                    break;
                default:
                    //invalid direction
                    Console.WriteLine("The direction that the Compass was given is invalid");
                    break;

            }
        }

        /// <summary>
        /// Returns the movement vector as a tuple of integers.
        /// </summary>
        /// <returns>A tuple of two integers, the first one representing the X axis value, and the other represents the Y axis value.</returns>
        public (int East, int North) getVector()
        {
            setVector();
            //Console.WriteLine("Current vector: {0}", currentVector);
            return currentVector;
        }

    }
}
