using System;
namespace Mars_Rovers
{
    /// <summary>
    /// Class that defines the size of the plateau that the Rover(s) is/are on.
    /// </summary>
    public class Plateau
    {
        private int plateauLength;
        private int plateauWidth;

        /// <summary>
        /// Constructor for creation of the map defined by the two given variables.
        /// </summary>
        /// <param name="plateauX">The size of the X axis.</param>
        /// <param name="plateauY">The size of the Y axis.</param>
        public Plateau(int plateauX, int plateauY)
        {
            plateauLength = plateauX;
            plateauWidth = plateauY;
        }

        /// <summary>
        /// Method to return the size of the plateau. Used for refrences.
        /// </summary>
        /// <returns>A tuple of two integers, the first one representing the X axis value, and the other represents the Y axis value.</returns>
        public (int length, int width) getPlateauSize()
        {
            return (plateauLength, plateauWidth);
        }

        /// <summary>
        /// Method for checking if the posistion exists on the map / plateau.
        /// </summary>
        /// <param name="xCoordinate">Posistion on the X axis of the map.</param>
        /// <param name="yCoordinate">Possition on the Y axis of the map.</param>
        /// <returns>A boolean value, true if the given posistion is within the bounds of the map and false if it does not.</returns>
        public bool coordinateExist(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate >= 0 && xCoordinate <= plateauLength)
                if (yCoordinate >= 0 && yCoordinate <= plateauWidth)
                    return true;
            return false;
        }

    }
}
