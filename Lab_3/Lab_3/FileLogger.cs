using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_3
{
    public class FileLogger : WriterLogger
    {
        bool disposed;
        protected FileStream stream;
        string path;

        ~FileLogger()
        {
            this.Dispose();
        }

        public override void Dispose(bool disposing)
        {
            stream.Dispose();
            path = null;
            disposed = true;
        }

        public FileLogger(string path)
        {
            this.path = path;
        }
    }
}
