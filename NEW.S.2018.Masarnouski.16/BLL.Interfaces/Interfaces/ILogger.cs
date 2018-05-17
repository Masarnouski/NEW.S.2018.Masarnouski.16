using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Interfaces
{
    public interface ILogger
    {
        void Debug(string message);

        void Debug(Exception exception, string message);

        void Error(string message);

        void Error(Exception exception, string message);

        void Fatal(string message);

        void Fatal(Exception exception, string message);

        void Info(string message);

        void Info(Exception exception, string message);

        void Trace(string message);

        void Trace(Exception exception, string message);

        void Warn(string message);

        void Warn(Exception exception, string message);
    }
}
