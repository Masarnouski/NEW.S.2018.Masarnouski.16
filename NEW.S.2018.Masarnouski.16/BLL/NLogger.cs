using NLog;
using System;
using BLL.Interfaces.Interfaces;

namespace BLL
{
    public class NLogger: Interfaces.Interfaces.ILogger
    {
        private Logger logger;

        public NLogger(Type type)
        {
            if (ReferenceEquals(type, null))
            {
                throw new ArgumentNullException(nameof(type));
            }

            this.logger = LogManager.GetLogger(type.Name);
        }

        public void Debug(string message)
        {
            this.logger.Debug(message);
        }

        
        public void Debug(Exception exception, string message)
        {
            this.logger.Debug(exception, message);
        }

       
        public void Error(string message)
        {
            this.logger.Error(message);
        }

       
        public void Error(Exception exception, string message)
        {
            this.logger.Error(exception, message);
        }

       
        public void Fatal(string message)
        {
            this.logger.Fatal(message);
        }

       
        public void Fatal(Exception exception, string message)
        {
            this.logger.Fatal(exception, message);
        }

        
        public void Info(string message)
        {
            this.logger.Info(message);
        }

        
        public void Info(Exception exception, string message)
        {
            this.logger.Info(exception, message);
        }

        
        public void Trace(string message)
        {
            this.logger.Trace(message);
        }

        
        public void Trace(Exception exception, string message)
        {
            this.logger.Trace(exception, message);
        }

        
        public void Warn(string message)
        {
            this.logger.Warn(message);
        }


        public void Warn(Exception exception, string message)
        {
            this.logger.Warn(exception, message);
        }
    }
}
