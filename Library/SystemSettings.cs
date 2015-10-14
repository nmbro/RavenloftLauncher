using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public static class SystemSettings
    {
        private static bool debug = false;


        public static bool isDebuggingEnabled
        {
            get { return debug; }
            set { debug = value; }
        }
    }
}
