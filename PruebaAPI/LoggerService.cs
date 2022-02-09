using Serilog;

namespace PruebaAPI
{
    public class LoggerService
    {
        private readonly Serilog.ILogger log;

        public LoggerService(IConfiguration configuration)
        {
            string path = configuration.GetSection("Logging")["LogFile"].ToString();
            log = new LoggerConfiguration()
                .WriteTo.File(path, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14)
                .CreateLogger();
        }

        public void Info(string msg)
        {
            log.Information(msg);
        }

        public void Error(string msg)
        {
            log.Error(msg);
        }

        public void Error(Exception ex, string msg)
        {
            log.Error(ex, msg);
        }
    }
}
