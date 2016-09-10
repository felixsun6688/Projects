using System;

namespace AorangiPeak.Common.Logging
{
    public interface ILogger
    {
        string SerializeException(Exception e);

        void Debug(object source, object message);
        void Debug(Type source, object message);

        void Info(object source, object message);
        void Info(Type source, object message);

        void Warn(object source, object message);
        void Warn(Type source, object message);

        void Error(object source, object message);
        void Error(Type source, object message);

        void Fatal(object source, object message);
        void Fatal(Type source, object message);

        void EnsureInitialized();
    }
}
