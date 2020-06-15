using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CMDHelper
{
    public class Instance
    {
        private readonly ProcessStartInfo PROCES_INFO;

        public Instance((string key, string value)[] EnvironmentVariable = null, bool createNoWindow = true, bool redirectStandardOutput = true)
        {
            PROCES_INFO = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = redirectStandardOutput,
                CreateNoWindow = createNoWindow
            };
            SetEnvVariables___(EnvironmentVariable);
        }

        public List<string> Run(string command)
        {
            return Run___(command);
        }

        private List<string> Run___(string command)
        {
            List<string> ret = new List<string>();

            PROCES_INFO.Arguments = "/C " + command;

            var proc = new Process()
            {
                StartInfo = PROCES_INFO
            };

            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                ret.Add(proc.StandardOutput.ReadLine());
            }

            if (proc.ExitCode != 0)
            {
                throw new Exception($"Exit code: '{proc.ExitCode}' for command: '{command}'");
            }

            return ret;
        }

        private void SetEnvVariables___((string key, string value)[] EnvVariable)
        {
            if (EnvVariable == null)
            {
                return;
            }

            foreach (var item in EnvVariable)
            {
                if (PROCES_INFO.EnvironmentVariables.ContainsKey(item.key))
                {
                    var value = PROCES_INFO.EnvironmentVariables[item.key];

                    PROCES_INFO.EnvironmentVariables.Remove(item.key);

                    PROCES_INFO.EnvironmentVariables.Add(item.key,
                        $"{value};{item.value}"
                    );
                }
                else
                {
                    PROCES_INFO.EnvironmentVariables.Add(item.key, item.value);
                }
            }
        }
    }
}
