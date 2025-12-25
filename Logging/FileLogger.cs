namespace OrderSystem.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("File path is not correct", nameof(filePath));
            _filePath = filePath;
        }
        public void Error(string message)
        {
            Write("ERROR", message);
        }

        public void Log(string message)
        {
            Write("INFO", message);
        }

        private void Write(string level, string message)
        {
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
            File.AppendAllText(_filePath, line + Environment.NewLine);
        }
    }
}
