using System;
using System.Collections.Generic;

namespace Coders_Strike_Back
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Checkpoint> checkpoints = new List<Checkpoint>();
            Checkpoint farthestCheckpoint = new Checkpoint(-1, -1);
            Checkpoint previousCheckpoint = new Checkpoint(-1, -1);
            int lapCount = 1;
            int previousCheckpointAngle = 0;
            double farthestCheckpointDist = double.MinValue;
            string[] inputs;
            bool boost = true;

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
                int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
                int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
                int nextCheckpointAngle = int.Parse(inputs[5]); // angle between your pod orientation and the direction of the next checkpoint
                inputs = Console.ReadLine().Split(' ');
                int opponentX = int.Parse(inputs[0]);
                int opponentY = int.Parse(inputs[1]);

                if (!checkpoints.Contains(new Checkpoint(nextCheckpointX, nextCheckpointY)))
                {
                    checkpoints.Add(new Checkpoint(nextCheckpointX, nextCheckpointY));
                }

                Console.Error.WriteLine(checkpoints[0].x + " " + checkpoints[0].y);

                if (previousCheckpoint.x > 0 &&
                previousCheckpoint.y > 0 &&
                previousCheckpoint.x != nextCheckpointX &&
                previousCheckpoint.y != nextCheckpointY &&
                checkpoints[0].x == nextCheckpointX &&
                checkpoints[0].y == nextCheckpointY)
                {
                    lapCount++;
                }

                string thrust = (nextCheckpointAngle > 90 || nextCheckpointAngle < -90) ? "0" : "100";
                if (farthestCheckpointDist < nextCheckpointDist)
                {
                    farthestCheckpointDist = nextCheckpointDist;
                    farthestCheckpoint.x = nextCheckpointX;
                    farthestCheckpoint.y = nextCheckpointY;
                }

                if (boost == true && lapCount == 3 &&
                thrust.Equals("100") &&
                previousCheckpointAngle == nextCheckpointAngle &&
                nextCheckpointX == farthestCheckpoint.x &&
                nextCheckpointY == farthestCheckpoint.y)
                {
                    boost = false;
                    thrust = "BOOST";
                }

                Console.Error.WriteLine(boost);
                Console.Error.WriteLine("Lap: " + lapCount);
                Console.Error.WriteLine("Farthest Checkpoint : " + farthestCheckpoint.x + " " + farthestCheckpoint.y);
                Console.Error.WriteLine("Next Checkpoint: " + nextCheckpointX + " " + nextCheckpointY);
                Console.Error.WriteLine("Next Checkpoint Angle : " + nextCheckpointAngle);

                previousCheckpoint.x = nextCheckpointX;
                previousCheckpoint.y = nextCheckpointY;
                previousCheckpointAngle = nextCheckpointAngle;

                Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + thrust);
            }
        }
    }
}
