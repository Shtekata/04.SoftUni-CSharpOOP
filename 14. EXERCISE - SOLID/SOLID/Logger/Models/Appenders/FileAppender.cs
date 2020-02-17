using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;

namespace Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        private int messagesAppended;
        private FileAppender()
        {
            messagesAppended = 0;
        }
        public FileAppender(ILayout layout, Level level, IFile file)
            : this()
        {
            Layout = layout;
            Level = level;
            File = file;
        }
        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            var formattedMessages = File.Write(Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(File.Path, formattedMessages);
            messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {Level.ToString()}, Messages appended: {messagesAppended}, File size: {File.Size}";
        }
    }
}
