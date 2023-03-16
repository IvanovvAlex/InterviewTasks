using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace OnlineStore.API.Logger
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _logFilePath;

        public FileLoggerProvider(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_logFilePath);
        }

        public void Dispose()
        {
        }

        private class FileLogger : ILogger
        {
            private readonly string _logFilePath;

            public FileLogger(string logFilePath)
            {
                _logFilePath = logFilePath;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
                Exception exception, Func<TState, Exception, string> formatter)
            {
                // Write the log message to a file
                var logMessage = formatter(state, exception);
                var logLine = $"{DateTime.Now} {logMessage}{Environment.NewLine}";
                File.AppendAllText(_logFilePath, logLine);
            }
        }
    }

}
