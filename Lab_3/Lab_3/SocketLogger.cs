using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class SocketLogger : ClientSocket, ILogger
    {
        private ClientSocket clientSocket;

        public SocketLogger(string host, int port) : base(host,port)
        {
            
        }

        ~SocketLogger()
        {
            this.Dispose(false);
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
