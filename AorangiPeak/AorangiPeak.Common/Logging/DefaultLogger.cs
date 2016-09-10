using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace AorangiPeak.Common.Logging
{
    public class DefaultLogger : ILogger
    {
        private Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();
        private bool _logInitialized = false;
        private object _lock = new object();

        public void Debug(Type source, object message)
        {
            Logger(source).Debug(message);
        }

        public void Debug(object source, object message)
        {
            Debug(source.GetType(), message);
        }

        public void Debug(object source, object message, Exception exception)
        {
            Debug(source.GetType(), message,exception);
        }

        public void Debug(Type source, object message, Exception exception)
        {
            Logger(source).Debug(message, exception);
        }

        public void Error(Type source, object message)
        {
            Logger(source).Error(message);
        }

        public void Error(object source, object message)
        {
            Error(source.GetType(), message);
        }

        public void Error(object source, object message, Exception exception)
        {
            Error(source.GetType(), message, exception);
        }

        public void Error(Type source, object message, Exception exception)
        {
            Logger(source).Error(message, exception);
        }

        public void Fatal(Type source, object message)
        {
            Logger(source).Fatal(message);
        }

        public void Fatal(object source, object message)
        {
            Fatal(source.GetType(), message);
        }

        public void Fatal(object source, object message, Exception exception)
        {
            Fatal(source.GetType(), message, exception);
        }

        public void Fatal(Type source, object message, Exception exception)
        {
            Logger(source).Fatal(message, exception);
        }

        public void Info(Type source, object message)
        {
            Logger(source).Info(message);
        }

        public void Info(object source, object message)
        {
            Info(source.GetType(), message);
        }

        public void Info(object source, object message, Exception exception)
        {
            Info(source.GetType(), message, exception);
        }

        public void Info(Type source, object message, Exception exception)
        {
            Logger(source).Info(message, exception);
        }

        public void Warn(Type source, object message)
        {
            Logger(source).Warn(message);
        }

        public void Warn(object source, object message)
        {
            Warn(source.GetType(), message);
        }

        public void Warn(object source, object message, Exception exception)
        {
            Warn(source.GetType(), message, exception);
        }

        public void Warn(Type source, object message, Exception exception)
        {
            Logger(source).Warn(message, exception);
        }

        public string SerializeException(Exception e)
        {
            return SerializeException(e, string.Empty);
        }

        private string SerializeException(Exception e, string exceptionMessage)
        {
            if (e == null) return string.Empty;
            exceptionMessage = string.Format(
                "{0}{1}{2}\n{3}" ,
                exceptionMessage,
                (exceptionMessage==string.Empty)? string.Empty:"\n\n",
                e.Message,
                e.StackTrace);
            if (e.InnerException != null)
                exceptionMessage = SerializeException(e.InnerException, exceptionMessage);
            return exceptionMessage;
        }

        public void EnsureInitialized()
        {
            if (!_logInitialized)
            {
                Initialize();
                _logInitialized = true;
            }
        }

        private ILog Logger(Type source)
        {
            lock (_lock)
            {
                if (_loggers.ContainsKey(source))
                {
                    return _loggers[source];
                }
                else
                {
                    ILog logger = LogManager.GetLogger(source);
                    _loggers.Add(source, logger);
                    return logger;
                }
            }
        }

        private void Initialize()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log4Net.config");
            if (!File.Exists(logFilePath))
            {
                logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Log4Net.config");
            }
            XmlConfigurator.ConfigureAndWatch(new FileInfo(logFilePath));
        }
    }
}
