using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class CommonLogger : ILogger
    {
        ILogger[] loggers = new ILogger[];

        public CommonLogger(ILogger[] loggers)
        {

        }

        public void Log(params string[] messages)
        {

        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
