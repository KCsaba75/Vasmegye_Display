using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vasmegye
{
    public partial class GrafikusFelulet : Form
    {
        private List<Szuletesek> szuletesek = new List<Szuletesek>();

        
       

        public GrafikusFelulet()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Form beállításai
            this.Text = "Vasmegye";
           

            // TextBox inicializálása
            
            tbEredmeny.Multiline = true;
            tbEredmeny.ScrollBars = ScrollBars.Vertical;
            tbEredmeny.ReadOnly = true;
            tbEredmeny.Dock = DockStyle.Fill;

            // Betöltés gomb inicializálása
            
            betoltesButton.Text = "Adatok Betöltése";
            betoltesButton.AutoSize=true;
            betoltesButton.Click += BetoltesButton_Click;

            // Feldolgozás gomb inicializálása
           
            feldolgozasButton.Text = "Adatok Feldolgozása";
            betoltesButton.AutoSize = true;
           
            feldolgozasButton.Click += FeldolgozasButton_Click;

            // Panel inicializálása és elemek hozzáadása
           
           
          

            // Form elemeinek hozzáadása
           
            
        }

        private void BetoltesButton_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("vas.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                szuletesek.Add(new Szuletesek(sr.ReadLine()));
            }

            sr.Close();
            DisplayMessage("Adatok betöltve.");
        }

        private void FeldolgozasButton_Click(object sender, EventArgs e)
        {
            AdatokFeldolgozasa();
        }

        private void AdatokFeldolgozasa()
        {
            DisplayMessage("Adatok feldolgozása elkezdődött...");

            HibasAzonositoMegjelenitese();
            SzokonapMegjelenitese();
            NemekStatisztikaMegjelenitese();
            SzuletesekSzamaMegjelenitese();
            EvekStatisztikaMegjelenitese();

            DisplayMessage("Adatok feldolgozva.");
        }

        private void DisplayMessage(string message)
        {
            tbEredmeny.AppendText(message + Environment.NewLine);
        }

        private void EvekStatisztikaMegjelenitese()
        {
            var evek = szuletesek.GroupBy(x => x.Szuldatum.Year);
            foreach (var evCsoport in evek)
            {
                DisplayMessage($"\t{evCsoport.Key} év - {szuletesek.Count(x => x.Szuldatum.Year.Equals(evCsoport.Key))}");
            }
        }

        private void SzuletesekSzamaMegjelenitese()
        {
            DisplayMessage($"5. feladat: Vas megyében a vizsgált évek alatt {szuletesek.Count()} csecsemő született");
        }

        private void SzokonapMegjelenitese()
        {
            string vane = szuletesek.Any(x => x.Szuldatum.Month.Equals(02) && x.Szuldatum.Day.Equals(24)) ? "született" : "nem született";
            DisplayMessage($"8. feladat: Szökőnapon {vane} baba!");
        }

        private void NemekStatisztikaMegjelenitese()
        {
            DisplayMessage($"6. feladat: Fiúk száma: {szuletesek.Count(x => x.Nem.Equals("1") || x.Nem.Equals("3"))}");
        }

        private void HibasAzonositoMegjelenitese()
        {
            DisplayMessage("4. feladat: Ellenőrzés");
            foreach (var szules in szuletesek)
            {
                if (!CdvE11(szules.Teljesazonosito))
                {
                    DisplayMessage($"\tHibás a {szules.Nem}-{szules.Szuletes}-{szules.Azonosito}-{szules.Egyedikod} személyi azonosító");
                }
            }
        }

        static bool CdvE11(string azonosito)
        {
            int utolso = Convert.ToInt32(azonosito.Substring(azonosito.Length - 1, 1));
            int osszeg = 0;
            int leptet = 10;
            for (int i = 1; i <= azonosito.Length - 1; i++)
            {
                osszeg = osszeg + Convert.ToInt32(azonosito[i - 1]) * leptet;
                leptet--;
            }

            int egyedikod = osszeg % 11;

            return egyedikod == utolso;
        }
    }

    class Szuletesek
    {
        private string nem;
        private string szuletes;
        private DateTime szuldatum;
        private string azonosito;
        private string egyedikod;
        private string teljesazonosito;

        public Szuletesek(string Adatsor)
        {
            string[] sor = Adatsor.Split('-');
            string ev = "";
            nem = sor[0];
            szuletes = sor[1];
            if (szuletes.StartsWith("0"))
            {
                ev = "20" + szuletes.Substring(0, 2) + "-" + szuletes.Substring(2, 2) + "-" + szuletes.Substring(4, 2);
            }
            if (szuletes.StartsWith("9"))
            {
                ev = "19" + szuletes.Substring(0, 2) + "-" + szuletes.Substring(2, 2) + "-" + szuletes.Substring(4, 2); ;
            }
            Szuldatum = Convert.ToDateTime(ev);
            azonosito = sor[2].Remove(sor[2].Length - 1);
            egyedikod = sor[2].Substring(sor[2].Length - 1, 1);
            teljesazonosito = nem + szuletes + azonosito + egyedikod;
        }

        public string Nem { get => nem; set => nem = value; }
        public string Szuletes { get => szuletes; set => szuletes = value; }
        public string Azonosito { get => azonosito; set => azonosito = value; }
        public string Egyedikod { get => egyedikod; set => egyedikod = value; }
        public string Teljesazonosito { get => teljesazonosito; set => teljesazonosito = value; }
        public DateTime Szuldatum { get => szuldatum; set => szuldatum = value; }
    }

}
