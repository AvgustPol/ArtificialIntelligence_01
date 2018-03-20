using System;

namespace CSVFileReadWrite
{
    static class StandardDeviationCounter
    {
       public static double CountStandardDeviation(double AverageCost, double[] variables)
        {
            double tmp = 0;
            for (int i = 0; i < variables.Length; i++)
            {
                tmp += (variables[i] - AverageCost) * (variables[i] - AverageCost);
            }

            tmp /= variables.Length;
            return Math.Sqrt(tmp);
        }
    }
}
