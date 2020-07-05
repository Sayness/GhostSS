using GhostSS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhostSS_Clean
{
    class Utils
    {

        public static string RandomFile = Path.GetRandomFileName();
        public static string ExplorerRestarted = "No";
        public static string DwmRestarted = "No";
        public static string getIPinfo()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }


        }


        public static void CheckClipBoardPIN()
        {
                string text = Clipboard.GetText(TextDataFormat.Text);
    
                if (text.Contains("1") || text.Contains("2") || text.Contains("3") || text.Contains("4") || text.Contains("5") || text.Contains("6") || text.Contains("7") || text.Contains("8") || text.Contains("9") || text.Contains("0"))
                {
         

                }
               else
            {
          
                text = null;
            }
         
        }
        public static string Username;

        public static string getCommandLines(Process processs)
        {
            var commandLineSearcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + processs.Id);
            string commandLine = "";
            foreach (ManagementObject commandLineObject in commandLineSearcher.Get())
                commandLine += Convert.ToString(commandLineObject["CommandLine"]);
            return commandLine;
        }

        public static string User1;
        public static string UsernameMC;
        public static void getMinecraftInfo()
        {
            var javaw = Process.GetProcessesByName(Main.minecraft) ;
            foreach (Process proc in javaw)
            {
                string[] arguments = getCommandLines(proc).Split(new[] { " --" }, StringSplitOptions.None);

                var count = 0;
                foreach (string test in arguments)
                {
                    if (test.Contains("username"))
                    {
                        User1 = arguments.ElementAt(count);
                        UsernameMC = User1.Replace("username", null);
                    }
                       

                    count += 1;
                }

            }

        }



        public static string GetStringBetween(string strBegin, string strEnd, string strSource)
        {
            string[] result = { string.Empty, string.Empty };
            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {
                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
                    result[0] = strSource.Substring(0, iEnd);
                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);
                }
            }
            else
                result[1] = strSource;
            return result[0];
        }


        public static DateTime GetProcessStartTime(string processName)
		{
			Process[] p = Process.GetProcessesByName(processName);
			if (p.Length <= 0) throw new Exception("Process not found!");
			return p[0].StartTime;
		}
		public static void Delete(int Timeout)
        {
            System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe")
            {
                Arguments = string.Concat(new string[] { "/C ping 1.1.1.1 -n 1 -w ", Timeout.ToString(), " > Nul & Del \"", Application.ExecutablePath, "\"" }),
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(processStartInfo);
        }
	
		public static object RunCMD(string command, bool ShowWindow = false, bool permanent = false)
		{
			Process process = new Process();
			ProcessStartInfo pi = new ProcessStartInfo();
			pi.Arguments = " " + ((ShowWindow && permanent) ? "/K" : "/C") + " " + command;
			pi.FileName = "cmd.exe";
			pi.CreateNoWindow = !ShowWindow;
			pi.RedirectStandardInput = false;
			pi.RedirectStandardOutput = true;
			pi.UseShellExecute = false;
			if (ShowWindow)
			{
				pi.WindowStyle = ProcessWindowStyle.Normal;
			}
			else
			{
				pi.WindowStyle = ProcessWindowStyle.Hidden;
			}
			process.StartInfo = pi;
			return process;
		}

     
    }
}
