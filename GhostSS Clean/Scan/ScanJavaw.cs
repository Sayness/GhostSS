
using GhostSS.model;
using GhostSS_Clean;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GhostSS
{
    class ScanJavaw
    {
     
      
        [Obfuscation(Exclude = true)]
        public static Processus Scan(string link, string process)
        {
            Processus javaw = new Processus("javaw");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[->]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Check of " + process + " just launched. ");
            List<string> hashlist = new List<string>();
            string path = Dumper.DumpJavaw(process);
            Process[] processes = Process.GetProcessesByName("Ghost");
            foreach (Process p in processes)
            {
                p.PriorityClass = ProcessPriorityClass.RealTime;
            }
            var sr = new StreamReader(File.OpenRead(path));
            var sw = new StreamWriter(File.OpenWrite(path + "1"));
            Main.CopyLinesRemovingAllDupes(sr, sw);
            //Main.RemoveLong(sr, sw);
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
                                    '='
                            })[0];
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
            using (FileStream fileStream = File.Open(path + "1", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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

                                    /* if (!fff.Contains(line))
                                     {
                                         fff.Add(line);*/
                                    string clientfound = Main.DetectClient(link, line);

                                    if (!result.Contains(Main.Decrypt(clientfound, 1000)))
                                    {
                                        Console.WriteLine(line);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("[->]");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(" Client Found: " + Main.Decrypt(clientfound, 1000) + "\n");
                                        javaw.results.Add(new Result(Main.Decrypt(clientfound, 1000)));
                                        result = result + Main.Decrypt(clientfound, 1000) + "-";
                                    }
                                    //}
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
                System.IO.File.Delete(path + "1");
                Main.Check = Main.Check + 1;
                Main.checkfile = false;
                return javaw;
            }
            else
            {
                System.IO.File.Delete(@"C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Temp\\Cat_Hello.exe");
                System.IO.File.Delete(path + "1");
                Main.Check = Main.Check + 1;
                Main.checkfile = false;
                return javaw;
            }
        }
    }
}
