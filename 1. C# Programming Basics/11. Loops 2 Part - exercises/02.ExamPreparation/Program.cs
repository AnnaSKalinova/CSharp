using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int unappropiateScoreCount = int.Parse(Console.ReadLine());

            string problem = Console.ReadLine();
            double score = 0.0;
            int currentUnappropriateCount = 0;
            bool isUnappropriate = false;
            double averageScore = 0.0;
            double totalScore = 0.0;
            int totalScoreCount = 0;
            string lastProblem = string.Empty;

            while (problem != "Enough")
            {
                score = double.Parse(Console.ReadLine());
                totalScore += score;
                totalScoreCount++;

                if (score <= 4)
                {
                    currentUnappropriateCount++;
                }

                if (currentUnappropriateCount == unappropiateScoreCount)
                {
                    isUnappropriate = true;
                    break;
                }
                else
                {
                    lastProblem = problem;
                    problem = Console.ReadLine();
                }
            }

            if (isUnappropriate)
            {
                Console.WriteLine($"You need a break, {currentUnappropriateCount} poor grades.");
            }
            else
            {
                averageScore = totalScore / totalScoreCount;
                Console.WriteLine($"Average score: {averageScore:f}");
                Console.WriteLine($"Number of problems: {totalScoreCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
