using System;
using System.Diagnostics;
using System.Text;

namespace NeoTokyo.ProductionBook.Logging
{
    public class Logger : ILogger
    {
        public void Information(String message)
        {
            Trace.TraceInformation(message);
        }

        public void Information(String fmt, params Object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Warning(String message)
        {
            Trace.TraceWarning(message);
        }

        public void Warning(String fmt, params Object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceWarning(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Error(String message)
        {
            Trace.TraceError(message);
        }

        public void Error(String fmt, params Object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan)
        {
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan, String properties)
        {
            String message = String.Concat("Compnent: ", componentName, ";Method: ", method, ";TimeSpan: ",
                timespan.ToString(), ";Properties: ", properties);
            Trace.TraceInformation(message);
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan, String fmt, params Object[] vars)
        {
            TraceApi(componentName, method, timespan, String.Format(fmt, vars));
        }

        private String FormatExceptionMessage(Exception exception, String fmt, Object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see 
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4
            var sb = new StringBuilder();
            sb.Append(string.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }

    }
}