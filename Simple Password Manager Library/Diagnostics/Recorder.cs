using System;
using System.Diagnostics;
using static System.Diagnostics.Process;

namespace SimplePM.Library.Diagnostics
{
    public static class Recorder
    {
        private static Stopwatch timer = new Stopwatch();
        private static long bytesPhysicalBefore = 0;
        private static long bytesVirtualBefore = 0;
        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }
        public static string Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            return $"Physical bytes used: {bytesPhysicalAfter - bytesPhysicalBefore}\n Virtual bytes used: {bytesVirtualAfter - bytesVirtualBefore}\n Time span ellapsed: {timer.Elapsed}\n Time ellapsed in milliseconds {timer.ElapsedMilliseconds}.";
        }
    }
}
