namespace Gunit.Core.Logging
{
    public enum Level
    {
        // turn on when additional detail is needed
        Debug = 1,

        // not too verbose, useful to show output in unit tests to assist tracing logic flow
        Info = 2,

        // unexepected, most likely only used by Gunit
        Error = 3,

        // disable all logging
        Off = 4

    }
}