using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkJohansen
{
    public class ConfigurationManager
    {
        public ConfigurationManager() { }
        public ConfigurationManager(string location)
        {
        }

        public static ConfigurationManager Load(string location){
            return null;


        }

        public void Save(string location){
        }
    }

    public class ConfigurationItem
    {
        public string key;
        public string value;
        public string type;

        public ConfigurationItem(string key, object value)
        {
            this.key = key;
            this.value = value.ToString();
            this.type = value.GetType().ToString();
        }
    }
}
