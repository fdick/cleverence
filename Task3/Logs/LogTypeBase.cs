using System.Text.RegularExpressions;

namespace Cleverence.Task3.Logs
{
    public abstract class LogTypeBase
    {
        protected string _pattern;
        protected Regex _regex;

        protected const string DEFAULT = "DEFAULT";
        protected const string WARN = "WARN";
        protected const string INFO = "INFO";

        public bool IsMatch(string line)
        {
            return _regex.IsMatch(line);
        }

        public abstract bool TryToConvert(string line, out LogLine outLog);

        protected string ProcessLogLevel(string str)
        {
            return str switch
            {
                "INFORMATION" => INFO,
                "WARNING" => WARN,
                _ => str
            };
        }

        protected void SetPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                Console.WriteLine($"Pattern {pattern} is invalid!");

            _pattern = pattern;
            _regex = new Regex(pattern, RegexOptions.Compiled);

        }

    }
}
