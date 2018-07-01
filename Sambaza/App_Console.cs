using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sambaza
{
    class App_Console
    {
        #region  Console_command
        public string UserConsole(string command_str, string args)
        {

            string output = string.Empty;

            ProcessStartInfo processStartInfo = new ProcessStartInfo(command_str, args);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.UseShellExecute = false;

            processStartInfo.CreateNoWindow = true;

            Process proc = new Process
            {
                StartInfo = processStartInfo
            };

            proc.Start();

            output = proc.StandardOutput.ReadToEnd();


            return output;

        }
        #endregion
    }
}
