using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public interface ILogger : IDisposable
    {
        void Log(params string[] messages);
    }
}
