using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZometSfarim.Loggers
{
    public class LogTxt
    {
        private static LogTxt instance;
        private static Queue<Log> logQueue;
        private static string logDir = @"C:\ZometSfarimLog\";
        private static string logFile = "log.txt";
        private static int maxLogAge = int.Parse("0");
        private static int queueSize = int.Parse("100");
        private static DateTime LastFlushed = DateTime.Now;

        /// <summary>
        /// Private constructor to prevent instance creation
        /// </summary>
        private LogTxt() { }

        /// <summary>
        /// An LogWriter instance that exposes a single instance
        /// </summary>
        public static LogTxt Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (instance == null)
                {
                    instance = new LogTxt();
                    logQueue = new Queue<Log>();
                }
                return instance;
            }
        }

        /// <summary>
        /// The single instance method that writes to the log file
        /// </summary>
        /// <param name="message">The message to write to the log</param>
        public void WriteToLog(string message)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log(message);
                logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (logQueue.Count >= queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }
        public void WriteToLog(List<string> message)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log(message);
                logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (logQueue.Count >= queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }
        private bool DoPeriodicFlush()
        {
            TimeSpan logAge = DateTime.Now - LastFlushed;
            if (logAge.TotalSeconds >= maxLogAge)
            {
                LastFlushed = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Flushes the Queue to the physical log file
        /// </summary>
        private void FlushLog()
        {
            while (logQueue.Count > 0)
            {
                Log entry = logQueue.Dequeue();
                string logPath = logDir + entry.LogDate + "_" + logFile;

                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                if (!File.Exists(logPath))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(logPath))
                    {
                    }

                }
                // This could be optimised to prevent opening and closing the file for each write
                using (FileStream fs = File.Open(logPath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter log = new StreamWriter(fs))
                    {
                        if (entry.Message != null)
                            log.WriteLine(string.Format("{0}\t{1}", entry.LogTime, entry.Message));
                        else if (entry.MessageList != null)
                        {
                            foreach (var message in entry.MessageList)
                            {
                                log.WriteLine(string.Format("{0}\t{1}", entry.LogTime, message));
                            }
                        }
                    }
                }
            }
        }
        public class Log
        {
            public string Message { get; set; }
            public string LogTime { get; set; }
            public string LogDate { get; set; }
            public List<string> MessageList { get; set; }

            public Log(string message)
            {
                Message = message;
                LogDate = DateTime.Now.ToString("yyyy-MM-dd");
                LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
            }

            public Log(List<string> messages)
            {
                MessageList = messages;
                LogDate = DateTime.Now.ToString("yyyy-MM-dd");
                LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
            }
        }
    }
}
