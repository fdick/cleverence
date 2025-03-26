using System.Text.RegularExpressions;

namespace Cleverence.Task3.Logs
{
    class LogsType2 : LogTypeBase
    {
        public LogsType2()
        {
            //             2025-03-10           15:14:51.5882          | INFO                    |11|MobileComputer.GetDeviceId| Код устройства: '@MINDEO-M40-D-410244015546'
            //            1: date,            2: time,                   3: log level,                     4: msg
            SetPattern(@"^(\d{4}-\d{2}-\d{2}) (\d{2}:\d{2}:\d{2}\.\d+)\| (INFORMATION|INFO|WARNING|WARN|ERROR|DEBUG)\|11\|([^|]+)\| (.+)$");
        }

        public override bool TryToConvert(string line, out LogLine outLog)
        {
            outLog = default;

            Match match = _regex.Match(line);

            if (!match.Success)
                return false;

            string date = DateTime.Parse(match.Groups[1].Value).ToString("dd-MM-yyyy");
            outLog = new LogLine(date, match.Groups[2].Value, ProcessLogLevel(match.Groups[3].Value), match.Groups[4].Value, match.Groups[5].Value);

            return true;
        }
    }
}
