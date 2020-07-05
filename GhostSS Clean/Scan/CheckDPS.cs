using GhostSS_Clean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhostSS.Scan
{
    class CheckDPS
    {
        public static string ResultDPS;
        public static string ResultPCA;
        [Obfuscation(Exclude = true)]

        public static int DPSID = 0;
        public static int PCAID = 0;
        public static void FoundDPSProcess()
        {
            string query = string.Format(
                "SELECT ProcessId FROM Win32_Service WHERE Name='{0}'",
                "DPS");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject obj in searcher.Get())
            {
                uint processId = (uint)obj["ProcessId"];
                Process process = null;
                try
                {
                    process = Process.GetProcessById((int)processId);
                }
                catch (ArgumentException)
                {
                    ResultDPS = "Generic Self Destruct";
                }
                try
                {
                    if (process != null)
                    {
                        DateTime dps = Utils.GetProcessStartTime(process.ProcessName);
                        DateTime wininit = Utils.GetProcessStartTime("wininit");


                        if (dps.Minute != wininit.Minute)
                        {
                            ResultDPS = "Generic Self Destruct";
                        }
                        else
                        {
                            ResultDPS = "Clean";
                        }
                    }
                }
                catch (Win32Exception)
                {
                    ResultDPS = "Generic Self Destruct";
                }
                catch (InvalidOperationException)
                {
                    ResultDPS = "Generic Self Destruct";
                }
            }
        }

        public static void FoundPCAProcess()
        {
            string query = string.Format(
                "SELECT ProcessId FROM Win32_Service WHERE Name='{0}'",
                "PcaSvc");
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject obj in searcher.Get())
            {
                uint processId = (uint)obj["ProcessId"];
                Process process = null;
                try
                {
                    process = Process.GetProcessById((int)processId);
                }
                catch (ArgumentException)
                {
                    ResultPCA = "Generic Self Destruct";
                }
                try
                {
                    if (process != null)
                    {
                        DateTime pca = Utils.GetProcessStartTime(process.ProcessName);
                        DateTime wininit = Utils.GetProcessStartTime("wininit");


                        if (pca.Minute != wininit.Minute)
                        {
                            ResultPCA = "Generic Self Destruct";
                        }
                        else
                        {
                            ResultPCA = "Clean";
                        }
                    }
                }
                catch (Win32Exception)
                {
                    ResultPCA = "Generic Self Destruct";
                }
                catch (InvalidOperationException)
                {
                    ResultPCA = "Generic Self Destruct";
                }
            }
        }

    }

}
