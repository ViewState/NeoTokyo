using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using NeoTokyo.ProductionBook.Logging;

namespace NeoTokyo.ProductionBook.DAL
{
    public class ProductionBookInterceptorLogging : DbCommandInterceptor
    {
        private ILogger _logger = new Logger();
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<Object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<Object> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                _logger.Error(interceptionContext.Exception, "Error executing command: ", command.CommandText);
            }
            else
            {
                _logger.TraceApi("SQL Database", "ProductionBookInterceptorLogging.ScalarExecuted", _stopwatch.Elapsed, "Command: {0}", command.CommandText);
            }
            base.ScalarExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                _logger.Error(interceptionContext.Exception, "Error executing command: ", command.CommandText);
            }
            else
            {
                _logger.TraceApi("SQL Database", "ProductionBookInterceptorLogging.ReaderExecuted", _stopwatch.Elapsed, "Command: {0}", command.CommandText);
            }
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<Int32> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            _stopwatch.Restart();
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<Int32> interceptionContext)
        {
            _stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                _logger.Error(interceptionContext.Exception, "Error executing command: ", command.CommandText);
            }
            else
            {
                _logger.TraceApi("SQL Database", "ProductionBookInterceptorLogging.NonQueryExecuted", _stopwatch.Elapsed, "Command: {0}", command.CommandText);
            }
            base.NonQueryExecuted(command, interceptionContext);
        }
    }
}