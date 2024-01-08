namespace StairsPlugin.StressTesting
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.VisualBasic.Devices;
    using StairsPlugin.KompasWrapper;
    using StairsPlugin.Model;

    public class Program
    {
        private static void Main()
        {
            var builder = new StairsBuilder();
            var stopWatch = new Stopwatch();
            var parameters = new StairsParameters();
            var streamWriter = new StreamWriter($"log.txt", false);
            var currentProcess = Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                stopWatch.Start();
                builder.BuildStairs(parameters);
                stopWatch.Stop();
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;
                streamWriter.WriteLine($"{++count}. "
                                       + $"{stopWatch.ElapsedMilliseconds}; "
                                       + $"{usedMemory}");
                stopWatch.Reset();
                streamWriter.Flush();
            }

            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}
