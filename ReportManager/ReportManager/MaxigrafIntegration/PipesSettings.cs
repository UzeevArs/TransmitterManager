using System.Collections.Generic;

namespace ReportManager.MaxigrafIntegration
{
    internal static class ServerPipeSettings
    {
        public static string Name = "MaxiGrafPipe";

        public enum Commands
        {
            Timeout, ErrorWithCode, MarkingStopped, MarkingCompleted, Exit, Unknown
        }

        public static Dictionary<Commands, string> CommandsList =
            new Dictionary<Commands, string>
            {
                {Commands.Timeout,          "Can\'t Connect.\nTimeOut"},
                {Commands.ErrorWithCode,    "Can\'t Connect.\n Error Code:"},
                {Commands.MarkingStopped,   "MarkingStopped"},
                {Commands.MarkingCompleted, "MarkingCompletedSuccessfully"},
                {Commands.Exit,             "Bay-bay"}
            };

        public static Commands TryParseCommand(string command)
        {
            if (command.Contains(CommandsList[Commands.ErrorWithCode]))
                return Commands.ErrorWithCode;

            foreach (var commandPair in CommandsList)
            {
                if (commandPair.Value == command)
                    return commandPair.Key;
            }

            return Commands.Unknown;
        }
    }

    public static class ClientPipeSettings
    {
        public static string Name =             "BackMaxiGrafPipe";
        public static string HelloRequest =     "You can do BakcMaxiGrafPipe";
        public static string HelloResponse =    "Yes I can do BakcMaxiGrafPipe";

        public enum Commands
        {
            ShowRectJoystick, ShowCrossJoystick, StopMarking, SetValue, StartMarking, TxtFileStart, LeFileStart,
            EndFile, TxtSuccess, LeSuccess, Exit, Unknown
        }

        public static Dictionary<Commands, string> CommandsList = 
            new Dictionary<Commands, string>
            {
                {Commands.ShowRectJoystick,     "Show Rectangular Joystick"},
                {Commands.ShowCrossJoystick,    "Show Cross Joystick"},
                {Commands.StopMarking,          "Stop"},
                {Commands.SetValue,             "Set new Value"},
                {Commands.StartMarking,         "Start mark"},
                {Commands.TxtFileStart,         "This is a TXT file"},
                {Commands.LeFileStart,          "This is a LE file"},
                {Commands.EndFile,              "This is the end of file"},
                {Commands.TxtSuccess,           "TXT sucsses"},
                {Commands.LeSuccess,            "LE success"},
                {Commands.Exit,                 "Bay-Bay"}
            };

        public static Commands TryParseCommand(string command)
        {
            foreach (var commandPair in CommandsList)
            {
                if (commandPair.Value == command)
                    return commandPair.Key;
            }

            return Commands.Unknown;
        }
    }
}
