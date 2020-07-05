using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GhostSS;
using GhostSS.API;
using GhostSS.model;
using GhostSS.Scan;
using GhostSS_Clean;
using Newtonsoft.Json;

namespace GhostSS_Clean
{
    public partial class Main : Form
    {
        private List<Processus> listProcessus;
        public Main()
        {
            InitializeComponent();
            listProcessus = new List<Processus>();
        }

      
        internal void hbwait(long ms_to_wait)
        {
            double endwait = 0;
            endwait = Environment.TickCount + ms_to_wait;
            while (Environment.TickCount < endwait)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
        }
        [Obfuscation(Exclude = true)]
        public static void CopyLinesRemovingAllDupes(TextReader reader, TextWriter writer)
        {
            string currentLine;
            HashSet<string> previousLines = new HashSet<string>();

            while ((currentLine = reader.ReadLine()) != null)
            {
                if (currentLine.Length > 50)
                {
                    currentLine.Replace(currentLine, "");
                }
                if (previousLines.Add(currentLine))
                {
                    writer.WriteLine(currentLine);
                }
            }
        }
        [Obfuscation(Exclude = true)]
        public static void RemoveLong(TextReader reader, TextWriter writer)
        {
            HashSet<string> previousLines = new HashSet<string>();
            string currentLine;       

            while ((currentLine = reader.ReadLine()) != null)
            {
     

                if (currentLine.Length > 20)
                {
                    previousLines.Add(currentLine);
                    writer.WriteLine(previousLines.ToString()) ;
                }
              
            }
        }

