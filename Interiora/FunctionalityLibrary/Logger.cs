using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalityLibrary
{
    public delegate void txt(string s);
    public class Logger
    {
        private string log = "";
        private event txt logAppened;
        public Logger()
        {
        }
        public void AppendString(string s)
        {
            log += s + Environment.NewLine;
            logAppened(s+Environment.NewLine);
        }
        public string GetCurrentLog()
        {
            return log;
        }
        public void NewEventHandler(txt e)
        {
            logAppened += e;
        }
    }
}
