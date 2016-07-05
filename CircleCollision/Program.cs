using System;
using System.Timers;
using System.Collections;
using System.IO;
using System.Linq;
class Solution
{
    /// <summary>
    /// This method measures the distance between 2 points in any number of dimensions of Euclidean space.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    static double Distance(double[] x, double[] y)
    {
        if (x.Length != y.Length)
        {
            Console.WriteLine("each point must have the same number of coordinates, returning 0");
            return 0;
        }
        else
        {
            double sumOfSquaredDifferences = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sumOfSquaredDifferences += Math.Pow(x[i] - y[i], 2);
            }
            double distance = Math.Sqrt(sumOfSquaredDifferences);
            return distance;
        }

    }

    static void Main(String[] args)
    {

        // Read the number of test cases
        Console.WriteLine("This program tests whether two spheres moving at constant acceleration will collide.");
        Console.WriteLine("How many test cases would you like to have?");
        Console.Write("(Please enter an integer):");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();


        // for loop, one instance for each test case

        for (int i = 0; i < n; i++)
        {

            // first line, pair of radii for the 2 discs
            Console.WriteLine("What are the radius of the 2 discs?");
            Console.WriteLine("Sample input:  1 2");
            Console.Write(">: ");
            double[] r = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            //position of the center of the first circle
            Console.WriteLine("What are the coordinates of the center first disc?");
            Console.WriteLine("Note; the disc can have 2 or more dimensions, but the dimensions");
            Console.WriteLine("must be consistent for all of the remaining questions.");
            Console.WriteLine("Sample input for a 3-D sphere:  1 2 3");
            Console.Write(">: ");
            double[] p1 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            //acceleration of the first circle
            Console.WriteLine("What are the acceleration components of the first disc?");
            Console.WriteLine("There must be an input for each position coordinate.");
            Console.WriteLine("Sample input for the 3-D sphere:  1 0 0");
            Console.Write(">: ");
            double[] a1 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            //position of the second circle
            Console.WriteLine("Coordinates of the second disc?");
            Console.WriteLine("Sample input: -10 0 5");
            Console.Write(">: ");
            double[] p2 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            //acceleration of the second circle
            Console.WriteLine("Acceleration of the second disc?");
            Console.WriteLine("Sample input: -1 0 0");
            Console.Write(">: ");
            double[] a2 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

            Console.WriteLine("\n\n\n");
            Console.WriteLine("Thank you for your inputs!");
            Console.WriteLine("Beginning calculations...");

            // answer variable set to false, if the circles collide it will be set to true
            bool answer = false;

            // lastDistance calculates the initial distance between the 2 circles.
            double lastDistance = Distance(p1, p2);
            Console.WriteLine("The initial distance between the two centers is: " + lastDistance);

            // t will be the time variable in the follow while loop
            double t = 0.0;

            // loop that runs as a time progression, time t starts at 0 and increases by increments of 0.01
            while (true)
            {

                //this loop goes through each of the coordinates in the first sphere, and updates them based on the given acceleration of each coordinate.
                for (int j = 0; j < p1.Length; j++)
                {
                    p1[j] = p1[j] + a1[j] * t * t;
                }

                // this loop does the same for the second sphere
                for (int k = 0; k < p2.Length; k++)
                {
                    p2[k] = p2[k] + a2[k] * t * t;
                }

                //calculates the distance between the two circle centers at the current time
                double distance = Distance(p1, p2);


                // if the distance is less then the sum of the two radii, the circles are overlapping. If it is equal, they are touching.
                // So if that's the case, we set the answer to true, denoting a collision, and break the loop.
                if (distance <= r[0] + r[1])
                {
                    answer = true;

                    break;
                }

                // if the current distance is greater then the previous distance, that means the circles are moving apart. Since they are
                //travelling in perfectly straight lines, the distance will only grow. Therefore, we break the loop since we know a collision
                // is impossible.
                if (distance > lastDistance)
                {
                    break;
                }

                // incremental time passage
                t += 0.01;

                // now set the previous distance to the new distance
                lastDistance = distance;

            }
            if (answer)
            {
                Console.WriteLine("The two discs collided at:");
                Console.WriteLine("Time: " + t);
                Console.Write("Position: ");
                for (int f = 0; f < p1.Length; f++)
                {
                    Console.Write((p1[f] + p2[f]) / (r[0] + r[1]) + " ");
                }
                Console.WriteLine();
            }

            else
                Console.WriteLine("The discs will not collide.");


        }
    }
}
