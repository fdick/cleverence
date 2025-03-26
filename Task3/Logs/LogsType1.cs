using System.Text.RegularExpressions;

namespace Cleverence.Task3.Logs
{
    class LogsType1 : LogTypeBase
    {
        public LogsType1()
        {
            //             10.03.2025           15:14:49.523             INFORMATION                       Версия программы: '3.4.0.48729'
            //             1: date,             2: time,                 3: log level,                     4: msg
            SetPattern(@"^(\d{2}\.\d{2}\.\d{4}) (\d{2}:\d{2}:\d{2}\.\d+) (INFORMATION|INFO|WARNING|WARN|ERROR|DEBUG) (.+)$");
        }

        public override bool TryToConvert(string line, out LogLine outLog)
        {
            outLog = default;

            Match match = _regex.Match(line);

            if (!match.Success)
                return false;

            outLog = new LogLine(match.Groups[1].Value, match.Groups[2].Value, ProcessLogLevel(match.Groups[3].Value), DEFAULT, match.Groups[4].Value);
            
            return true;
        }
    }
}
