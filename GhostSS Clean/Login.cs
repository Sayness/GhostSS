using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aes256CbcEncrypterApp;
using GhostSS;
using GhostSS.API;
using GhostSS_Clean;
using Newtonsoft.Json;

namespace GhostSS_Clean
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        public static string cassingText;
        public static string Pin;
        public static string IdUser;

        private Main f2;
        public static string token = null;
        public void CheckPin()
        {

            byte[] Key = Convert.FromBase64String("PgPub55WkbbAw7Tc6KlPIHzQ8GGkRzB9UFJZMfbWhE4=");
            Dictionary<string, string> values = new Dictionary<string, string>(); 
          
            values.Add("pin", cassingText);
            string reponse = API.sendPin(ED.Encrypt("pin=" + cassingText, Key)).Result;
            MessageBox.Show(reponse);
            var res = JsonConvert.DeserializeObject<Dictionary<string, string>>(reponse);
            token = res["token"]; // IL Y A PAS DE MSGBOX HEIN
           

            if (reponse.Contains("BR") && reponse.Contains("QU") && reponse.Contains("PD"))
            {
                Main Scan = new Main();
                this.Hide();
                Scan.Show();
            }
            else
            {

            }
            MessageBox.Show(token); // J'ai rien touché depuis tt a l'heure
        }

       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

             cassingText = filsdepute.text;

          // MECCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
          // TU VOIS ? HO FDP 
                Thread thr6 = new Thread(CheckPin);
                thr6.Start();




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
      
        private void Login_Load(object sender, EventArgs e)
        {
            Protection.CheckSandbox();
            //Thread ParentThread = new Thread(Protection.CheckParent);
            //ParentThread.Start();

            this.Show();

            var ct = new CancellationTokenSource();

            new Task(() => Protection.CheckIllegalProcess()).Repeat(ct.Token, TimeSpan.FromSeconds(1));



            Thread AD1 = new Thread(AD.Initialize);
            AD1.Start();

            //var Ch = new CancellationTokenSource();

            //new Task(() => Utils.CheckClipBoardPIN()).Repeat(Ch.Token, TimeSpan.FromSeconds(1));
        }
       
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void filsdepute_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void filsdepute_KeyPress(object sender, EventArgs e)
        {
      
        }

    }
}
