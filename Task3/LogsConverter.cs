using Cleverence.Task3.Logs;

namespace Cleverence.Task3
{
    public class LogsConverter
    {
        public LogsConverter(string outputFilePath, string outProblemsFilePath)
        {
            _outputFilePath = outputFilePath;
            _problemsFilePath = outProblemsFilePath;
        }

        private string _outputFilePath;
        private string _problemsFilePath;

        private LogTypeBase[] _logTypes = [new LogsType1(), new LogsType2()];



        public void ProcessConvertation(string inputFilePath)
        {
            if (!FileHandler.TryToReadFileByLine(inputFilePath, out var outIterator))
            {
                Console.WriteLine($"I can not open the file {inputFilePath}");
                return;
            }

            foreach (string line in outIterator)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                bool lineIsOkey = false;

                foreach (var l in _logTypes)
                {

                    if (!l.IsMatch(line))
                        continue;

                    if (l.TryToConvert(line, out var outLog))
                    {
                        //write to file
                        FileHandler.WriteLineToFile(_outputFilePath, outLog.ToString());
                        lineIsOkey = true;
                        break;
                    }
                }

                //write to problems file
                if (!lineIsOkey)
                    FileHandler.WriteLineToFile(_problemsFilePath, line);
            }

        }

    }
}
