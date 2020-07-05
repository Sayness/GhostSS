using GhostSS_Clean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhostSS
{
    class Protection
    {
      

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibraryA([MarshalAs(UnmanagedType.LPStr)] string library);
    

        //Check si une sandbox est présente
        public static void CheckSandbox()
        {
            if (LoadLibraryA("SbieDll.dll") != IntPtr.Zero || LoadLibraryA("sbie.dll") != IntPtr.Zero)
            {
                MessageBox.Show("Virtual Machine or Sandbox Tool Detected", "GhostSS - Protection");
                Application.Exit();
            }
        }

        public static ProcessModule find_module(Process p, string module_str)
        {
            foreach (ProcessModule modu in p.Modules)
            {
                if (modu.FileName.ToLower().Contains(module_str.ToLower()))
                    return modu;
            }
            return null;
        }
        public static void CheckIllegalProcess()
        {

            var ps = Process.GetProcesses();

            foreach (var p in ps)
            {
                try
                {
                    var desc = FileVersionInfo.GetVersionInfo(p.MainModule.FileName);
                    if (p.MainModule.ModuleName.Contains("dnSpy"))
                    {
                        p.Kill();
                    }

                    if (p.MainModule.ModuleName.Contains("HTTPDebugger"))
                    {
                        p.Kill();
                    }

                    if (p.MainModule.ModuleName.Contains("dnlib"))
                    {
                        p.Kill();
                    }

                    if (p.MainModule.ModuleName.Contains("smash"))
                    {
                        p.Kill();
                    }

                    if (desc.FileDescription.Contains("x64dbg"))
                    {
                        p.Kill();
                    }

                    if (desc.FileDescription.Contains("x32dbg"))
                    {
                        p.Kill();
                    }

                    if (desc.FileDescription.Contains("Dumper"))
                    {
                        p.Kill();
                    }

                    if (desc.FileDescription.Contains("Cheat Engine"))
                    {
                        p.Kill();
                    }

                    if (desc.FileDescription.Contains("Process Hacker"))
                    {
                        p.Kill();
                    }
                }
                catch
                {

                }
            }



        }

        public static void CheckParent()
        {
            Process currentProcess = Process.GetCurrentProcess();
            int pid = currentProcess.Id;
            Process[] processes = Process.GetProcessesByName("explorer");
            foreach (Process p in processes)
            {
                int explorerpid = p.Id;
                int final = Process.GetProcessById(pid).Parent().Id;
                if (final != explorerpid)
                {
                    Process.Start(new ProcessStartInfo("cmd.exe", "/c START CMD /C \" TITLE GhostSS - Protection && ECHO Please Contact Support, launch not authorized && TIMEOUT 10\"")
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
       
    }
}
