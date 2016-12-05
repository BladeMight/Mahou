using NLog;
using NLog.Config;
using NLog.Targets;

namespace Mahou {
    internal class LogHelper {
        public static void ConfigureNlog() {         // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            fileTarget.FileName = "${basedir}/logs/${shortdate}.log";
            fileTarget.Layout = @"${longdate} ${uppercase:${level}} ${message} ${exception:format=toString}";

            LoggingRule rule2;
#if DEBUG
            rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
#else
            rule2= new LoggingRule("*", LogLevel.Warn, fileTarget);
#endif
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
        }
    }
}