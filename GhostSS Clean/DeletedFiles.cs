using GhostSS_Clean;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostSS
{
    class DeletedFiles
    {
        public static List<string> FileDeleted = new List<string>();
        public static void FoundPca()
        {
            //if (File.Exists(@"Sayness.PcaClient")) File.Delete(@"Sayness.PcaClient");
            String final = "";
            String line;
            String oldLine = "";
            String oldLineA = "";
            String L = "";
            using (var fs = File.OpenRead(Path.GetTempPath() + Utils.RandomFile + @"\" + @"Sayness.22"))
            using (var sr = new StreamReader(fs, Encoding.UTF8, true))
            {
                HashSet<String> hash = new HashSet<String>();
                hash.Add(",Time,0");

                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (String str in hash)
                        {
                            if (oldLine.Contains(",Time,0") && oldLine.Contains("TRACE,0000,0000,PcaClient,MonitorProcess,"))
                            {
                                //   sw.WriteLine(oldLine);
                                oldLineA = oldLine.Replace("TRACE,0000,0000,PcaClient,MonitorProcess,", "");
                                final = oldLineA.Replace(",Time,0", "");

                                List<string> splitted = new List<string>(final.Split('\n'));

                                foreach (string fdp in splitted)
                                {
                                    if (!File.Exists(fdp.ToString()))
                                    {
                                            FileDeleted.Add("Found Deleted Files: " + fdp);
                                    }
                                }

                              
                                // sw.WriteLine(line + "\r\n");
                            }
                        
                        oldLine = line;

                    }
                }
            }
        }
    }
}
