using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Net;

namespace Roni.Communication.RoniDataSocket
{
    public class Client
    {
        private NationalInstruments.Net.DataSocket _ds;
        public NationalInstruments.Net.DataSocket DS
        {
            get { return _ds; }
            set { _ds = value; }
        }

        private System.ComponentModel.IContainer _components;

        public Client(System.ComponentModel.IContainer componets)
        {
             _components = componets;
             this._ds = new NationalInstruments.Net.DataSocket(this._components);
        }

        public void BeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this._ds)).BeginInit();
        }

        public void EndInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this._ds)).EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoConnect { set; get; }

        /// <summary>
        /// 
        /// </summary>
        private ConnectionStatusUpdatedEventHandler _ConnectionStatusEventHandler=null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventHandler"></param>
        public void RegisterConnectionStatusUpdated(ConnectionStatusUpdatedEventHandler eventHandler )
        {
            _ConnectionStatusEventHandler = eventHandler;
        }


        /// <summary>
        /// 
        /// </summary>
        private NationalInstruments.Net.DataUpdatedEventHandler _DataUpdatedEventHandler=null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventHandler"></param>
        public void RegisterDataUpdated(DataUpdatedEventHandler eventHandler)
        {
            _DataUpdatedEventHandler = eventHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, object> _dataAttributes = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        public void AddDataAttributes(string name, object obj)
        {
            _dataAttributes.Add(name, obj);
        }

        public void Init()
        {
            BeginInit();
            this._ds.AutoConnect = AutoConnect;

            if (_ConnectionStatusEventHandler != null)
            {
                this._ds.ConnectionStatusUpdated += new NationalInstruments.Net.ConnectionStatusUpdatedEventHandler(_ConnectionStatusEventHandler);
            }

            if (_DataUpdatedEventHandler!=null)
            {
                this._ds.DataUpdated += new DataUpdatedEventHandler(_DataUpdatedEventHandler);

            }
            if (_dataAttributes.Count != 0)
            {
                foreach (var v in _dataAttributes)
                {
                    this._ds.Data.Attributes.Add(v.Key, v.Value);
                }
            
            }
            
            EndInit();
        
        
        }
    }
}
