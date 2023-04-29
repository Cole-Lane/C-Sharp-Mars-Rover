using System;
using System.Collections.Generic;
using System.IO;
using Mars_Rovers;

namespace Mars_Rovers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "/Users/colelane/Documents/Input.txt";
            LineReader LineRead = new LineReader();

            Rover Rover1 = new Rover(0, 0, 'N');
            Plateau MarsP = new Plateau(0,0);

            //lineCounter is used to determine what instruction should be given from the input file.
            int lineCounter = 0;

            //Read from input file, throwing an exception if the file is not found.
            try
            {
                foreach (string line in System.IO.File.ReadLines(inputFile))
                {
                    if (lineCounter == 0) //plateau creation
                    {
                        MarsP = LineRead.plateauDimensionsLine(line);
                    }
                    else if (lineCounter % 2 == 1) //new rover
                    {
                        Rover1 = LineRead.roverCreationLine(line, MarsP);
                    }
                    else if (lineCounter % 2 == 0) //rover instructions
                    {
                        LineRead.roverMovementLine(line, Rover1);
                        Console.WriteLine(Rover1.getPosition());
                    }

                    lineCounter++;
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

        }

    }

}






