using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Reflection;
using GhostSS_Clean;

namespace GhostSS
{
    class Dumper
    {

        

        public static int DNSID = 0;
        [Obfuscation(Exclude = true)]
        public static void FoundDNS()
        {
            string query = string.Format(
                "SELECT ProcessId FROM Win32_Service WHERE Name='{0}'",
                "Dnscache");
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
                    // Thrown if the process specified by processId
                    // is no longer running.
                }
                try
                {
                    if (process != null)
                    {
                        DNSID = process.Id;
                    }
                }
                catch (Win32Exception)
                {
                    // Thrown if process is already terminating,
                    // the process is a Win16 exe or the process
                    // could not be terminated.
                }
                catch (InvalidOperationException)
                {
                    // Thrown if the process has already terminated.
                }
            }
        }


        /// <summary>
        ///  Dump
        /// </summary>
        public static string stringsjavaw = "";
        public static string stringsexplorer = "";
        public static string stringslsass = "";
        public static string stringsdwm = "";
        public static string stringsdns = "";

   
        public static void FoundPca()
        {
            if (File.Exists(@"Sayness.PcaClient")) File.Delete(@"Sayness.PcaClient");

            String line;
            String oldLine = "";
            String oldLineA = "";
            String final = "";

            using (var fs = File.OpenRead(Path.GetTempPath() + Utils.RandomFile + @"\" + @"Sayness.explorer"))
            using (var sr = new StreamReader(fs, Encoding.UTF8, true))
            {
                HashSet<String> hash = new HashSet<String>();
                hash.Add(",Time,0");
                using (var sw = new StreamWriter(Path.GetTempPath() + Utils.RandomFile + @"\" + @"Sayness.PcaClient"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (String str in hash)
                        {
                            if (oldLine.Contains(",Time,0") && oldLine.Contains("TRACE,0000,0000,PcaClient,MonitorProcess,"))
                            {
                                //   sw.WriteLine(oldLine);
                                oldLineA = oldLine.Replace("TRACE,0000,0000,PcaClient,MonitorProcess,", "");
                                final = oldLineA.Replace(",Time,0", "");
                                sw.WriteLine(final);
                                sw.WriteLine(line + "\r\n");
                            }
                        }
                        oldLine = line;

                    }
                }
            }
        }

     
        public static string DumpDNS()
        {
            string path = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\", "Ghosting.exe");

            stringsdns = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\", Convert.ToString("Sayness.4"));

            if (File.Exists(path))
            {
                Process proc2 = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + DNSID + " > " + stringsdns
                    }
                };
                proc2.Start();
                proc2.WaitForExit();
                return stringsdns;
            }
            else
            {
                File.WriteAllBytes(path, GhostSS.Properties.Resources.Cat_Hello);
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + DNSID + " > " + stringsdns
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return stringsdns;
            }
        }

  
        public static string DumpJavaw(string process)
        {
            string path = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , "Ghosting.exe");

            stringsjavaw = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , Convert.ToString("Sayness.1"));
            string pid = Process.GetProcessesByName(process)[0].Id.ToString();
            if (File.Exists(path))
            {
                Process proc2 = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsjavaw
                    }
                };
                proc2.Start();
                proc2.WaitForExit();
                return stringsjavaw;
            }
            else
            {
                File.WriteAllBytes(path, GhostSS.Properties.Resources.Cat_Hello);
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsjavaw
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return stringsjavaw;
            }
        }
      
        public static string DumpExplorer(string process)
        {
            string path = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , "Ghosting.exe");

            stringsexplorer = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , Convert.ToString("Sayness.2"));
            string pid = Process.GetProcessesByName(process)[0].Id.ToString();
            if (File.Exists(path))
            {
                Process proc2 = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsexplorer
                    }
                };
                proc2.Start();
                proc2.WaitForExit();
                return stringsexplorer;
            }
            else
            {
                File.WriteAllBytes(path, GhostSS.Properties.Resources.Cat_Hello);
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsexplorer
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return stringsexplorer;
            }
        }
     
        public static string DumpDwm(string process)
        {
            string path = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , "Ghosting.exe");

            stringsdwm = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , Convert.ToString("Sayness.5"));
            string pid = Process.GetProcessesByName(process)[0].Id.ToString();
            if (File.Exists(path))
            {
                Process proc2 = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsdwm
                    }
                };
                proc2.Start();
                proc2.WaitForExit();
                return stringsdwm;
            }
            else
            {
                File.WriteAllBytes(path, GhostSS.Properties.Resources.Cat_Hello);
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringsdwm
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return stringsdwm;
            }
        }
   
        public static string DumpLsass(string process)
        {
            string path = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , "Ghosting.exe");

            stringslsass = Path.Combine(Path.GetTempPath() + Utils.RandomFile + @"\" , Convert.ToString("Sayness.3"));
            string pid = Process.GetProcessesByName(process)[0].Id.ToString();
            if (File.Exists(path))
            {
                Process proc2 = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringslsass
                    }
                };
                proc2.Start();
                proc2.WaitForExit();
                return stringslsass;
            }
            else
            {
                File.WriteAllBytes(path, GhostSS.Properties.Resources.Cat_Hello);
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd",
                        Arguments = "/C" + path + " -clean -scan " + pid + " > " + stringslsass
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return stringslsass;
            }


        }   
    }
}