        [Obfuscation(Exclude = true)]
        public static string DetectClient(string link, string hash)
        {
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
                            if (str.Equals(hash)
)
                            {

                                return cheat;
                            }
                        }
                    }
                }
            }
            return "";
        }
        [Obfuscation(Exclude = true)]
        public static string Decrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }
        [Obfuscation(Exclude = true)]
       
        public static string hash(string input)
        {

            using (SHA512Cng sha1 = new SHA512Cng())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
              
                }
                return sb.ToString();
            }
         
        }


        public static string VPN = null;
        public void CheckVPN()
        {
            string IPInfo = Utils.getIPinfo();
            string ASN = Utils.GetStringBetween("as\":\"", "\"", IPInfo);
            string asn_number = ASN.Split(' ')[0].Replace("AS", "");

            using (WebClient wc = new WebClient())
            {
                string vpnlist = wc.DownloadString("http://say-industries.eu/GhostSS/VPN");

                if (vpnlist.Contains(asn_number + ","))
                {
                    VPN = "Connected";
                }
                else
                {
                    VPN = "Not Connected";

                }
            }

            

        }
        public void LaunchJavaw()
        {
            listProcessus.Add(ScanJavaw.Scan("http://ghostss.say-industries.eu/strings/ghostss/v3/javaw.txt", minecraft));
        }
     
        public void LaunchExplorer()
        {
            listProcessus.Add(ScanExplorer.Scan("http://ghostss.say-industries.eu/strings/ghostss/v3/explorer.txt", "explorer"));
        }
      
        public void LaunchLsasss()
        {
            listProcessus.Add(ScanLsass.Scan("http://ghostss.say-industries.eu/strings/ghostss/v3/lsass.txt", "lsass"));
        }
      
        public void LaunchDNS()
        {
            listProcessus.Add(ScanDNS.Scan("http://ghostss.say-industries.eu/strings/ghostss/v3/dns.txt"));
        }
        
        public void LaunchDwm()
        {
            listProcessus.Add(ScanDwm.Scan("http://ghostss.say-industries.eu/strings/ghostss/v3/dwm.txt", "dwm"));
        }
      
    
        public static string minecraft = null;
      
        public void LauncHScan()
        {
            CoolDown.Enabled = true;
            checkfile = false;
            timer1.Enabled = true;
            Utils.getMinecraftInfo();
            label9.Text = "Check #1 is in progress...";

            if (minecraft != "Not Found")
            {
                Thread thr1 = new Thread(LaunchJavaw);
                thr1.Start();
            }
            else
            {
                Check = Check + 1;
            }
            Thread thr2 = new Thread(LaunchExplorer);
            Thread thr3 = new Thread(LaunchLsasss);
            Thread thr4 = new Thread(LaunchDwm);
            Thread thr5 = new Thread(LaunchDNS);
            thr2.Start();
            thr3.Start();
            thr4.Start();
            thr5.Start();


               
        }
      
        public void CheckMC()
        {
            Process[] MinecraftNormal = Process.GetProcessesByName("javaw");
            Process[] Pactify = Process.GetProcessesByName("Pactify");
            Process[] PvpLounge = Process.GetProcessesByName("launcher");
            Process[] CheatBreaker = Process.GetProcessesByName("java");
            if (MinecraftNormal.Length > 0)
            {
                foreach (Process p in MinecraftNormal)
                {
                    bool check = false;
                    bool check_type_1 = false;
                    bool check_type_2 = false;
                    bool check_type_3 = false;
                    try
                    {
                        foreach (ProcessModule current_module in p.Modules)
                        {
                            if (current_module.ModuleName.Equals("jvm.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_1 = true;
                            }
                            else if (current_module.ModuleName.Equals("java.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_2 = true;
                            }
                            else if (current_module.ModuleName.StartsWith("lwjgl", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_3 = true;
                            }

                            if (check_type_1 && check_type_2 && check_type_3)
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (check)
                    {
                        minecraft = p.ProcessName;
                        LauncHScan();
                    }
                }
            }
           else if (PvpLounge.Length > 0)
            {
                foreach (Process p in PvpLounge)
                {
                    bool check = false;
                    bool check_type_1 = false;
                    bool check_type_2 = false;
                    bool check_type_3 = false;
                    try
                    {
                        foreach (ProcessModule current_module in p.Modules)
                        {
                            if (current_module.ModuleName.Equals("jvm.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_1 = true;
                            }
                            else if (current_module.ModuleName.Equals("java.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_2 = true;
                            }
                            else if (current_module.ModuleName.StartsWith("lwjgl", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_3 = true;
                            }

                            if (check_type_1 && check_type_2 && check_type_3)
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (check)
                    {
                        minecraft = p.ProcessName;
                        LauncHScan();
                    }
                }
            }
            else if (Pactify.Length > 0)
            {
                foreach (Process p in Pactify)
                {
                    bool check = false;
                    bool check_type_1 = false;
                    bool check_type_2 = false;
                    try
                    {
                        foreach (ProcessModule current_module in p.Modules)
                        {
                            if (current_module.ModuleName.Equals("jvm.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_1 = true;
                            }
                            else if (current_module.ModuleName.Equals("java.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_2 = true;
                            }

                            if (check_type_1 && check_type_2)
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (check)
                    {
                        minecraft = p.ProcessName;
                        LauncHScan();
                    }
                }
            }
            else if (CheatBreaker.Length > 0)
            {
                foreach (Process p in CheatBreaker)
                {
                    bool check = false;
                    bool check_type_1 = false;
                    bool check_type_2 = false;
                    bool check_type_3 = false;
                    try
                    {
                        foreach (ProcessModule current_module in p.Modules)
                        {
                            if (current_module.ModuleName.Equals("jvm.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_1 = true;
                            }
                            else if (current_module.ModuleName.Equals("java.dll", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_2 = true;
                            }
                            else if (current_module.ModuleName.StartsWith("lwjgl", StringComparison.CurrentCultureIgnoreCase))
                            {
                                check_type_3 = true;
                            }

                            if (check_type_1 && check_type_2 && check_type_3)
                            {
                                check = true;
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (check)
                    {
                        minecraft = p.ProcessName;
                        LauncHScan();
                    }
                }
            }
            else
            {
                label9.Text = "Minecraft Not Found, GhostSS Launch The Scan...";
                hbwait(3000);
                minecraft = "Not Found";
                LauncHScan();
            }
        }
       
        public static void GhostDownload()
        {
          
            using (var clienta = new WebClient())
            {
                string se = @"http://ghostss.me/Ghosting.exe";
                WebRequest.DefaultWebProxy = null;
                clienta.DownloadFile(new Uri(se), Path.GetTempPath() + Utils.RandomFile + @"\" + "Ghosting.exe");
            }
        }
       

        private void Main_Load(object sender, EventArgs e)
        {
            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = ProcessPriorityClass.RealTime;


      
            this.Show();
            timer1.Enabled = true;
            label9.Text = "Downloading Modules...";

            PB.Enabled = true;

            Directory.CreateDirectory(Path.GetTempPath() + Utils.RandomFile);
            CheckVPN();
            GhostDownload();
           
            hbwait(3000);
            CheckDPS.FoundDPSProcess();
            CheckDPS.FoundPCAProcess();
            CheckMC();
        }

    
        public static int Check = 0;
     
        public void PB_Tick(object sender, EventArgs e)
        {

        }
        public static bool finish = false;
        public static bool checkfile = false;
        public static bool scan1 = false;

       
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (label9.Text == "Downloading Modules..." && checkfile == false)
            {
                if (bunifuProgressBar1.Value == 20)
                {
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;

            }

            if (label9.Text == "Check #1 is in progress..." && checkfile == false && scan1 == false)
            {
                if (bunifuProgressBar1.Value == 26)
                {
                    scan1 = true;
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;

            }

            if (Check == 1 && checkfile == false)
            {
                label9.Text = "Check #2 is in progress...";
                if (bunifuProgressBar1.Value == 36)
                {
                    hbwait(1000);
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;

            }

            if (Check == 2 && checkfile == false)
            {
                label9.Text = "Check #3 is in progress...";
                if (bunifuProgressBar1.Value == 53)
                {
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;

            }


            if (Check == 3 && checkfile == false)
            {
                label9.Text = "Check #4 is in progress...";
                if (bunifuProgressBar1.Value == 69)
                {
              
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;
            }

            if (Check == 4 && checkfile == false)
            {
                label9.Text = "Check #5 is in progress...";
                if (bunifuProgressBar1.Value == 75)
                {
      
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;
            }


            if (Check == 5 && checkfile == false)
            {
                label9.Text = "Check #6 is in progress...";
                if (bunifuProgressBar1.Value == 89)
                {
                    finish = true;
                    checkfile = true;
                    return;
                }
                bunifuProgressBar1.Value += 1;
            }

            if (finish == true && checkfile == true)
            {
                
                if (bunifuProgressBar1.Value == 100)
                {
                    File.Delete(Path.GetTempPath() + Utils.RandomFile + @"\" + "Ghosting.exe");
                    CoolDown.Enabled = false;
                    label9.Text = "Finish...";
                    panel2.Visible = true;
                    GROSCHIENDETESMORT.Visible = true;
                    timer1.Enabled = false;


          

                    Dictionary<string, string> output = new Dictionary<string, string>();
                    //output.Add("Processus", listProcessus);
                    
                    Processus PCA = new Processus("PCA");
                    Result res = new Result(CheckDPS.ResultPCA);
                    PCA.results.Add(res);
                    listProcessus.Add(PCA);

                    Processus VPNCheck = new Processus("vpn");
                    res = new Result(VPN);
                    VPNCheck.results.Add(res);
                    listProcessus.Add(VPNCheck);

                    Processus Time = new Processus("Time");
                    res = new Result(label12.Text);
                    Time.results.Add(res);
                    listProcessus.Add(Time);

                    Processus ExplorerRestart = new Processus("ExplorerRestart");
                    res = new Result(Utils.ExplorerRestarted);
                    ExplorerRestart.results.Add(res);
                    listProcessus.Add(ExplorerRestart);

                    Processus DwmRestart = new Processus("DwmRestart");
                    res = new Result(Utils.DwmRestarted);
                    DwmRestart.results.Add(res);
                    listProcessus.Add(DwmRestart);

                    Processus DPSCheck = new Processus("DPSCheck");
                    res = new Result(CheckDPS.ResultDPS);
                    DPSCheck.results.Add(res);
                    listProcessus.Add(DPSCheck);

                    Processus PCACheck = new Processus("PCACheck");
                    res = new Result(CheckDPS.ResultPCA);
                    PCACheck.results.Add(res);
                    listProcessus.Add(PCACheck);

                    Processus Username = new Processus("Username");
                    res = new Result(Utils.UsernameMC);
                    Username.results.Add(res);
                    listProcessus.Add(Username);
                 
      
                    if (DeletedFiles.FileDeleted.Count != 0)
                    {
                        Processus DF = new Processus("DeletedFiles");
                        foreach (string resultdeleted in DeletedFiles.FileDeleted)
                        {
                            res = new Result(resultdeleted);
                            DF.results.Add(res);
                            

                            // en faite le problème ici c'est que comme j'ai supr 2 exe ça doit donner 2 string donc en faite l'erreur est que ça add 2 fois la même chose genre ça crée
                            // peut être 2 processus ou jsp 
                        }
                        listProcessus.Add(DF);
                    }
                    else
                    {
                        Processus DeletedFiles = new Processus("DeletedFiles");
                        res = new Result("No");
                        DeletedFiles.results.Add(res);
                        listProcessus.Add(DeletedFiles);
                    }


                    string TE;

                    TE = JsonConvert.SerializeObject(listProcessus);

                    string mdr = "";
                    string resultField = "";
                    int i = 0;
                    foreach(var p in listProcessus)
                    {
                        if(p.results.Count == 0)
                        {
                            Result lamda = new Result("lamda");
                            p.results.Add(lamda);
                        }
                        resultField = "";
                        i = 0;
                        foreach (var r in p.results)
                        { // ? j'ai pris ton pin
                            i++;
                            resultField += r.result;
                            if (i < p.results.Count - 1)
                            {
                                resultField += ";";
                            }
                        }
                        mdr += p.name + "\t";
                        
                        output.Add(p.name, resultField);
                    }

     
                    API.sendResult(output, Login.token);
             
                    return;
                }
                bunifuProgressBar1.Value += 1;
            }

            

            // Discordeu
        }
      
        private void GROSCHIENDETESMORT_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.GetTempPath() + Utils.RandomFile))
            {
                Directory.Delete(Path.GetTempPath() + Utils.RandomFile);
            }

            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (finish == false)
            {
                e.Cancel = true;
            }
            else
            {
                if (Directory.Exists(Path.GetTempPath() + Utils.RandomFile))
                {
                    Directory.Delete(Path.GetTempPath() + Utils.RandomFile);
                }
                Application.Exit();
            }

        }

        int i = 0;
     
        private void CoolDown_Tick(object sender, EventArgs e)
        {
            i++;
            label12.Text = i.ToString();
        }
    }
}
