using System;
using System.Collections.Generic;
using System.Text;

namespace AjaxPro.Configuration
{
    public delegate T Func<T>();

    public class HandlerConfiguration
    {
        private static Func<AjaxProDefaultSettings> _defaultSettings;

        public static Func<AjaxProDefaultSettings> DefaultSettings
        {
            get { return _defaultSettings; }
            set { _defaultSettings = value; }
        }

        static HandlerConfiguration()
        {
            DefaultSettings = SetDefault;
        }

        static AjaxProDefaultSettings SetDefault()
        {
            return new AjaxProDefaultSettings();
        }
    }

    public class AjaxProDefaultSettings
    {
        public delegate void CusEventHandler(object sender, HandlerEventArgs e);

        public event CusEventHandler PreHandlerExecute;
        public event CusEventHandler PostHandlerExecute;

        internal void OnPreHandlerExecute(HandlerEventArgs e)
        {
            if (PreHandlerExecute != null)
                PreHandlerExecute(this, e);
        }

        internal void OnPostHandlerExecute(HandlerEventArgs e)
        {
            if (PostHandlerExecute != null)
                PostHandlerExecute(this, e);
        }
    }

    public class HandlerEventArgs : EventArgs
    {
        private string _methodName;
        private string _args;

        public string MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        public string Args
        {
            get { return _args; }
            set { _args = value; }
        }
    }
}
