using System;
using System.IO;

namespace SimplePM.Library.Diagnostics
{
    public static class Logger
    {
        public static void CreateExceptionEntry(Exception ex)
        {
            DateTime dateTime = DateTime.Now;
            string fileName = $"{dateTime.Month}{dateTime.Day}{dateTime.Year}_{dateTime.Hour}_{dateTime.Minute}_{dateTime.Second}_error_log.txt";
            string dirPath = Path.Combine(Environment.CurrentDirectory, "logs");
            string filePath = Path.Combine(dirPath, fileName);
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(ex.ToString());
                sw.WriteLine();
            }
        }
    }
}
