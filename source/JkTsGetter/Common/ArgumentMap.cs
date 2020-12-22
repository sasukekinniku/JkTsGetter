using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// こういうのを探していた。つかわせていただきました
// https://github.com/mik-claire/MikLib
// https://qiita.com/mik_claire/items/87ee5880d5fd79db9d16
namespace MikLib.Util
{
    public class ArgumentMap
    {
        private List<string> mainArgs = new List<string>();
        private Dictionary<string, string> optionMap = new Dictionary<string, string>();
        private List<string> optionSwitches = new List<string>();

        public void Init(string[] args)
        {
            int i = 0;
            while (i < args.Length)
            {
                string arg = args[i];
                if (arg.StartsWith("-"))
                {
                    if (i + 1 < args.Length)
                    {
                        if (args[i + 1].StartsWith("-"))
                        {
                            this.optionSwitches.Add(args[i]);
                        }
                        else
                        {
                            this.optionMap[arg] = args[i + 1];
                            i++;
                        }
                    }
                    else
                    {
                        this.optionSwitches.Add(args[i]);
                    }
                }
                else
                {
                    this.mainArgs.Add(arg);
                }

                i++;
            }
        }

        public List<string> GetMainArgs()
        {
            return this.mainArgs;
        }

        public bool HasSwitch(string key)
        {
            return this.optionSwitches.Contains(key);
        }

        public string GetOption(string key, string defaultValue = null)
        {
            if (this.optionMap.ContainsKey(key))
            {
                return this.optionMap[key];
            }

            return defaultValue;
        }

        public int GetOptionInt(string key, int defaultValue)
        {
            if (this.optionMap.ContainsKey(key))
            {
                string value = this.optionMap[key];
                int intValue = defaultValue;
                if (int.TryParse(value, out intValue))
                {
                    return intValue;
                }
            }

            return defaultValue;
        }

        public bool GetOptionBool(string key, bool defaultValue)
        {
            if (this.optionMap.ContainsKey(key))
            {
                string value = this.optionMap[key];
                bool boolValue = defaultValue;
                if (bool.TryParse(value, out boolValue))
                {
                    return boolValue;
                }
            }

            return defaultValue;
        }
    }
}
