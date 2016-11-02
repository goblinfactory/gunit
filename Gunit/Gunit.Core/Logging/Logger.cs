using System;
using System.Collections.Generic;
using Gunit.Core.Packages.MUnit;

namespace Gunit.Core.Logging
{
    public class Logger : ILog
    {
        public static Action<string> Echo = _ => { };
        public static Level DefaultLevel = Level.Off;

        private readonly Level _level;
        private static List<string> _logs = new List<string>();

        public Logger(Level level)
        {
            _level = level;
        }

        private void Log(Level level, string text)
        {
            if (level <= _level) return;
            _logs.Add(text);
            Echo(text);
        }

        public void Info(string text,  int indent)
        {
            Log(Level.Info, text.Indent(indent));
        }

        public void Debug(string text, int indent)
        {
            Log(Level.Debug, text.Indent(indent));
        }

        public void Error(string text, int indent)
        {
            Log(Level.Debug, text.Indent(indent));
        }

        public string[] Logs
        {
            get { return _logs.ToArray(); }
        }
    }
}