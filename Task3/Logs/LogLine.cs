namespace Cleverence.Task3.Logs
{
    public struct LogLine
    {
        public string Date { get; }
        public string Time { get; }
        public string LogLevel { get; }
        public string Method { get; }
        public string Message { get; }

        public LogLine(string date, string time, string logLevel, string method, string message)
        {
            Date = date;
            Time = time;
            LogLevel = logLevel;
            Method = method;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Date}\t{Time}\t{LogLevel}\t{Method}\t{Message}";
        }
    }
}
