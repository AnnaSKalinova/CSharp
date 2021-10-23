using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            string newStepsCount = Console.ReadLine();

            int totalSteps = 0;
            bool isGoalReached = false;

            while (totalSteps < goal)
            {
                if (newStepsCount == "Going home")
                {
                    newStepsCount = Console.ReadLine();
                    totalSteps += int.Parse(newStepsCount);
                    if (totalSteps >= goal)
                    {
                        isGoalReached = true;
                    }
                    break;
                }

                totalSteps += int.Parse(newStepsCount);

                if (totalSteps >= goal)
                {
                    isGoalReached = true;
                    break;
                }

                newStepsCount = Console.ReadLine();
            }
            
            if (isGoalReached)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
            }
        }
    }
}
