namespace Cleverence.Task3
{
    static class FileHandler
    {
        static public bool TryToReadFileByLine(string filePath, out IEnumerable<string> outIterator)
        {
            outIterator = default;

            if (!File.Exists(filePath))
                return false;

            outIterator = File.ReadLines(filePath);
            return true;
        }

        static public void WriteLineToFile(string filePath, string line)
        {
            using var writer = new StreamWriter(filePath, true);
            writer.WriteLine(line);
        }
    }
}
