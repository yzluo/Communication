using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Net;

namespace Roni.Communication.RoniDataSocket
{
    public class Server
    {
        private DataSocketServer _dsServer;
        private System.ComponentModel.IContainer _components;

        public Server(System.ComponentModel.IContainer componets)
        {
            _components = componets;
            this._dsServer = new NationalInstruments.Net.DataSocketServer(this._components);
            ((System.ComponentModel.ISupportInitialize)(this._dsServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsServer)).EndInit();

        }
    }
}
