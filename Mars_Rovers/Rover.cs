using System;
namespace Mars_Rovers
{
    /// <summary>
    /// Class that represents a Mars Rover. Utilizes both the Compass and plateauMap classes as well.
    /// Keeps track of its location and heading (of the four basic directions: North, South, East, West).
    /// </summary>
    public class Rover
    {
        private int eastCoordinant;
        private int northCoordinant;
        private char heading;

        private Compass roverComp;
        private Plateau roverMap;

        /// <summary>
        /// Constructor to create the Rover from input of Current Coordinates and Heading
        /// </summary>
        /// <param name="eastCoord">Integer representing location on X axis.</param>
        /// <param name="northCoord">Integer representing location on Y axis.</param>
        /// <param name="Heading">Character that represents the current heading of the four basic directions (North, South, East, West).</param>
        public Rover(int eastCoord, int northCoord, Char Heading)
        {
            eastCoordinant = eastCoord;
            northCoordinant = northCoord;
            heading = Heading;

            //Composistion to make use of the compass
            roverComp = new Compass(heading);
        }

        /// <summary>
        /// Constructor to create a Rover from input of Current Coordinates, Heading and plateauMap.
        /// </summary>
        /// <param name="eastCoord">Integer representing location on X axis.</param>
        /// <param name="northCoord">Integer representing location on Y axis.</param>
        /// <param name="Heading">Character that represents the current heading of the four basic directions (North, South, East, West).</param>
        /// <param name="map">An instance of the plateauMap class, allows the Rover to check and make sure it does not move off of the plateau.</param>
        public Rover(int eastCoord, int northCoord, Char Heading, Plateau map)
        {
            eastCoordinant = eastCoord;
            northCoordinant = northCoord;
            heading = Heading;
            roverComp = new Compass(heading);
            roverMap = map;
            //Console.WriteLine("Map size is:" + map.getPlateauSize());
        }

        /// <summary>
        /// Void function to allow composistion between the Rover and plateauMap class.
        /// </summary>
        /// <param name="marsMap">An instance of the plateauMap class.</param>
        public void loadMap(Plateau marsMap)
        {
            roverMap = marsMap;
        }

        /// <summary>
        /// Basic navigation function. Uses the Rover's Compass to change direction by turning left 90 degrees.
        /// </summary>
        public void TurnLeft()
        {
            roverComp.changeDirection(-1);
            heading = roverComp.getDirection();
        }

        /// <summary>
        /// Basic navigation function. Uses the Rover's Compass to change direction by turning right 90 degrees.
        /// </summary>
        public void TurnRight()
        {
            roverComp.changeDirection(1);
            heading = roverComp.getDirection();
        }

        /// <summary>
        /// Basic navigation function. Uses the Rover's Compass to verify direction and add's the direction's vector to the Rover's current location.
        /// </summary>
        public void Forward()
        {
            //use vector from compass and add to current coordinants

            // create function for movement calculation - pendingMove function?
            (int eastMovement, int northMovement) = roverComp.getVector();

            //Verifies with the map that movement does not cause out of bounds (fall off the plateau)
            if (roverMap.coordinateExist(eastCoordinant + eastMovement, northCoordinant + northMovement))
            {
                this.eastCoordinant = eastCoordinant + eastMovement;
                this.northCoordinant = northCoordinant + northMovement;
            }
            //Catch for out of bounds, Rover does not move.
            else
                Console.WriteLine("Rover is unable to move to {0} {1} (Off of Plateau)", (eastCoordinant + eastMovement), (northCoordinant + northMovement));
        }


        /// <summary>
        /// Funtion to return the current posistion and heading of the Rover.
        /// </summary>
        /// <returns>String with integer values for both the X and Y axis and a Char representing the current heading of the four basic direcions (N, S, E, W)</returns>
        public string getPosition()
        {
            return string.Format("{0} {1} {2}", eastCoordinant, northCoordinant, heading);
        }

        /// <summary>
        /// Takes a single character as input and determines what kind of movement that the rover needs to take.
        /// An invalid instruction string is written to the console if the char does not match any of the determined movements.
        /// </summary>
        /// <param name="currentInstruction">Character representing the movement that the rover should make. (L for Turn left, R for Turn right, or M for Move forward).</param>
        public void readInstruction(char currentInstruction)
        {
            switch (currentInstruction)
            {
                case 'L':
                    //turn left
                    this.TurnLeft();
                    break;

                case 'R':
                    //turn right
                    this.TurnRight();
                    break;

                case 'M':
                    //forward
                    this.Forward();
                    break;

                default:
                    //invalid direction
                    Console.WriteLine("The instruction that the Rover was given is invalid");
                    break;
            }
        }

    }
}
