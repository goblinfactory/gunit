namespace Gunit.Core.Logging
{
    public interface ILog
    {
        void Debug(string text, int indent);
        void Info(string text, int indent);
        void Error(string text, int indent);
        string[] Logs { get;  }
    }
}