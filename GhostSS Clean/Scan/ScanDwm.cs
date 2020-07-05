using GhostSS.model;
using GhostSS_Clean;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GhostSS.Scan
{
    class ScanDwm
    {
        public static void CheckRestart()
        {
            DateTime dwm = Utils.GetProcessStartTime("dwm");
            DateTime winlogon = Utils.GetProcessStartTime("winlogon");


            if (dwm.Minute != winlogon.Minute)
            {
                Utils.DwmRestarted = "Dwm Restarted (at " + dwm + ")";
            }

        }

        [Obfuscation(Exclude = true)]
        public static Processus Scan(string link, string process)
        {
            CheckRestart();
            Processus dwm = new Processus("dwm");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[->]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Check of " + process + " just launched. ");
            List<string> hashlist = new List<string>();
            string path = Dumper.DumpDwm(process);
            Process[] processes = Process.GetProcessesByName("Ghost");
            foreach (Process p in processes)
            {
                p.PriorityClass = ProcessPriorityClass.RealTime;
            }
            var sr = new StreamReader(File.OpenRead(path));
            var sw = new StreamWriter(File.OpenWrite(path + "5"));
            Main.CopyLinesRemovingAllDupes(sr, sw);
            sw.Close();
            sr.Close();
           System.IO.File.Delete(path);
            WebClient w = new WebClient();
            using (Stream stream = w.OpenRead(link))
            {
                using (BufferedStream bs = new BufferedStream(stream))
                {
                    using (StreamReader streamReader = new StreamReader(bs))
                    {
                        // Scanning
                        string linha;
                        while ((linha = streamReader.ReadLine()) != null)
                        {
                            string str = linha.Split(new char[]
                            {
                                    'Љ'
                            })[0];
                            string cheat = linha.Split(new char[]
                            {
                                   'Љ'
                            })[1];
                            hashlist.Add(str);
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[->]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Scanning the " + process + "...");
                    }
                }
            }

            string result = "";
            List<string> fff = new List<string>();
            Console.ForegroundColor = ConsoleColor.White;
            using (FileStream fileStream = File.Open(path + "5", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamReader streamReader = new StreamReader(bufferedStream))
                    {
                        string line;

                        while ((line = streamReader.ReadLine()) != null)
                        {

                            line = "7xzjxzC3&yU&Tf&#SQKsPmy&KkFc!Chm25pJJmY5" + line + "FwxX_%rJPTdt5e7P_fGL4WSAwdpsCG#8AAyZDs!y";
                            line = Main.hash(line);
                            foreach (string hash in hashlist.ToList())
                            {
                                if (hash.Equals(line))
                                {
                                    hashlist.Remove(hash);
                                    string clientfound = Main.DetectClient(link, line);

                                    if (!result.Contains(Main.Decrypt(clientfound, 1000)))
                                    {
                                        Console.WriteLine(line);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("[->]");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(" Client Found: " + Main.Decrypt(clientfound, 1000) + "\n");
                                        dwm.results.Add(new Result(Main.Decrypt(clientfound, 1000)));
                                        result = result + Main.Decrypt(clientfound, 1000) + "-";



                                    }

                                }
                            }

                        }
                    }
                }
            }
            Console.WriteLine(result);


            if (result == "")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[->]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Nothing Found " + "\n");
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\Cat_Hello.exe");
                System.IO.File.Delete(path + "5");
                Main.Check = Main.Check + 1;
                Main.checkfile = false;
                return dwm;
            }
            else
            {
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\Cat_Hello.exe");
                System.IO.File.Delete(path + "5");
                Main.Check = Main.Check + 1;
                Main.checkfile = false;
                return dwm;
            }
        }
    }
}
